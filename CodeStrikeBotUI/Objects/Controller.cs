using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace CodeStrikeBot
{
    class Controller
    {
        private const int FORM_X = 5;
        private const int FORM_Y = 5;
        //private const int BLUESTACKS_TITLEBAR_H = 37;
        //public const int DROID4X_TITLEBAR_H = 38;
        //public const int DROID4X_LEFTMARGIN = 63;
        public const int SCREEN_W = 394;//468;
        public const int SCREEN_H = 702;//830;
        private const int TIMEOUT_CLICK = 200;
        private const int TIMEOUT_KEY = 300;
        private const int TIMEOUT_SCRCAP = 100;

        public static Controller Instance { get; private set; }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string sWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, UInt32 message, UInt32 wParam, Int64 lParam);
        //LRESULT WINAPI SendMessage(HWND hWnd, UINT Msg, UINT_PTR wParam, LONG_PTR lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 uMsg, IntPtr wParam, ref TITLEBARINFOEX lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 message, UInt32 wParam, Int64 lParam);
        
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int cButtons, uint dwExtraInfo);
        //private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 cButtons, UInt64 dwExtraInfo);
        //VOID mouse_event(DWORD dwFlags, DWORD dx, DWORD dy, DWORD dwData, ULONG_PTR dwExtraInfo);
        
        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int vKey);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        static extern bool SetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(IntPtr hWnd, IntPtr hWndTo, bool attach);

        public int ActiveWindow { get; set; }

        private Semaphore semaphore;

        public BotDatabase Database;
        private PushoverClient.Pushover pclient;

        public Screen[] sc { get; private set; }

        public List<DataObjects.App> apps;
        public List<DataObjects.EmulatorInstance> emulators;
        public List<DataObjects.Account> accounts;

        public List<Messages.Objects.March> marches, endedMarches;
        public List<Messages.Objects.Rally> rallies;
        public List<Messages.Objects.Tile> tiles;

        public DateTime StartScheduler, StartTasks, StartScreenState, StartAutoActions;

        public Controller()
        {
            Instance = this;

            marches = new List<Messages.Objects.March>();
            endedMarches = new List<Messages.Objects.March>();

            rallies = new List<Messages.Objects.Rally>();

            tiles = new List<Messages.Objects.Tile>();
            
            Database = new BotDatabase();

            apps = DataObjects.App.GetApps();
            accounts = DataObjects.Account.GetAccounts(apps);
            emulators = DataObjects.EmulatorInstance.GetEmulators(accounts, apps);

            bool restart = false;

            sc = new Screen[4];
            for (int i = 0; i < Database.Settings.ActiveEmulators.Length; i++)
            {
                foreach (DataObjects.EmulatorInstance e in emulators)
                {
                    if (e.Id == Database.Settings.ActiveEmulators[i])
                    {
                        sc[i] = Screen.CreateScreen(e);
                        if (sc[i].EmulatorProcess == null)
                        {
                            if (sc[i].Emulator != null)
                            {
                                StartEmulator(sc[i]);
                                Login(sc[i], sc[i].Emulator.LastKnownAccount);
                                //restart = true;
                            }
                        }
                        break;
                    }
                }
            }

            if (restart)
            {
                Program.RestartApp();
            }

            /*if (sc[0] == null)
            {
                sc[0] = Screen.CreateScreen("Leapdroid");
            }
            if (sc[1] == null)
            {
                sc[1] = Screen.CreateScreen("Leapdroid");
            }
            if (sc[2] == null)
            {
                sc[2] = Screen.CreateScreen("Leapdroid");
            }
            if (sc[3] == null)
            {
                sc[3] = Screen.CreateScreen("Leapdroid");
            }*/

            //Database.UpdateSettings(new EmulatorInstance[4] { sc[0].Emulator, sc[1].Emulator, sc[2].Emulator, sc[3].Emulator }, Database.ScreenshotDir, Database.MapDir);

            this.RefreshWindows();
            this.UpdateWindowInfo();

            ActiveWindow = 0;
            semaphore = new Semaphore(1, 1);

            pclient = new PushoverClient.Pushover(Database.Settings.PushoverAPIKey);
        }

        public Screen ActiveScreen { get { return sc[ActiveWindow]; } }

        public Screen GetFirstAbleWindow()
        {
            foreach (Screen s in sc)
            {
                Controller.CaptureApplication(s);
                ScreenState state = s.ScreenState;

                if (state.CurrentArea == Area.StateMaps.Main || state.CurrentArea == Area.MainBases.Main)
                {
                    return s;
                }
            }

            return null;
        }

        public DataObjects.Account FindAccount(string name)
        {
            foreach (DataObjects.Account a in accounts)
            {
                if (a.App.ShortName == "FFXV" && a.Name.ToLower() == name.ToLower())
                {
                    return a;
                }
            }

            foreach (DataObjects.Account a in accounts)
            {
                if (a.App.ShortName == "FFXV" && a.UserName.ToLower() == name.ToLower())
                {
                    return a;
                }
            }

            return null;
        }

        public DataObjects.Account FindAccount(int id)
        {
            foreach (DataObjects.Account a in accounts)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }

            return null;
        }

        public DataObjects.EmulatorInstance[] GetEmulators()
        {
            DataObjects.EmulatorInstance[] emulators = new DataObjects.EmulatorInstance[sc.Length];

            for (int s = 0; s < sc.Length; s++)
            {
                emulators[s] = sc[s].Emulator;
            }

            return emulators;
        }

        public string GetFullScreenshotDir()
        {
            string dir = Database.Settings.ScreenshotDir;
            
            if (!dir.Contains(':'))
            {
                dir = String.Format("{0}\\{1}", System.Windows.Forms.Application.StartupPath, Database.Settings.ScreenshotDir);
            }

            return dir;
        }

        public void BeginTask(int delay = 0)
        {
            semaphore.WaitOne();
            Thread.Sleep(delay);
            UpdateWindowInfo();
        }

        public void EndTask()
        {
            try
            {
                semaphore.Release();
            }
            catch (System.Threading.SemaphoreFullException e)
            {
                BotDatabase.InsertLog(0, "Semaphore Kill", String.Format("{0}{1}", e.Message, e.StackTrace), new byte[1] { 0x0 });
            }
        }

        public string GetStatusMessage()
        {
            string message = "";

            foreach (Screen s in sc)
            {
                if (s != null)
                {
                    if (s.Emulator.LastKnownAccount != null)
                    {
                        message += String.Format("{0}: ", s.Emulator.LastKnownAccount.Name);
                    }
                    else
                    {
                        message += String.Format("{0}: ", "<empty>");
                    }

                    if (s.EmulatorProcess == null)
                    {
                        message += "Offline";
                    }
                    else
                    {
                        Controller.CaptureApplication(s);
                        ScreenState state = s.ScreenState;

                        message += state;
                    }
                }
                else
                {
                    message += "Offline";
                }

                message += "\n";
            }

            message = message.Substring(0, message.Length - 1);

            return message;
        }

        public DataObjects.ScheduleTask GetNextTask()
        {
            List<DataObjects.ScheduleTask> tasks = DataObjects.ScheduleTask.GetTasks(accounts, apps);

            foreach (DataObjects.ScheduleTask t in tasks)
            {
                if (t.Type == ScheduleType.Shield || t.Type == ScheduleType.AntiScout || t.Type == ScheduleType.GhostRally)
                {
                    foreach (Screen s in sc)
                    {
                        if (s.Emulator.App.Id == t.App.Id)
                        {
                            return t;
                        }
                    }
                }
            }

            foreach (DataObjects.ScheduleTask t in tasks)
            {
                foreach (Screen s in sc)
                {
                    if (s != null && s.Emulator.LastKnownAccount != null && t.Account.Id == s.Emulator.LastKnownAccount.Id && t.App.Id == s.Emulator.App.Id)
                    {
                        return t;
                    }
                }
            }

            foreach (DataObjects.ScheduleTask t in tasks)
            {
                foreach (Screen s in sc)
                {
                    if (s.Emulator.App.Id == t.App.Id)
                    {
                        return t;
                    }
                }
            }

            return null;
        }

        public Screen GetNextWindow(DataObjects.Account account)
        {
            Screen screen = null;

            foreach (Screen s in sc)
            {
                if (s != null && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.LastKnownAccount != null && s.Emulator.LastKnownAccount.Id == account.Id)
                {
                    screen = s;
                    break;
                }
            }

            if (screen == null)
            {
                foreach (Screen s in sc)
                {
                    if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && (s.Emulator.LastKnownAccount == null || s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android))
                    {
                        screen = s;
                        break;
                    }
                }

                if (screen == null)
                {
                    foreach (Screen s in sc)
                    {
                        if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority < 3 && !s.ScreenState.Overlays.Contains(Overlay.Widgets.MissionsAvailable) && !s.ScreenState.Overlays.Contains(Overlay.Widgets.GlobalGift) && !s.ScreenState.Overlays.Contains(Overlay.Widgets.AllianceHelp))
                        {
                            screen = s;
                            break;
                        }
                    }

                    if (screen == null)
                    {
                        foreach (Screen s in sc)
                        {
                            if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.LastKnownAccount != null && s.Emulator.LastKnownAccount.Priority == 0)
                            {
                                screen = s;
                                break;
                            }
                        }

                        if (screen == null)
                        {
                            foreach (Screen s in sc)
                            {
                                if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority == 1)
                                {
                                    screen = s;
                                    break;
                                }
                            }

                            if (screen == null)
                            {
                                foreach (Screen s in sc)
                                {
                                    if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority == 2)
                                    {
                                        screen = s;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return screen;
        }

        public Screen GetNextWindow(DataObjects.ScheduleTask task)
        {
            Screen screen = null;

            foreach (Screen s in sc)
            {
                if (s != null && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && s.Emulator.LastKnownAccount != null && s.Emulator.LastKnownAccount == task.Account)
                {
                    screen = s;
                    break;
                }
            }

            if (screen == null)
            {
                foreach (Screen s in sc)
                {
                    if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && (s.Emulator.LastKnownAccount == null || s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android))
                    {
                        screen = s;
                        break;
                    }
                }

                if (screen == null)
                {
                    foreach (Screen s in sc)
                    {
                        if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority < 3 && !s.ScreenState.Overlays.Contains(Overlay.Widgets.MissionsAvailable) && !s.ScreenState.Overlays.Contains(Overlay.Widgets.GlobalGift) && !s.ScreenState.Overlays.Contains(Overlay.Widgets.AllianceHelp))
                        {
                            screen = s;
                            break;
                        }
                    }

                    if (screen == null)
                    {
                        foreach (Screen s in sc)
                        {
                            if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && s.Emulator.LastKnownAccount != null && s.Emulator.LastKnownAccount.Priority == 0)
                            {
                                screen = s;
                                break;
                            }
                        }

                        if (screen == null)
                        {
                            foreach (Screen s in sc)
                            {
                                if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority == 1)
                                {
                                    screen = s;
                                    break;
                                }
                            }

                            if (screen == null)
                            {
                                foreach (Screen s in sc)
                                {
                                    if (s != null && !s.PreventFromOpening && !s.IsFucked && s.EmulatorProcess != null && s.Emulator.App.Id == task.App.Id && s.Emulator.LastKnownAccount != null && (int)s.Emulator.LastKnownAccount.Priority == 2)
                                    {
                                        screen = s;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return screen;
        }

        public void ExecuteTask(DataObjects.ScheduleTask task)
        {
            try
            {
                BeginTask();
                SpeedTest();

                Screen screen = GetNextWindow(task);
                Stopwatch tmrRun = new Stopwatch();

                if (screen != null)
                {
                    tmrRun.Start();

                    if (screen.Emulator.LastKnownAccount != null && screen.Emulator.LastKnownAccount.Id == task.Account.Id && screen.PreventFromOpening)		
                    {		
                        screen.PreventFromOpening = false;		
                        screen.Emulator.LastKnownAccount = null;		
                    }

                    while ((screen.Emulator.LastKnownAccount == null || screen.Emulator.LastKnownAccount.Id != task.Account.Id) && tmrRun.ElapsedMilliseconds < 70000)
                    {
                        Logout(screen);
                        StartApp(screen);
                        CaptureApplication(screen);
                        if (screen.ScreenState.CurrentArea == Area.Others.Login)		
                        {		
                            Login(screen, task.Account);		
                        }		
                        else		
                        {		
                            screen.Emulator.LastKnownAccount = task.Account;		
                            screen.Emulator.Save();		
                        }
                    }

                    if (screen.Emulator.LastKnownAccount != null && screen.Emulator.LastKnownAccount.Id == task.Account.Id)
                    {
                        bool success = false;

                        switch (task.Type)
                        {
                            case ScheduleType.StoneTransfer:
                            case ScheduleType.OilTransfer:
                            case ScheduleType.IronTransfer:
                            case ScheduleType.FoodTransfer:
                            case ScheduleType.CoinTransfer:
                                success = screen.ResourceTransfer(task);
                                break;
                            case ScheduleType.Shield:
                            case ScheduleType.AntiScout:
                                success = screen.ActivateBoost(task);
                                if (!success)
                                {
                                    SendNotification(String.Format("Failed to activate {0} on {1}", task.Type.ToString(), task.Account.ToString()), NotificationType.BoostActivationFail);
                                }
                                break;
                            case ScheduleType.ActivateVIP:
                                success = screen.ActivateVIP(task.Amount);
                                break;
                            case ScheduleType.Login:
                                success = true;
                                break;
                        }

                        if (success)
                        {
                            task.LastAction = DateTime.Now;
                            task.Save();
                        }
                        else
                        {
                            //TODO Slow mode
                            //screen.TimeoutFactor = 1.0;
                            screen.TimeoutFactor = 5.0;
                        }
                    }

                    tmrRun.Stop();
                }
            }
            catch (Exception e)
            {
                BotDatabase.InsertLog(0, String.Format("{0} {1}", e.GetType(), e.Message), e.StackTrace, new byte[1] { 0x0 });
                Controller.Instance.SendNotification(String.Format("Scheduler Crash {0} {1}", e.GetType(), e.Message), NotificationType.Crash);
            }
            finally
            {
                EndTask();
            }
        }

        public void RestartEmulator(Screen s, bool restart = true)
        {
            KillEmulator(s, restart);
            StartEmulator(s);

            if (restart)
            {
                Program.RestartApp();
            }
        }

        public void KillEmulator(Screen s, bool restart = true)
        {
            if (s != null)
            {
                Stopwatch tmrRun = new Stopwatch();

                if (s.EmulatorProcess != null && !s.EmulatorProcess.HasExited)
                {
                    s.EmulatorProcess.Kill();
                    s.EmulatorProcess.WaitForExit();
                }
                Thread.Sleep(7000);
                //TODO Slow mode
                s.TimeoutFactor = 1.0;

                if (restart)
                {
                    Program.RestartApp();
                }
            }
        }

        public void StartEmulator(Screen s)
        {
            bool success = false;

            while (!success)
            {
                success = true;

                if (s != null && s.Emulator != null)
                {
                    string prog, args;
                    if (s.Emulator.Command.StartsWith("\""))
                    {
                        prog = s.Emulator.Command.Substring(1, s.Emulator.Command.IndexOf("\"", 1) - 1);
                        args = s.Emulator.Command.Substring(prog.Length + 2).Trim();
                    }
                    else
                    {
                        prog = s.Emulator.Command.Substring(0, s.Emulator.Command.IndexOf(" ", 0));
                        args = s.Emulator.Command.Substring(prog.Length).Trim();
                    }
                    System.Diagnostics.Process.Start(prog, args);
                    System.Threading.Thread.Sleep(6000);
                    foreach (Process p in Process.GetProcessesByName(s.ProcessName))
                    {
                        if (p.CommandLineArgs(s.Emulator.Type) == s.Emulator.Command)
                        {
                            s.EmulatorProcess = p;
                            break;
                        }
                    }
                    RefreshWindows();
                    UpdateWindowInfo();
                    Controller.CaptureApplication(s);
                    if (s.ScreenState != null)
                    {
                        using (Bitmap bmpScreenCapture = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height))
                        {
                            ushort chksum = 0;

                            while (s.ScreenState.CurrentArea == Area.Emulators.Loading || chksum == 0x0474)
                            {
                                System.Windows.Forms.Application.DoEvents();

                                Thread.Sleep(500);
                                Controller.CaptureApplication(s);

                                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                                {
                                    g.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                                }

                                chksum = bmpScreenCapture.Checksum(510, 442, 20, 20);
                                if (chksum == 0x0474)
                                {
                                    Controller.SendClick(null, 980, 620, 1000);
                                    success = false;
                                }
                            }
                        }

                        if (s.ScreenState.CurrentArea == Area.Emulators.Android)
                        {
                            s.IsFucked = false;
                        }
                    }
                    else
                    {
                        Program.RestartApp();
                    }
                }
            }
        }

        public void SpeedTest()
        {
            foreach (Screen s in sc)
            {
                //TODO Slow mode
                if (s != null && s.ScreenState != null && s.TimeoutFactor == 1.0 && s.ScreenState.CurrentArea != Area.Others.Login && s.ScreenState.CurrentArea != Area.Others.Splash && s.ScreenState.CurrentArea != Area.Emulators.Android && s.ScreenState.CurrentArea != Area.Emulators.Crash && s.ScreenState.CurrentArea != Area.Emulators.Loading && s.ScreenState.CurrentArea != Area.Emulators.TaskManager && s.ScreenState.CurrentArea != Area.Emulators.TaskManagerApp && s.ScreenState.CurrentArea != Area.Emulators.TaskManagerRemove)
                {
                    s.SpeedTest();
                }
            }
        }

        public void RegularTasks()
        {
            Stopwatch tmrRun = new Stopwatch();

            bool tasksLeft = true;

            bool failed = false;

            SpeedTest();

            tmrRun.Start();

            while (tasksLeft && tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = false;

                foreach (Screen s in sc)
                {
                    if (s != null && s.EmulatorProcess != null)
                    {
                        if (s.GoToBaseOrMapStep())
                        {
                            tasksLeft = true;
                        }
                    }
                }
            }

            if (tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = true;

                tmrRun.Restart();

                while (tasksLeft && tmrRun.ElapsedMilliseconds < 20000)
                {
                    tasksLeft = false;

                    foreach (Screen s in sc)
                    {
                        if (s != null && s.EmulatorProcess != null)
                        {
                            Controller.CaptureApplication(s);

                            //go to world view
                            if (s.ScreenState.CurrentArea != Area.StateMaps.Main && !(s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android || s.ScreenState.CurrentArea == Area.Emulators.Loading || s.ScreenState.CurrentArea == Area.Others.Splash || s.ScreenState.CurrentArea == Area.Emulators.Crash || s.ScreenState.CurrentArea == Area.Emulators.TaskManager || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerApp || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove))
                            {
                                tasksLeft = true;
                                Controller.SendClick(s, 40, 675, 400); //click World
                            }
                        }
                    }
                }

                if (tmrRun.ElapsedMilliseconds < 20000)
                {
                    tasksLeft = true;

                    tmrRun.Restart();

                    while (tasksLeft && tmrRun.ElapsedMilliseconds < 10000)
                    {
                        tasksLeft = false;

                        foreach (Screen s in sc)
                        {
                            if (s != null && s.EmulatorProcess != null)
                            {
                                Controller.CaptureApplication(s);

                                //go to base view
                                if (s.ScreenState.CurrentArea != Area.MainBases.Main && !(s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android || s.ScreenState.CurrentArea == Area.Emulators.Loading || s.ScreenState.CurrentArea == Area.Others.Splash || s.ScreenState.CurrentArea == Area.Emulators.Crash || s.ScreenState.CurrentArea == Area.Emulators.TaskManager || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerApp || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove))
                                {
                                    tasksLeft = true;
                                    Controller.SendClick(s, 40, 675, 300); //click Base
                                }
                            }
                        }
                    }

                    if (tmrRun.ElapsedMilliseconds < 10000)
                    {
                        tasksLeft = true;

                        tmrRun.Restart();

                        foreach (Screen s in sc)
                        {
                            if (s != null)
                            {
                                s.skipMissions = false;
                                s.skipRewards = false;
                                s.skipVault = false;
                            }
                        }

                        while (tasksLeft && tmrRun.ElapsedMilliseconds < 60000)
                        {
                            tasksLeft = false;

                            foreach (Screen s in sc)
                            {
                                if (s != null)
                                {
                                    if (!s.IsFucked && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading && s.RegularTasksStep())
                                    {
                                        tasksLeft = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Screen s in sc)
                        {
                            if (s != null && s.EmulatorProcess != null)
                            {
                                Controller.CaptureApplication(s);

                                if (s.ScreenState.CurrentArea != Area.MainBases.Main && !(s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android || s.ScreenState.CurrentArea == Area.Emulators.Loading || s.ScreenState.CurrentArea == Area.Others.Splash || s.ScreenState.CurrentArea == Area.Emulators.Crash || s.ScreenState.CurrentArea == Area.Emulators.TaskManager || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerApp || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove))
                                {
                                    RestartEmulator(s);
                                    s.Login(s.Emulator.LastKnownAccount);
                                }
                            }
                        }
                    }
                }
                else
                {
                    failed = true;
                }
            }
            else
            {
                failed = true;
            }

            if (failed)
            {
                foreach (Screen s in sc)
                {
                    if (s != null && s.EmulatorProcess != null)
                    {
                        Controller.CaptureApplication(s);

                        if (s.ScreenState.CurrentArea != Area.StateMaps.Main && s.ScreenState.CurrentArea != Area.StateMaps.FullScreen && s.ScreenState.CurrentArea != Area.MainBases.Main && !(s.ScreenState.CurrentArea == Area.Others.Login || s.ScreenState.CurrentArea == Area.Emulators.Android || s.ScreenState.CurrentArea == Area.Emulators.Loading || s.ScreenState.CurrentArea == Area.Others.Splash || s.ScreenState.CurrentArea == Area.Emulators.Crash || s.ScreenState.CurrentArea == Area.Emulators.TaskManager || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerApp || s.ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove))
                        {
                            RestartEmulator(s);
                            s.Login(s.Emulator.LastKnownAccount);
                        }
                    }
                }
            }

            tmrRun.Stop();
        }

        public void Logout()
        {
            Logout(ActiveScreen);
        }

        public void Logout(Screen s)
        {
            Stopwatch tmrRun = new Stopwatch();

            if (s != null)
            {
                tmrRun.Start();

                while (!s.Logout() && tmrRun.ElapsedMilliseconds < 20000)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                if (tmrRun.ElapsedMilliseconds < 20000 && s.Emulator.LastKnownAccount != null && s.Emulator.LastKnownAccount.Id != 0)
                {
                    s.Emulator.LastKnownAccount.LastLogout = DateTime.Now;
                    s.Emulator.LastKnownAccount.Save();
                    s.Emulator.LastKnownAccount = null;
                    s.Emulator.Save();
                }

                tmrRun.Stop();
            }
        }

        public void Login(DataObjects.Account account)
        {
            if (account != null && account.Email != null)
            {
                Login(ActiveScreen, account);
            }
        }

        public void Login(Screen s, DataObjects.Account account)
        {
            Stopwatch tmrRun = new Stopwatch();

            if (s != null && account != null && account.Email != null && s.Login(account))
            {
                account.LastLogin = DateTime.Now;
                account.LastLogout = account.LastLogin;
                account.Save();
                s.Emulator.LastKnownAccount = account;
                s.Emulator.Save();

                foreach (Screen scr in sc)
                {
                    if (scr != null)
                    {
                        scr.PreventFromOpening = false;
                    }
                }
            }
        }

        public void StartApp()
        {
            StartApp(ActiveScreen);
        }

        public void StartApp(Screen s)
        {
            s.StartApp();

            if (s.Emulator.LastKnownAccount == null)
            {
                s.Emulator.Save();
            }
        }

        public void CollectGifts()
        {
            Stopwatch tmrRun = new Stopwatch();

            bool tasksLeft = true;

            tmrRun.Start();

            while (tasksLeft && tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = false;

                foreach (Screen s in sc)
                {
                    if (s.GoToBaseOrMapStep())
                    {
                        tasksLeft = true;
                    }
                }
            }

            if (tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = true;

                tmrRun.Restart();

                while (tasksLeft && tmrRun.ElapsedMilliseconds < 60000)
                {
                    tasksLeft = false;

                    foreach (Screen s in sc)
                    {
                        if (s.CollectGiftsStep())
                        {
                            tasksLeft = true;
                        }
                    }
                }
            }

            tmrRun.Stop();
        }

        public void CollectMissions()
        {
            Stopwatch tmrRun = new Stopwatch();
            
            bool tasksLeft = true;

            tmrRun.Start();

            while (tasksLeft && tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = false;

                foreach (Screen s in sc)
                {
                    if (s.GoToBaseOrMapStep())
                    {
                        tasksLeft = true;
                    }
                }
            }

            if (tmrRun.ElapsedMilliseconds < 10000)
            {
                tasksLeft = true;

                tmrRun.Restart();

                while (tasksLeft && tmrRun.ElapsedMilliseconds < 60000)
                {
                    tasksLeft = false;

                    foreach (Screen s in sc)
                    {
                        if (s.CompleteMissionsStep())
                        {
                            tasksLeft = true;
                        }
                    }
                }
            }

            tmrRun.Stop();
        }

        public static void SendClick(Screen s, int x, int y, int timeout = 0, int hold = 0)
        {
            if (s != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                if (s.Emulator.Type == EmulatorType.Leapdroid)
                {
                    SendClickRaw(s, x, y, hold);
                }
                else
                {
                    SendClickBackground(s, x, y, hold);
                }

                Thread.Sleep((int)(timeout * s.TimeoutFactor));
            }
            else if (s == null)
            {
                SendClickRaw(s, x, y, hold);
            }
            //SendClickTest(s, x, y, hold);
        }

        public static void SendClickTest(Screen s, int x, int y, int timeout = 0, int hold = 0)
        {
            if (s != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                SendClickBackground(s, x, y, hold);

                Thread.Sleep((int)(timeout * s.TimeoutFactor));
            }
        }

        private static void SendClickBackground(Screen s, int x, int y, int hold = 0)
        {
            int wparam = s.WINDOW_TITLEBAR_H + y;
            wparam = wparam << 16;
            wparam += s.WINDOW_MARGIN_L + x;

            SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_LBUTTONDOWN, 0x1, wparam);
            SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_LBUTTONUP, 0x0, wparam);
        }

        private static void SendClickRaw(Screen s, int x, int y, int hold = 0)
        {
            if (x < 0)
            {
                x = x;
            }
            
            Point curPosition = System.Windows.Forms.Cursor.Position;
            Thread.Sleep(5);
            if (s != null)
            {
                x = s.WindowRect.left + s.WINDOW_MARGIN_L + x;
                y = s.WindowRect.top + s.WINDOW_TITLEBAR_H + y;
            }
            SetCursorPos(x, y);
            mouse_event((uint)MOUSEEVENTF.LEFTDOWN, (uint)x, (uint)y, 0, 0);
            Thread.Sleep(10 + hold);
            mouse_event((uint)MOUSEEVENTF.LEFTUP, (uint)x, (uint)y, 0, 0);
            Thread.Sleep(5);
            SetCursorPos(curPosition.X, curPosition.Y);
        }

        public static void SendClickDrag(Screen s, int fromX, int fromY, int toX, int toY, int dragTime, bool slide = false, int timeout = 0)
        {
            if (s != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                if (s.Emulator.Type == EmulatorType.Leapdroid)
                {
                    SendClickDragRaw(s, fromX, fromY, toX, toY, dragTime, slide);
                }
                else
                {
                    SendClickDragBackground(s, fromX, fromY, toX, toY, dragTime, slide);
                }

                Thread.Sleep((int)(timeout * s.TimeoutFactor));
            }
        }

        private static void SendClickDragRaw(Screen s, int fromX, int fromY, int toX, int toY, int dragTime, bool slide = false)
        {
            /*Point curPosition = System.Windows.Forms.Cursor.Position;
            Thread.Sleep(5);
            int offsetX = s.WindowRect.left + s.WINDOW_MARGIN_L, offsetY = s.WindowRect.top + s.WINDOW_TITLEBAR_H;
            SetCursorPos(offsetX + fromX, offsetY + fromY);
            mouse_event((uint)MOUSEEVENTF.LEFTDOWN, (uint)(offsetX + fromX), (uint)(offsetY + fromY), 0, 0);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < dragTime)
            {
                int newX = 30 + ((toX - fromX) * (int)watch.ElapsedMilliseconds / dragTime), newY = 400 + ((toY - fromY) * (int)watch.ElapsedMilliseconds / dragTime);

                mouse_event((uint)(MOUSEEVENTF.ABSOLUTE | MOUSEEVENTF.MOVE | MOUSEEVENTF.LEFTDOWN), (uint)(offsetX + newX), (uint)(offsetY + newY), 0, 0);

                Thread.Sleep((int)(5 * s.TimeoutFactor));
            }

            mouse_event((uint)(MOUSEEVENTF.ABSOLUTE | MOUSEEVENTF.MOVE | MOUSEEVENTF.LEFTDOWN), (uint)(offsetX + toX), (uint)(offsetY + toY), 0, 0);

            watch.Stop();
            if (!slide)
            {
                Thread.Sleep((int)(150 * s.TimeoutFactor));
            }

            mouse_event((uint)MOUSEEVENTF.LEFTUP, (uint)(offsetX + toX), (uint)(offsetY + toY), 0, 0);
            Thread.Sleep(5);
            SetCursorPos(curPosition.X, curPosition.Y);*/
        }

        private static void SendClickDragBackground(Screen s, int fromX, int fromY, int toX, int toY, int dragTime, bool slide = false)
        {
            int wparam = s.WINDOW_TITLEBAR_H + fromY;
            wparam = wparam << 16;
            wparam += s.WINDOW_MARGIN_L + fromX;
            SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_LBUTTONDOWN, 0x1, wparam);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < dragTime)
            {
                int newX = 30 + ((toX - fromX) * (int)watch.ElapsedMilliseconds / dragTime), newY = 400 + ((toY - fromY) * (int)watch.ElapsedMilliseconds / dragTime);

                wparam = s.WINDOW_TITLEBAR_H + newY;
                wparam = wparam << 16;
                wparam += s.WINDOW_MARGIN_L + newX;
                SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_MOUSEMOVE, 0x1, wparam);

                Thread.Sleep((int)(5 * s.TimeoutFactor));
            }

            wparam = s.WINDOW_TITLEBAR_H + toY;
            wparam = wparam << 16;
            wparam += s.WINDOW_MARGIN_L + toX;
            SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_MOUSEMOVE, 0x1, wparam);

            watch.Stop();
            if (!slide)
            {
                Thread.Sleep((int)(150 * s.TimeoutFactor));
            }

            SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_LBUTTONUP, 0x0, wparam);
        }

        public static void SendKey(Screen s, string keys, bool escape = false)
        {
            if (keys != null && s != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                if (s.Emulator.Type == EmulatorType.Leapdroid)
                {
                    Main.CurrentForm.Invoke(new Action(() => SendKeyAlternative(s, keys, escape)));
                }
                else
                {
                    if (keys.All(c => "1234567890".Contains(c)))
                    {
                        if (Main.CurrentForm.InvokeRequired)
                        {
                            Main.CurrentForm.Invoke(new Action(() => SendKeyDirect(s, keys)));
                        }
                        else
                        {
                            SendKeyDirect(s, keys);
                        }
                    }
                    else if (!s.ClipboardFailed)
                    {
                        if (Main.CurrentForm.InvokeRequired)
                        {
                            Main.CurrentForm.Invoke(new Action(() => SendKeyPaste(s, keys)));
                        }
                        else
                        {
                            SendKeyPaste(s, keys);
                        }
                    }
                    else if (keys.All(c => "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./\n".Contains(c)))
                    {
                        if (Main.CurrentForm.InvokeRequired)
                        {
                            Main.CurrentForm.Invoke(new Action(() => SendKeyDirect(s, keys)));
                        }
                        else
                        {
                            SendKeyDirect(s, keys);
                        }
                    }
                    else
                    {
                        if (Main.CurrentForm.InvokeRequired)
                        {
                            Main.CurrentForm.Invoke(new Action(() => SendKeyAlternative(s, keys, escape)));
                        }
                        else
                        {
                            SendKeyAlternative(s, keys, escape);
                            //SendKeyRaw(s, keys, escape);
                        }
                    }
                }
            }
        }

        private static void SendKeyPaste(Screen s, string keys, bool escape = false)
        {
            if (s.EmulatorProcess != null && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                if (!s.ClipboardFailed)
                {
                    IntPtr curWindow = GetForegroundWindow();
                    SetForegroundWindow(s.EmulatorProcess.MainWindowHandle);
                    System.Windows.Forms.Clipboard.SetText(keys);
                    System.Windows.Forms.SendKeys.SendWait("^v");
                    SetForegroundWindow(curWindow);
                    Thread.Sleep((int)(300 * s.TimeoutFactor));
                }
                else
                {
                    SendKeyAlternative(s, keys, escape);
                }
            }
        }

        private static void SendKeyDirect(Screen s, string keys)
        {
            if (s.EmulatorProcess != null && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                if (keys.All(c => "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./".Contains(c)))
                {
                    Thread.Sleep(500);

                    foreach (char c in keys)
                    {
                        VirtualKeyShort key = 0;
                        switch (c)
                        {
                            case 'a':
                                key = VirtualKeyShort.KEY_A;
                                break;
                            case 'b':
                                key = VirtualKeyShort.KEY_B;
                                break;
                            case 'c':
                                key = VirtualKeyShort.KEY_C;
                                break;
                            case 'd':
                                key = VirtualKeyShort.KEY_D;
                                break;
                            case 'e':
                                key = VirtualKeyShort.KEY_E;
                                break;
                            case 'f':
                                key = VirtualKeyShort.KEY_F;
                                break;
                            case 'g':
                                key = VirtualKeyShort.KEY_G;
                                break;
                            case 'h':
                                key = VirtualKeyShort.KEY_H;
                                break;
                            case 'i':
                                key = VirtualKeyShort.KEY_I;
                                break;
                            case 'j':
                                key = VirtualKeyShort.KEY_J;
                                break;
                            case 'k':
                                key = VirtualKeyShort.KEY_K;
                                break;
                            case 'l':
                                key = VirtualKeyShort.KEY_L;
                                break;
                            case 'm':
                                key = VirtualKeyShort.KEY_M;
                                break;
                            case 'n':
                                key = VirtualKeyShort.KEY_N;
                                break;
                            case 'o':
                                key = VirtualKeyShort.KEY_O;
                                break;
                            case 'p':
                                key = VirtualKeyShort.KEY_P;
                                break;
                            case 'q':
                                key = VirtualKeyShort.KEY_Q;
                                break;
                            case 'r':
                                key = VirtualKeyShort.KEY_R;
                                break;
                            case 's':
                                key = VirtualKeyShort.KEY_S;
                                break;
                            case 't':
                                key = VirtualKeyShort.KEY_T;
                                break;
                            case 'u':
                                key = VirtualKeyShort.KEY_U;
                                break;
                            case 'v':
                                key = VirtualKeyShort.KEY_V;
                                break;
                            case 'w':
                                key = VirtualKeyShort.KEY_W;
                                break;
                            case 'x':
                                key = VirtualKeyShort.KEY_X;
                                break;
                            case 'y':
                                key = VirtualKeyShort.KEY_Y;
                                break;
                            case 'z':
                                key = VirtualKeyShort.KEY_Z;
                                break;
                            case '0':
                                key = VirtualKeyShort.KEY_0;
                                break;
                            case '1':
                                key = VirtualKeyShort.KEY_1;
                                break;
                            case '2':
                                key = VirtualKeyShort.KEY_2;
                                break;
                            case '3':
                                key = VirtualKeyShort.KEY_3;
                                break;
                            case '4':
                                key = VirtualKeyShort.KEY_4;
                                break;
                            case '5':
                                key = VirtualKeyShort.KEY_5;
                                break;
                            case '6':
                                key = VirtualKeyShort.KEY_6;
                                break;
                            case '7':
                                key = VirtualKeyShort.KEY_7;
                                break;
                            case '8':
                                key = VirtualKeyShort.KEY_8;
                                break;
                            case '9':
                                key = VirtualKeyShort.KEY_9;
                                break;
                            case '`':
                                key = VirtualKeyShort.OEM_3;
                                break;
                            case '-':
                                key = VirtualKeyShort.OEM_MINUS;
                                break;
                            case '=':
                                key = VirtualKeyShort.OEM_PLUS;
                                break;
                            case '[':
                                key = VirtualKeyShort.OEM_4;
                                break;
                            case ']':
                                key = VirtualKeyShort.OEM_6;
                                break;
                            case '\\':
                                key = VirtualKeyShort.OEM_5;
                                break;
                            case ';':
                                key = VirtualKeyShort.OEM_1;
                                break;
                            case '\'':
                                key = VirtualKeyShort.OEM_7;
                                break;
                            case ',':
                                key = VirtualKeyShort.OEM_COMMA;
                                break;
                            case '.':
                                key = VirtualKeyShort.OEM_PERIOD;
                                break;
                            case '/':
                                key = VirtualKeyShort.OEM_2;
                                break;
                            case '\n':
                                key = VirtualKeyShort.RETURN;
                                break;
                        }

                        long lparam = 0;

                        SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYDOWN, (uint)key, lparam);
                        SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYUP, (uint)key, lparam & 0xC0000000);
                    }

                    Thread.Sleep((int)(300 * s.TimeoutFactor));
                }
                else
                {
                    SendKeyAlternative(s, keys);
                }
            }
        }

        private static void SendKeyAlternative(Screen s, string keys, bool escape = false)
        {
            if (keys != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                IntPtr curWindow = GetForegroundWindow();
                SetForegroundWindow(s.EmulatorProcess.MainWindowHandle);
                

                string[] lines = keys.Split('\n');

                bool first = true;

                foreach (string line in lines)
                {
                    if (!first)
                    {
                        //Thread.Sleep(2500);
                        System.Windows.Forms.SendKeys.SendWait("\n");
                        Thread.Sleep((int)((100 + 25 * line.Length) * s.TimeoutFactor));
                    }

                    string str = line.Replace("!", "{!}");
                    str = str.Replace("#", "{#}");
                    str = str.Replace("+", "+(=)");
                    str = str.Replace("@", "+(2)");
                    str = str.Replace("^", "{^}");

                    System.Windows.Forms.SendKeys.SendWait(str);
                    Thread.Sleep((int)((100 + 25 * line.Length) * s.TimeoutFactor));

                    first = false;
                }
                SetForegroundWindow(curWindow);
                Thread.Sleep((int)(300 * s.TimeoutFactor));
            }
        }

        private static void SendKeyRaw(Screen s, string keys, bool escape = false)
        {
            if (keys != null && s.EmulatorProcess != null && !s.EmulatorProcess.HasExited && s.ScreenState.CurrentArea != Area.Emulators.Loading)
            {
                IntPtr curWindow = GetForegroundWindow();
                SetForegroundWindow(s.EmulatorProcess.MainWindowHandle);

                //InputSimulator.SimulateTextEntry(keys);
                //System.Windows.Forms.SendKeys.Send(keys.Replace("\n", "{ENTER}"));
                
                //INPUT[] Inputs = new INPUT[(keys.Length + (escape ? 1 : 0)) * 2];
                INPUT[] Inputs = new INPUT[1];
                INPUT Input = new INPUT();
                List<INPUT> listInputs = new List<INPUT>();

                bool keyMod = false, skipChar;

                for (int i = 0; i < keys.Length * 2; i += 2)
                {
                    skipChar = false;
                    keyMod = false;

                    char c = keys[i / 2];

                    if (c > 0x30 & c <= 0x39)//numbers
                    {
                        Input.U.ki.wScan = ScanCodeShort.KEY_1 + (short)c - 0x31;
                    }
                    else
                    {
                        if ((c > 0x3d && c < 0x5b)
                            || (c > 0x20 && c < 0x27)
                            || (c > 0x27 && c < 0x2c)
                            || c == 0x3a
                            || c == 0x3c
                            )
                        {
                            keyMod = true;

                            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                            Input.type = 1;
                            Input.U.ki.wScan = (ScanCodeShort)42; //shift
                            listInputs.Add(Input);

                            if (c > 0x40 && c < 0x5b) //letter
                            {
                                c += (char)0x20;
                            }
                        }

                        switch ((short)c)
                        {
                            case 0x0a://enter
                                Input.U.ki.wScan = (ScanCodeShort)28;
                                break;
                            case 0x20://space
                                Input.U.ki.wScan = (ScanCodeShort)57;
                                break;
                            case 0x2b://plus
                                Input.U.ki.wScan = ScanCodeShort.OEM_PLUS;
                                break;
                            case 0x2d://dash
                                Input.U.ki.wScan = ScanCodeShort.OEM_MINUS;
                                break;
                            case 0x2e://dot
                                Input.U.ki.wScan = ScanCodeShort.OEM_PERIOD;
                                break;
                            case 0x30://zero
                                Input.U.ki.wScan = (ScanCodeShort)11;
                                break;
                            case 0x3a://colon
                                Input.U.ki.wScan = (ScanCodeShort)39;
                                break;
                            case 0x40://at
                                Input.U.ki.wScan = ScanCodeShort.KEY_2;
                                break;
                            case 0x5b://left bracket
                                Input.U.ki.wScan = (ScanCodeShort)26;
                                break;
                            case 0x5d://right bracket
                                Input.U.ki.wScan = (ScanCodeShort)27;
                                break;
                            case 0x61://a
                                Input.U.ki.wScan = (ScanCodeShort)30;
                                break;
                            case 0x62://b
                                Input.U.ki.wScan = (ScanCodeShort)48;
                                break;
                            case 0x63://c
                                Input.U.ki.wScan = (ScanCodeShort)46;
                                break;
                            case 0x64://d
                                Input.U.ki.wScan = (ScanCodeShort)32;
                                break;
                            case 0x65://e
                                Input.U.ki.wScan = (ScanCodeShort)18;
                                break;
                            case 0x66://f
                                Input.U.ki.wScan = (ScanCodeShort)33;
                                break;
                            case 0x67://g
                                Input.U.ki.wScan = (ScanCodeShort)34;
                                break;
                            case 0x68://h
                                Input.U.ki.wScan = (ScanCodeShort)35;
                                break;
                            case 0x69://i
                                Input.U.ki.wScan = (ScanCodeShort)23;
                                break;
                            case 0x6a://j
                                Input.U.ki.wScan = (ScanCodeShort)36;
                                break;
                            case 0x6b://k
                                Input.U.ki.wScan = (ScanCodeShort)37;
                                break;
                            case 0x6c://l
                                Input.U.ki.wScan = (ScanCodeShort)38;
                                break;
                            case 0x6d://m
                                Input.U.ki.wScan = (ScanCodeShort)50;
                                break;
                            case 0x6e://n
                                Input.U.ki.wScan = (ScanCodeShort)49;
                                break;
                            case 0x6f://o
                                Input.U.ki.wScan = (ScanCodeShort)24;
                                break;
                            case 0x70://p
                                Input.U.ki.wScan = (ScanCodeShort)25;
                                break;
                            case 0x71://q
                                Input.U.ki.wScan = (ScanCodeShort)16;
                                break;
                            case 0x72://r
                                Input.U.ki.wScan = (ScanCodeShort)19;
                                break;
                            case 0x73://s
                                Input.U.ki.wScan = (ScanCodeShort)31;
                                break;
                            case 0x74://t
                                Input.U.ki.wScan = (ScanCodeShort)20;
                                break;
                            case 0x75://u
                                Input.U.ki.wScan = (ScanCodeShort)22;
                                break;
                            case 0x76://v
                                Input.U.ki.wScan = (ScanCodeShort)47;
                                break;
                            case 0x77://w
                                Input.U.ki.wScan = (ScanCodeShort)17;
                                break;
                            case 0x78://x
                                Input.U.ki.wScan = (ScanCodeShort)45;
                                break;
                            case 0x79://y
                                Input.U.ki.wScan = (ScanCodeShort)21;
                                break;
                            case 0x7a://z
                                Input.U.ki.wScan = (ScanCodeShort)44;
                                break;
                            default:
                                skipChar = true;
                                break;
                        }
                    }

                    if (!skipChar)
                    {
                        if (keyMod)
                        {
                            listInputs.Add(Input);

                            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
                            listInputs.Add(Input);

                            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
                            Input.U.ki.wScan = (ScanCodeShort)42;
                            listInputs.Add(Input);
                        }
                        else
                        {
                            Input.type = 1; // 1 = Keyboard Input
                            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                            listInputs.Add(Input);

                            Input.type = 1; // 1 = Keyboard Input
                            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
                            listInputs.Add(Input);
                        }
                    }

                    //Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                    //Inputs[i] = Input;
                    //Input.U.ki.wScan = (ScanCodeShort)1;
                    //Input.type = 1; // 1 = Keyboard Input
                    //Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                    //Inputs[i + 1] = Input;

                    //// shift key down
                    //Input.type = 1;
                    //Input.ki.wVk = VK_LSHIFT;
                    //SendInput(1, &Input, sizeof(INPUT));

                    //// 'a' key down
                    //Input.type = 1;
                    //Input.ki.wVk = 'A';
                    //SendInput(1, &Input, sizeof(INPUT));

                    //// 'a' key release
                    //Input.type = 1;
                    //Input.ki.dwFlags = KEYEVENTF_KEYUP;
                    //Input.ki.wVk = 'A';
                    //SendInput(1, &Input, sizeof(INPUT));

                    //// shift key release
                    //Input.type = 1;
                    //Input.ki.dwFlags = KEYEVENTF_KEYUP;
                    //Input.ki.wVk = VK_LSHIFT;
                    //SendInput(1, &Input, sizeof(INPUT));
                }

                if (escape)
                {
                    Input.type = 1; // 1 = Keyboard Input
                    Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                    Input.U.ki.wScan = (ScanCodeShort)1;
                    //listInputs.Add(Input);
                    Inputs[0] = Input;
                    SendInput(1, Inputs, INPUT.Size);
                    Thread.Sleep(10);

                    Input.type = 1; // 1 = Keyboard Input
                    Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
                    //listInputs.Add(Input);
                    Inputs[0] = Input;
                    SendInput(1, Inputs, INPUT.Size);
                    Thread.Sleep(10);
                }

                //Inputs = new INPUT[listInputs.Count];

                for (int i = 0; i < listInputs.Count; i++)
                {
                    Inputs[0] = listInputs.ElementAt(i);

                    if (Inputs[0].U.ki.wScan == (ScanCodeShort)28)
                    {
                        Thread.Sleep(200);
                    }

                    SendInput(1, Inputs, INPUT.Size);
                    Thread.Sleep(25);
                }
                //SendInput(Convert.ToUInt32((listInputs.Count * 2).ToString()), Inputs, INPUT.Size);

                SetForegroundWindow(curWindow);
                Thread.Sleep((int)(300 * s.TimeoutFactor));
            }
        }

        public static void ZoomOut(Screen s)
        {
            if (s.EmulatorProcess != null)
            {
                //this.SendKey("z");
                //Thread.Sleep(500);

                SetForegroundWindow(s.EmulatorProcess.MainWindowHandle);

                INPUT[] Inputs = new INPUT[1];
                INPUT Input = new INPUT();

                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Input.type = 1;
                Input.U.ki.wScan = (ScanCodeShort)29;//Ctrl
                Inputs[0] = Input;
                SendInput(1, Inputs, INPUT.Size);

                System.Windows.Forms.Cursor.Position = new Point(s.WindowRect.left + s.WINDOW_MARGIN_L + 150, s.WindowRect.top + s.WINDOW_TITLEBAR_H + 400);
                Thread.Sleep((int)(20 * s.TimeoutFactor));
                mouse_event((uint)MOUSEEVENTF.WHEEL, (uint)(s.WindowRect.left + s.WINDOW_MARGIN_L + 150), (uint)(s.WindowRect.top + s.WINDOW_TITLEBAR_H + 400), -120, 0);
                Thread.Sleep((int)(1200 * s.TimeoutFactor));
                mouse_event((uint)MOUSEEVENTF.WHEEL, (uint)(s.WindowRect.left + s.WINDOW_MARGIN_L + 150), (uint)(s.WindowRect.top + s.WINDOW_TITLEBAR_H + 400), -120, 0);
                Thread.Sleep((int)(300 * s.TimeoutFactor));

                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
                Inputs[0] = Input;
                SendInput(1, Inputs, INPUT.Size);
            }
        }

        public void SendNotification(string message, NotificationType type)
        {
            if (Database != null && Database.Settings != null)
            {
                if (Database.Settings.PushoverAPIKey != "" && Database.Settings.PushoverUserKey != "")
                {
                    int priority = 0;
                    switch (type)
                    {
                        case NotificationType.RallyDefense:
                        case NotificationType.Offline:
                        case NotificationType.BoostActivationFail:
                        case NotificationType.IncomingRally:
                        case NotificationType.IncomingAttack:
                        case NotificationType.TasksPastDue:
                            priority = 1;
                            break;

                    }

                    PushoverClient.PushResponse response = pclient.Push("MS Alert", message, Database.Settings.PushoverUserKey, priority.ToString()); ;

                    while (response.Status != 1)
                    {
                        Thread.Sleep(1000);
                        response = pclient.Push("MS Alert", message, Database.Settings.PushoverUserKey, priority.ToString());
                    }
                }

                if (Database.Settings.SlackURL != "")
                {
                    Slack.Webhooks.SlackClient slackClient = new Slack.Webhooks.SlackClient(Database.Settings.SlackURL, 30);
                    Slack.Webhooks.SlackMessage slackMessage = new Slack.Webhooks.SlackMessage();

                    slackMessage.Channel = "#general";
                    switch (type)
                    {
                        case NotificationType.RallyDefense:
                            slackMessage.Channel = "#rallydefense";
                            break;
                        case NotificationType.RallyOffense:
                            slackMessage.Channel = "#rallyoffense";
                            break;
                    }

                    slackMessage.Username = "codestrikebot";
                    slackMessage.Text = message;

                    slackClient.Post(slackMessage);
                }
            }
        }

        public static Bitmap CaptureApplicationNew(Screen s)
        {
            Bitmap bmp = null;

            if (s.EmulatorProcess != null)
            {
                Rect rect = new Rect();

                while (!s.EmulatorProcess.HasExited && GetWindowRect(s.EmulatorProcess.MainWindowHandle, ref rect) == (IntPtr)0) { }

                //int width = rect.right - rect.left - 2+5;
                //int height = rect.bottom - rect.top - BLUESTACKS_TITLEBAR_HEIGHT - 2+5;

                bmp = new Bitmap(SCREEN_W, SCREEN_H, PixelFormat.Format16bppRgb565);

                int failure = 100;
                do
                {
                    try
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            //g.CopyFromScreen(s.procWindow.left + Screen.DROID4X_LEFTMARGIN, s.procWindow.top + Screen.DROID4X_TITLEBAR_H, 0, 0, new Size(Screen.SCREEN_W, Screen.SCREEN_H), CopyPixelOperation.SourceCopy);
                            IntPtr hdcBitmap = g.GetHdc();

                            PrintWindow(s.EmulatorProcess.MainWindowHandle, hdcBitmap, 0);

                            g.ReleaseHdc(hdcBitmap);

                            bmp.Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                        }
                        failure = 0;
                        /*bmp = Direct3DCapture.CaptureRegionDirect3D(s.proc.MainWindowHandle, new Rectangle(new Point(s.procWindow.left + Screen.DROID4X_LEFTMARGIN, s.procWindow.top + Screen.DROID4X_TITLEBAR_H), new Size(Screen.SCREEN_W, Screen.SCREEN_H)));
                        bmp.Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                        failure = 0;*/
                    }
                    //catch (ArgumentException e) { failure--; }
                    catch (System.ComponentModel.Win32Exception e)
                    {
                        failure--;
                        //UnintendedHalt = true;
                        //this.CheckPause();
                    }
                }
                while (failure > 0);
            }

            return bmp;
        }

        public static void CaptureApplication(Screen s)
        {
            if (s != null && s.EmulatorProcess != null)
            {
                Rect rect = new Rect();
                Stopwatch tmrRun = new Stopwatch();

                tmrRun.Start();

                while (tmrRun.ElapsedMilliseconds < 10000 && !s.EmulatorProcess.HasExited && GetWindowRect(s.EmulatorProcess.MainWindowHandle, ref rect) == (IntPtr)0) { }

                if (tmrRun.ElapsedMilliseconds >= 10000)
                {
                    Program.RestartApp();
                }

                int failure = 100;
                do
                {
                    try
                    {
                        using (Graphics g = Graphics.FromImage(s.SuperBitmap.Bitmap))
                        {
                            int taskbarLeftOffset = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Left;
                            int taskbarTopOffset = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Top;

                            Size sz = System.Windows.Forms.SystemInformation.BorderSize;
                            g.CopyFromScreen(s.WindowRect.left + s.WINDOW_MARGIN_L, s.WindowRect.top + s.WINDOW_TITLEBAR_H, 0, 0, new Size(SCREEN_W, SCREEN_H), CopyPixelOperation.SourceCopy);
                        }

                        s.GetScreenState();
                        failure = 0;
                    }
                    catch (ArgumentException e) { failure--; }
                    catch (System.ComponentModel.Win32Exception e)
                    {
                        failure--;
                    }
                    catch (InvalidOperationException e)
                    {
                        failure--;
                    }
                }
                while (failure > 0);
            }
        }

        public static Bitmap CaptureApplication(Screen s, int x, int y, int w, int h)
        {
            Bitmap bmp = null;

            if (s.EmulatorProcess != null)
            {
                Rect rect = new Rect();

                while (!s.EmulatorProcess.HasExited && GetWindowRect(s.EmulatorProcess.MainWindowHandle, ref rect) == (IntPtr)0) { }

                bmp = new Bitmap(w, h, PixelFormat.Format16bppRgb565);
                try
                {
                    Controller.CaptureApplication(s);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int failure = 100;
                        do
                        {
                            try
                            {
                                g.DrawImage(s.SuperBitmap.Bitmap, 0, 0, new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                                failure = 0;
                            }
                            catch (InvalidOperationException ex)
                            {
                                failure--;
                            }
                        }
                        while (failure > 0);
                    }
                }
                catch (System.ComponentModel.Win32Exception e)
                {
                    bmp.Dispose();
                }
            }

            return bmp;
        }

        public static List<Process> GetRunningEmulators()
        {
            List<Process> emulators = new List<Process>();
            foreach (Process p in Process.GetProcessesByName(LeapdroidScreen.PROCESSNAME))
            {
                emulators.Add(p);
            }
            foreach (Process p in Process.GetProcessesByName(NoxScreen.PROCESSNAME))
            {
                emulators.Add(p);
            }
            foreach (Process p in Process.GetProcessesByName(MEmuScreen.PROCESSNAME))
            {
                emulators.Add(p);
            }
            return emulators;
        }

        public void RefreshWindows()
        {
            for (int s = 0; s < sc.Length; s++)
            {
                if (sc[s] != null && sc[s].EmulatorProcess != null)
                {
                    if (sc[s].EmulatorProcess.HasExited)
                    {
                        sc[s].EmulatorProcess = null;
                    }
                    else
                    {
                        int taskbarLeftOffset = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Left;
                        int taskbarTopOffset = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Top;
                        Rect r = new Rect();
                        SetForegroundWindow(sc[s].EmulatorProcess.MainWindowHandle);
                        ShowWindow(sc[s].EmulatorProcess.MainWindowHandle, SW_RESTORE);
                        GetWindowRect(sc[s].EmulatorProcess.MainWindowHandle, ref r);
                        MoveWindow(sc[s].EmulatorProcess.MainWindowHandle, FORM_X + taskbarLeftOffset + (s * (SCREEN_W + sc[s].WINDOW_MARGIN_L + sc[s].WINDOW_MARGIN_R + 5)), FORM_Y + taskbarTopOffset, r.right - r.left, r.bottom - r.top, true);
                        Thread.Sleep(TIMEOUT_SCRCAP);
                    }
                }
            }
        }

        public void UpdateWindowInfo()
        {
            foreach (Screen s in sc)
            {
                if (s != null && s.EmulatorProcess != null)
                {
                    Rect r = s.WindowRect;
                    GetWindowRect(s.EmulatorProcess.MainWindowHandle, ref r);
                    s.WindowRect = r;
                }
            }
        }

        public static DataObjects.EmulatorInstance FindOrCreateEmulatorInstance(Process p)
        {
            EmulatorType type = EmulatorType.MEmu;
            
            switch (p.ProcessName)
            {
                case "Droid4X":
                    type = EmulatorType.Droid4X;
                    break;
                case "Nox":
                    type = EmulatorType.Nox;
                    break;
                case "LeapdroidVM":
                    type = EmulatorType.Leapdroid;
                    break;
                case "MEmu":
                    type = EmulatorType.MEmu;
                    break;
            }

            string command = p.CommandLineArgs(type);

            foreach (DataObjects.EmulatorInstance ei in Controller.Instance.emulators)
            {
                if (ei.Type == type && ei.Command == command)
                {
                    return ei;
                }
            }

            DataObjects.EmulatorInstance emulator = new DataObjects.EmulatorInstance(0, type, (p.MainWindowTitle.Contains(' ') ? p.MainWindowTitle.Substring(0, p.MainWindowTitle.IndexOf(' ')) : p.MainWindowTitle), command, new DataObjects.Account(0), new DataObjects.App(0));
            emulator.Save();

            return emulator;
        }

        public void GetAndSetEmulatorProcess(int window)
        {
            Process process = ReplaceThisPrompt.ShowDialog("Select an emulator process", "Running emulators", Controller.GetRunningEmulators());
            if (process != null)
            {
                if (sc[window] == null)
                {
                    sc[window] = Screen.CreateScreen(process);
                }
                else
                {
                    sc[window].EmulatorProcess = process;
                    sc[window].Emulator = Controller.FindOrCreateEmulatorInstance(process);
                }

                Database.Settings.Emulator1 = (sc[0] != null ? sc[0].Emulator.Id : 0);
                Database.Settings.Emulator2 = (sc[1] != null ? sc[1].Emulator.Id : 0);
                Database.Settings.Emulator3 = (sc[2] != null ? sc[2].Emulator.Id : 0);
                Database.Settings.Emulator4 = (sc[3] != null ? sc[3].Emulator.Id : 0);
                BotDatabase.SaveObject(Database.Settings);
            }
        }

        public int GetWindowWidth(IntPtr hWnd)
        {
            TITLEBARINFOEX info = GetTitleBarInfoEx(hWnd);
            return info.rcTitleBar.Height;
        }

        private TITLEBARINFOEX GetTitleBarInfoEx(IntPtr hWnd)
        {
            // Create and initialize the structure
            TITLEBARINFOEX tbi = new TITLEBARINFOEX();
            tbi.cbSize = Marshal.SizeOf(typeof(TITLEBARINFOEX));

            // Send the WM_GETTITLEBARINFOEX message
            SendMessage(hWnd, (uint)MESSAGEF.WM_GETTITLEBARINFOEX, IntPtr.Zero, ref tbi);

            // Return the filled-in structure
            return tbi;
        }

        public static KeyStateInfo GetKeyState(System.Windows.Forms.Keys key)
        {
            short keyState = GetKeyState((int)key);
            byte[] bits = BitConverter.GetBytes(keyState);
            bool toggled = bits[0] > 0, pressed = bits[1] > 0;
            return new KeyStateInfo(key, pressed, toggled);
        }

        public static void SendKeyEscape(Screen s)
        {
            if (s.EmulatorProcess != null && !s.EmulatorProcess.HasExited)
            {
                byte[] state = new byte[256];
                //state[(int)VirtualKeyShort.CONTROL] = 0xFF;
                long lparam = 0;
                lparam = lparam & (1 << 24);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYDOWN, (uint)VirtualKeyShort.LCONTROL, lparam);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYDOWN, (uint)VirtualKeyShort.ESCAPE, lparam);
                //Console.WriteLine(result.ToString());
                //Thread.Sleep(100);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYUP, (uint)VirtualKeyShort.ESCAPE, lparam & 0xC0000000);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYUP, (uint)VirtualKeyShort.LCONTROL, lparam);
            }
        }

        public static void SendKeyTest(Screen s, string keys, int offset = 0)
        {
            if (s.EmulatorProcess != null && !s.EmulatorProcess.HasExited)
            {
                byte[] state = new byte[256], state2 = new byte[256];
                //state[(int)VirtualKeyShort.CONTROL] = 0xFF;
                System.Windows.Forms.Clipboard.SetText(keys);
                long lparam = 0;
                lparam = lparam & (1 << 24);

                //AttachThreadInput((IntPtr)Thread.CurrentThread.ManagedThreadId, s.EmulatorProcess.MainWindowHandle, true);
                AttachThreadInput(Process.GetCurrentProcess().Handle, s.EmulatorProcess.MainWindowHandle, true);
                AttachThreadInput(s.EmulatorProcess.MainWindowHandle, Process.GetCurrentProcess().Handle, true);

                GetKeyboardState(state);
                state[(int)VirtualKeyShort.CONTROL] = (byte)(state[(int)VirtualKeyShort.CONTROL] | 0x80);
                SetKeyboardState(state);

                Thread.Sleep(1000);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYDOWN, (uint)VirtualKeyShort.LCONTROL, lparam);
                SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYDOWN, (uint)VirtualKeyShort.KEY_V, lparam);
                //Console.WriteLine(result.ToString());
                //Thread.Sleep(100);
                SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYUP, (uint)VirtualKeyShort.KEY_V, lparam & 0xC0000000);
                //SendMessage(s.EmulatorProcess.MainWindowHandle, (uint)MESSAGEF.WM_KEYUP, (uint)VirtualKeyShort.LCONTROL, lparam);
                GetKeyboardState(state);
                state[(int)VirtualKeyShort.CONTROL] = (byte)(state[(int)VirtualKeyShort.CONTROL] & 0x7F);
                SetKeyboardState(state);

                //AttachThreadInput((IntPtr)Thread.CurrentThread.ManagedThreadId, s.EmulatorProcess.MainWindowHandle, false);
                AttachThreadInput(Process.GetCurrentProcess().Handle, s.EmulatorProcess.MainWindowHandle, false);
                AttachThreadInput(s.EmulatorProcess.MainWindowHandle, Process.GetCurrentProcess().Handle, false);
            }
            /*INPUT[] Inputs = new INPUT[(21) * 2];
            INPUT Input = new INPUT();

            for (int i = 0; i < 10; i++ )
            {
                //char c = keys[i / 2];
                Input.U.ki.wScan = (ScanCodeShort)(i + offset);
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i*2] = Input;
                Input.U.ki.wScan = (ScanCodeShort)1;
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i*2 + 1] = Input;
            }

            Input.U.ki.wScan = (ScanCodeShort)45;
            Inputs[20] = Input;

            SendInput(Convert.ToUInt32((21 * 2).ToString()), Inputs, INPUT.Size);*/
            /*INPUT[] Inputs = new INPUT[11];
            INPUT Input = new INPUT();

            for (int i = 0; i < 10; i += 1)
            {
                Input.U.ki.wScan = (ScanCodeShort)i + 2;
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i] = Input;
            }
            Input.U.ki.wScan = (ScanCodeShort)1;
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[10] = Input;

            Thread.Sleep(TIMEOUT_KEY);
            SendInput(11, Inputs, INPUT.Size);
            Thread.Sleep(TIMEOUT_KEY);

            Inputs = new INPUT[11];
            Input = new INPUT();

            for (int i = 0; i < 10; i++)
            {
                Input.U.ki.wScan = (ScanCodeShort)i + 16;
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i] = Input;
            }
            Input.U.ki.wScan = (ScanCodeShort)1;
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[10] = Input;
            Thread.Sleep(TIMEOUT_KEY);
            SendInput(11, Inputs, INPUT.Size);
            Thread.Sleep(TIMEOUT_KEY);

            Inputs = new INPUT[10];
            Input = new INPUT();

            for (int i = 0; i < 9; i++)
            {
                Input.U.ki.wScan = (ScanCodeShort)i + 30;
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i] = Input;
            }
            Input.U.ki.wScan = (ScanCodeShort)1;
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[9] = Input;
            Thread.Sleep(TIMEOUT_KEY);
            SendInput(10, Inputs, INPUT.Size);
            Thread.Sleep(TIMEOUT_KEY);

            Inputs = new INPUT[8];
            Input = new INPUT();

            for (int i = 0; i < 7; i++)
            {
                Input.U.ki.wScan = (ScanCodeShort)i + 44;
                Input.type = 1; // 1 = Keyboard Input
                Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                Inputs[i] = Input;
            }
            Input.U.ki.wScan = (ScanCodeShort)1;
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[7] = Input;
            Thread.Sleep(TIMEOUT_KEY);
            SendInput(8, Inputs, INPUT.Size);
            Thread.Sleep(TIMEOUT_KEY);*/
        }
    }

    public struct KeyStateInfo
    {
        System.Windows.Forms.Keys _key;
        bool _isPressed,
            _isToggled;
        public KeyStateInfo(System.Windows.Forms.Keys key,
                        bool ispressed,
                        bool istoggled)
        {
            _key = key;
            _isPressed = ispressed;
            _isToggled = istoggled;
        }
        public static KeyStateInfo Default
        {
            get
            {
                return new KeyStateInfo(System.Windows.Forms.Keys.None,
                                            false,
                                            false);
            }
        }
        public System.Windows.Forms.Keys Key
        {
            get { return _key; }
        }
        public bool IsPressed
        {
            get { return _isPressed; }
        }
        public bool IsToggled
        {
            get { return _isToggled; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TITLEBARINFOEX
    {
        public int cbSize;
        public Rectangle rcTitleBar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 + 1)]
        public int[] rgstate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5 + 1)]
        public Rectangle[] rgrect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public override string ToString()
        {
            return String.Format("{{L={0}, T={1}, R={2}, B={3}}}", left, top, right, bottom);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        internal uint type;
        internal InputUnion U;
        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct InputUnion
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal MouseEventDataXButtons mouseData;
        internal MOUSEEVENTF dwFlags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }

    [Flags]
    internal enum MouseEventDataXButtons : uint
    {
        Nothing = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }

    [Flags]
    internal enum MOUSEEVENTF : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }

    internal enum MESSAGEF : uint
    {
        WM_KEYDOWN = 0x100,
        WM_KEYUP = 0x101,
        WM_MOUSEMOVE = 0x200,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_MOUSEWHEEL = 0x20a,
        WM_GETTITLEBARINFOEX = 0x33f
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        internal VirtualKeyShort wVk;
        internal ScanCodeShort wScan;
        internal KEYEVENTF dwFlags;
        internal int time;
        internal UIntPtr dwExtraInfo;
    }

    [Flags]
    internal enum KEYEVENTF : uint
    {
        EXTENDEDKEY = 0x0001,
        KEYUP = 0x0002,
        SCANCODE = 0x0008,
        UNICODE = 0x0004
    }

    internal enum VirtualKeyShort : short
    {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard) 
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key  
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key  
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key  
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key  
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key  
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key  
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key  
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key 
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
        ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved 
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }

    internal enum ScanCodeShort : short
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 1,//11
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0,

        //added
        KEY_COLON = 186
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        internal int uMsg;
        internal short wParamL;
        internal short wParamH;
    }
}
