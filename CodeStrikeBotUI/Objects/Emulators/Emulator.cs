using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;

namespace CodeStrikeBot
{
    public abstract class Screen
    {
        public static string PROCESSNAME;
        public int WINDOW_TITLEBAR_H = 0;
        public int WINDOW_MARGIN_L = 0;
        public int WINDOW_MARGIN_R = 0;

        public Process EmulatorProcess { get; set; }
        public Rect WindowRect { get; set; }
        public DataObjects.EmulatorInstance Emulator { get; set; }

        public double TimeoutFactor;
        public SuperBitmap SuperBitmap;
        public ScreenState ScreenState { get; set; }

        public bool IsFucked;
        public bool ClipboardFailed;
        public bool PreventFromOpening;
        public ushort LastChecksum { get; set; }
        public DateTime TimeSinceChecksumChanged { get; set; }
        public DateTime TimeSinceAreaChanged { get; set; }

        public bool skipMissions, skipRewards, skipVault;

        public Screen(DataObjects.EmulatorInstance emulator)
        {
            
        }

        public Screen(string windowName)
        {

        }

        public static Screen CreateScreen(DataObjects.EmulatorInstance emulator)
        {
            Screen s = null;
            switch (emulator.Type)
            {
                case EmulatorType.Droid4X:
                    s = new Droid4XScreen(emulator);
                    break;
                case EmulatorType.Nox:
                    s = new NoxScreen(emulator);
                    break;
                case EmulatorType.Leapdroid:
                    s = new LeapdroidScreen(emulator);
                    break;
                case EmulatorType.MEmu:
                    s = new MEmuScreen(emulator);
                    break;
            }

            return s;
        }

        public static Screen CreateScreen(Process process)
        {
            Screen s = null;
            switch (process.ProcessName)
            {
                case "Droid4x":
                    s = new Droid4XScreen(Controller.FindOrCreateEmulatorInstance(process));
                    break;
                case "Nox":
                    s = new NoxScreen(Controller.FindOrCreateEmulatorInstance(process));
                    break;
                case "LeapdroidVM":
                    s = new LeapdroidScreen(Controller.FindOrCreateEmulatorInstance(process));
                    break;
                case "MEmu":
                    s = new MEmuScreen(Controller.FindOrCreateEmulatorInstance(process));
                    break;
            }

            return s;
        }

        public static Screen CreateScreen(string windowName)
        {
            Screen s = null;
            //switch (emulator.Type)
            {
                //case EmulatorType.Droid4X:
                    //s = new Droid4XScreen(emulator);
                    //break;
                //case EmulatorType.Nox:
                    //s = new LeapdroidScreen(windowName);
                s = new MEmuScreen(windowName);
                    //break;
            }

            return s;
        }

        public static string ProcessNameFromType(EmulatorType type)
        {
            switch (type)
            {
                case EmulatorType.Droid4X:
                    return Droid4XScreen.PROCESSNAME;
                case EmulatorType.Leapdroid:
                    return LeapdroidScreen.PROCESSNAME;
                case EmulatorType.MEmu:
                    return MEmuScreen.PROCESSNAME;
                case EmulatorType.Nox:
                    return NoxScreen.PROCESSNAME;
                default:
                    return "";
            }
        }

        public abstract string ProcessName { get; }

        public abstract void ClickBack(int timeout = 0);

        public abstract void ClickHome(int timeout = 0);

        public abstract bool KillApp();

        public abstract bool StartApp();

        public override string ToString()
        {
            string ret = "";

            if (EmulatorProcess != null)
            {
                ret = EmulatorProcess.MainWindowTitle;
            }
            if (Emulator != null && Emulator.LastKnownAccount != null)
            {
                ret += String.Format("[{0}]", Emulator.LastKnownAccount.Name);
            }

            return ret;
        }

        public bool ClickUntil(int x, int y, ID area, int clickDelay = 0, int timeout = 60000)
        {
            bool success = false;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            do
            {
                Controller.SendClick(this, x, y, clickDelay);

                Controller.CaptureApplication(this);
            }
            while (ScreenState.CurrentArea != area && watch.ElapsedMilliseconds < timeout);

            if (ScreenState.CurrentArea == area)
            {
                success = true;
            }

            return success;
        }

        public bool ClickUntil(int x, int y, int chkX, int chkY, int chkSize, ushort chkValue, int clickDelay = 0, int timeout = 60000)
        {
            bool success = false;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            ushort chksum;

            do
            {
                Controller.SendClick(this, x, y, clickDelay);

                Controller.CaptureApplication(this);
                chksum = ScreenState.GetScreenChecksum(SuperBitmap, chkX, chkY, chkSize);
            }
            while (chksum != chkValue && watch.ElapsedMilliseconds < timeout);

            if (chksum == chkValue)
            {
                success = true;
            }

            return success;
        }

        public bool ClickUntil(int x, int y, int chkX, int chkY, Color color, int clickDelay = 0, int timeout = 60000)
        {
            bool success = false;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Color c;

            do
            {
                Controller.SendClick(this, x, y, clickDelay);

                Controller.CaptureApplication(this);
                c = SuperBitmap.GetPixel(chkX, chkY);
            }
            while (!c.Equals(color.R, color.G, color.B) && watch.ElapsedMilliseconds < timeout);

            if (c.Equals(color.R, color.G, color.B))
            {
                success = true;
            }

            return success;
        }

        public double CompareBitmaps(Bitmap b1, Bitmap b2)
        {
            double identical = 0, near = 0, drastic = 0;

            for (int x = 0; x < b1.Width; x++)
            {
                for (int y = 0; y < b1.Height; y++)
                {
                    Color c1 = b1.GetPixel(x, y), c2 = b2.GetPixel(x, y);

                    if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                    {
                        identical++;
                    }

                    if (Math.Abs(c1.R - c2.R) < 20 && Math.Abs(c1.G - c2.G) < 20 && Math.Abs(c1.B - c2.B) < 20)
                    {
                        near++;
                    }

                    if (Math.Abs(c1.R - c2.R) > 100 || Math.Abs(c1.G - c2.G) > 100 || Math.Abs(c1.B - c2.B) > 100)
                    {
                        drastic++;
                    }
                }
            }

            return ((identical + near * 2 + ((b1.Width * b1.Height - drastic) * 2)) / 5) * 100 / (b1.Width * b1.Height);
        }

        public bool CheckTextField(int x, int y)
        {
            Controller.CaptureApplication(this);

            Color c = SuperBitmap.GetPixel(x - 6, y);

            if (c.R < 127 && c.G < 127 && c.B < 127)
            {
                return true;
            }
            else
            {
                c = SuperBitmap.GetPixel(x - 4, y);

                if (c.R < 127 && c.G < 127 && c.B < 127)
                {
                    return true;
                }
                else
                {
                    c = SuperBitmap.GetPixel(x - 2, y);

                    if (c.R < 127 && c.G < 127 && c.B < 127)
                    {
                        return true;
                    }
                    else
                    {
                        c = SuperBitmap.GetPixel(x, y);

                        if (c.R < 127 && c.G < 127 && c.B < 127)
                        {
                            return true;
                        }
                        else
                        {
                            c = SuperBitmap.GetPixel(x + 2, y);

                            if (c.R < 127 && c.G < 127 && c.B < 127)
                            {
                                return true;
                            }
                            else
                            {
                                c = SuperBitmap.GetPixel(x + 4, y);

                                if (c.R < 127 && c.G < 127 && c.B < 127)
                                {
                                    return true;
                                }
                                else
                                {
                                    c = SuperBitmap.GetPixel(x + 6, y);

                                    if (c.R < 127 && c.G < 127 && c.B < 127)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        public bool CheckIfSSReady()
        {
            Controller.CaptureApplication(this);

            if (false)
            {
                SuperBitmap.Bitmap.Save(String.Format("{0}\\loading.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
            }
            //bmp = new Bitmap(String.Format("{0}\\title.bmp", Controller.Instance.GetFullScreenshotDir()));
            int count = 0;

            //check if loading
            Color c = SuperBitmap.GetPixel(14, 652);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(14, 674);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(3, 663);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(25, 663);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(5, 656);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(5, 670);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(23, 656);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            c = SuperBitmap.GetPixel(23, 670);

            if (c.R > 225 && c.G > 225 && c.B > 225)
            {
                count++;
            }

            if (count > 3)
            {
                return false;
            }

            //check notification
            c = SuperBitmap.GetPixel(8, 500);

            if (Math.Abs(c.R - c.G) + Math.Abs(c.G - c.B) < 10)
            {
                c = SuperBitmap.GetPixel(8, 523);

                if (Math.Abs(c.R - c.G) + Math.Abs(c.G - c.B) < 10)
                {
                    c = SuperBitmap.GetPixel(8, 552);

                    if (Math.Abs(c.R - c.G) + Math.Abs(c.G - c.B) < 10)
                    {
                        return false;
                    }
                }
            }

            //check state title
            c = SuperBitmap.GetPixel(51, 140);
            //107,199,222
            if (c.R > 105 && c.R < 110 && c.G > 195 && c.G < 205 && c.B > 220 && c.B < 225)
            {
                c = SuperBitmap.GetPixel(51, 200);
                //107,199,222
                if (c.R > 105 && c.R < 110 && c.G > 195 && c.G < 205 && c.B > 220 && c.B < 225)
                {
                    Thread.Sleep(5000);
                    return false;
                }
            }

            //check challenge
            c = SuperBitmap.GetPixel(38, 155);
            //189,154,33
            if (c.R > 185 && c.R < 195 && c.G > 150 && c.G < 160 && c.B > 30 && c.B < 35)
            {
                c = SuperBitmap.GetPixel(38, 195);
                //189,154,33
                if (c.R > 185 && c.R < 195 && c.G > 150 && c.G < 160 && c.B > 30 && c.B < 35)
                {
                    Thread.Sleep(4000);
                    return false;
                }
            }

            //check transport
            c = SuperBitmap.GetPixel(1, 400);

            if (c.G > 230 && c.R < 30 && c.B < 30)
            {
                Thread.Sleep(4000);
                return false;
            }

            //check attack
            c = SuperBitmap.GetPixel(1, 400);

            if (c.R > 230 && c.G < 30 && c.B < 30)
            {
                Thread.Sleep(4000);
                return false;
            }

            return true;
        }

        public Bitmap ScreenShot(string text)
        {
            Controller.CaptureApplication(this);

            if (text != "")
            {
                System.IO.Directory.CreateDirectory(Controller.Instance.GetFullScreenshotDir());

                if (text == "map")
                {
                    Controller.CaptureApplication(this, 0, 32, 394, 648).Save(String.Format("{0}\\map.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                }
                else
                {
                    SuperBitmap.Bitmap.Save(String.Format("{0}\\{1}.bmp", Controller.Instance.GetFullScreenshotDir(), text), ImageFormat.Bmp);
                }
            }

            return SuperBitmap.Bitmap;
        }

        public bool SpeedTest()
        {
            bool success = false;

            if (EmulatorProcess != null && !EmulatorProcess.HasExited)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                while (this.GoToBaseOrMapStep() && watch.ElapsedMilliseconds < 5000) { };

                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea == Area.Unknown)
                {
                    return false;
                }

                if (ScreenState.CurrentArea == Area.MainBases.Main)
                {
                    Controller.SendClick(this, 20, 680, 2000); //click on world view
                    Controller.CaptureApplication(this);
                }

                if (ScreenState.CurrentArea == Area.StateMaps.FullScreen)
                {
                    Controller.SendClick(this, 385, 10, 500); //exit fullscreen
                    Controller.CaptureApplication(this);
                }

                if (ScreenState.CurrentArea == Area.StateMaps.Main)
                {
                    Controller.SendClick(this, 10, 10, 500); //go to your base

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 32, 90, 20);

                    watch.Restart();
                    Controller.SendClick(this, 196, 382); //click on own base
                    Controller.CaptureApplication(this);

                    while (!ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.PlayerFriend) && watch.ElapsedMilliseconds < 10000)
                    {
                        Controller.CaptureApplication(this);
                    }

                    int elapsed = (int)watch.ElapsedMilliseconds;

                    if (ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.PlayerFriend))
                    {
                        TimeoutFactor = Math.Max(1.001, (double)watch.ElapsedMilliseconds / 400);

                        //TODO Slow mode
                        if (TimeoutFactor != 5.0)
                        {
                            success = true;
                        }
                    }
                }
            }
            
            return success;
        }

        public bool CheckPause()
        {
            //int key = 25;
            /*System.Windows.Forms.Keys key = System.Windows.Forms.Keys.P;
            KeyStateInfo keyState = Screen.GetKeyState(key);

            if (keyState.IsPressed)
            {
                do
                {
                    Thread.Sleep(1000);
                    keyState = Screen.GetKeyState(System.Windows.Forms.Keys.R);
                }
                while (!keyState.IsPressed);
            }*/

            /*if (false)
            {
                while (false)
                {
                    Thread.Sleep(1000);
                }
            }
            else if (UnintendedHalt)
            {

                    //System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("The process has paused. Do you wish to continue?", "Process Paused", System.Windows.Forms.MessageBoxButtons.YesNo);

                    //if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        UnintendedHalt = false;
                    }
                    //else
                    {
                        //cancel
                        //return false;
                    }
            }*/

            return true;
        }

        public bool Logout()
        {
            bool success = true;
            //TODO: Only return success if it truly logs out

            Stopwatch tmrRun = new Stopwatch();

            if (EmulatorProcess != null)
            {
                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea != Area.Emulators.Android && ScreenState.CurrentArea != Area.Others.Login)
                {
                    tmrRun.Start();
                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 350, 655, 10);

                    //while ((chksum != 0x56c9 && chksum != 0xa0ba && chksum != 0x1ae8) && tmrRun.ElapsedMilliseconds < 5000) //DIFF MS
                    while (chksum != 0x4fba && tmrRun.ElapsedMilliseconds < 5000) //DIFF FF
                    {
                        if (ScreenState.CurrentArea == Area.Others.Splash)
                        {
                            break;
                        }

                        this.ClickBack(350);
                        Controller.CaptureApplication(this);
                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 350, 655, 10);
                    }

                    //if (chksum == 0x56c9 || chksum == 0xa0ba) //DIFF MS
                    if (chksum == 0x4fba) //DIFF FF
                    {
                        tmrRun.Restart();

                        do
                        {
                            Controller.SendClick(this, 360, 680, 500); //click More
                            Controller.CaptureApplication(this);
                        }
                        while (ScreenState.CurrentArea != Area.Menus.More && tmrRun.ElapsedMilliseconds < 3000);

                        if (tmrRun.ElapsedMilliseconds > 3000 && ScreenState.CurrentArea == Area.Unknown)
                        {
                            //TODO: Revisit why this is Unknown, screenshot, probably loading More menu
                            if (!KillApp())
                            {
                                Controller.Instance.RestartEmulator(this);
                            }
                            return false;
                        }
                        else
                        {
                            tmrRun.Restart();

                            do
                            {
                                //Controller.SendClick(this, 245, 200, 300); //click EW //DIFF MS
                                Controller.SendClick(this, 335, 200, 300); //click EW //DIFF FF
                                Controller.CaptureApplication(this);
                            }
                            while (ScreenState.CurrentArea != Area.Menus.Account && tmrRun.ElapsedMilliseconds < 3000);

                            if (ScreenState.CurrentArea == Area.Menus.Account)
                            {
                                while (ScreenState.Overlays.Contains(Overlay.Statuses.Loading))
                                {
                                    Thread.Sleep(50);
                                }

                                tmrRun.Restart();

                                Color c = new Color();
                                do
                                {
                                    Controller.SendClick(this, 200, 555, 300); //click Logout
                                    Controller.CaptureApplication(this);
                                    c = SuperBitmap.GetPixel(110, 555);
                                }
                                while (c.Equals(189, 40, 41) && tmrRun.ElapsedMilliseconds < 5000);

                                if (!c.Equals(189, 40, 41))
                                {
                                    tmrRun.Restart();

                                    do
                                    {
                                        Controller.SendClick(this, 120, 265); //click Yes
                                        Controller.CaptureApplication(this);
                                        c = SuperBitmap.GetPixel(60, 265);
                                    }
                                    while (c.Equals(0, 101, 214) && tmrRun.ElapsedMilliseconds < 3000);

                                    if (!c.Equals(0, 101, 214))
                                    {
                                        tmrRun.Restart();

                                        do
                                        {
                                            Thread.Sleep(500);
                                            Controller.CaptureApplication(this);
                                        }
                                        while (ScreenState.CurrentArea != Area.Emulators.Android && tmrRun.ElapsedMilliseconds < 5000);
                                    }
                                    else
                                    {
                                        success = false;
                                    }
                                }
                                else
                                {
                                    success = false;
                                }
                            }
                            else
                            {
                                success = false;
                            }
                        }
                    }
                    else if (chksum == 0x1ae8) //TODO: Figure out what this case means
                    {
                        if (!KillApp())
                        {
                            Controller.Instance.RestartEmulator(this);
                        }
                        success = false;
                    }
                    else if (ScreenState.CurrentArea != Area.Others.Splash)
                    {
                        success = false;
                    }

                    tmrRun.Stop();
                }
            }

            if (success)
            {
                Emulator.LastKnownAccount = null;
            }

            return success;
        }

        public bool Login(DataObjects.Account account)
        {
            bool success = false;

            Stopwatch tmrRun = new Stopwatch();

            tmrRun.Start();

            if (account.Email == null)
            {
                account = null;
            }

            if (EmulatorProcess != null && account != null)
            {
                Controller.CaptureApplication(this);

                int tries = 0;

                while (ScreenState.CurrentArea == Area.Others.Login && tries < 6)
                {
                    Controller.CaptureApplication(this);

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 88, 216, 20);//DIFF ff
                    if (chksum != 0x5921) //nox, if email has been previously entered
                    {
                        while (!KillApp()) { }
                        {
                            //Controller.Instance.RestartEmulator(this);
                        }
                        Thread.Sleep(500);
                        this.StartApp();
                    }

                    chksum = ScreenState.GetScreenChecksum(SuperBitmap, 88, 263, 20);//DIFF ff
                    if (chksum != 0x5921) //nox, if password has been previously entered
                    {
                        while (!KillApp()) { }
                        {
                            //Controller.Instance.RestartEmulator(this);
                        }
                        Thread.Sleep(500);
                        this.StartApp();
                    }

                    tmrRun.Restart();
                    
                    //enter email
                    do
                    {
                        Controller.SendClick(this, 300, 226, (int)(300 * (tries / 2.0 + 1)));//DIFF ff
                        Controller.SendKey(this, account.Email);
                        Thread.Sleep((int)((500 * (tries / 2.0 + 1)) * TimeoutFactor));
                        Controller.CaptureApplication(this);
                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 82, 216, 20);//DIFF ff
                    }
                    while ((chksum == 0xe182 || chksum == 0x55ac) && tmrRun.ElapsedMilliseconds < 50000);//DIFF ff
                    
                    tmrRun.Restart();

                    //enter password
                    do
                    {
                        Controller.SendClick(this, 300, 273, (int)(600 * (tries / 2.0 + 1)));//DIFF ff
                        Controller.SendKey(this, account.Password);
                        Thread.Sleep((int)((500 * (tries / 2.0 + 1)) * TimeoutFactor));
                        Controller.CaptureApplication(this);
                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 82, 263, 20);//DIFF ff
                    }
                    while ((chksum == 0xe182 || chksum == 0x55ac) && tmrRun.ElapsedMilliseconds < 50000);//DIFF ff

                    Controller.CaptureApplication(this);
                    chksum = ScreenState.GetScreenChecksum(SuperBitmap, 188, 304, 20);
                    if (chksum == 0x673b) //DIFF ff login gray
                    {
                        //backspace fields
                        /*this.SendClick(310, 260, 250);
                        this.SendKey(new String('\b', account.Email.Length));

                        this.SendClick(310, 305, 250);
                        this.SendKey(new String('\b', account.Password.Length));
                        */
                        while (!KillApp()) { }
                        {
                            //Controller.Instance.RestartEmulator(this);
                        }
                        this.StartApp();
                    }
                    else
                    {
                        do
                        {
                            Controller.SendClick(this, 100, 325, 100); //click Login
                            Controller.CaptureApplication(this);
                            chksum = ScreenState.GetScreenChecksum(SuperBitmap, 188, 304, 20);
                        }
                        while (chksum == 0x9dc3);

                        Thread.Sleep(300);
                        Controller.CaptureApplication(this);

                        tmrRun.Restart();

                        success = true;

                        while (success && ScreenState.CurrentArea == Area.Others.Login && tmrRun.ElapsedMilliseconds < 30000)
                        {
                            //chksum = ScreenState.GetScreenChecksum(SuperBitmap, 190, 116, 20);
                            //SuperBitmap.Bitmap.Save(String.Format("{0}\\login.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);

                            if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.LoginFailed))
                            {
                                if (!KillApp())
                                {
                                    Controller.Instance.RestartEmulator(this);
                                }
                                this.StartApp();

                                success = false;
                            }
                            /*switch (chksum)
                            {
                                case 0x16d1: //loading/wait
                                    success = true;
                                    break;
                            }*/
                           
                            System.Windows.Forms.Application.DoEvents();

                            //TODO Slow mode
                            //TimeoutFactor = 5.0;
                            TimeoutFactor = 1.0;

                            Thread.Sleep((int)(500));
                            Controller.CaptureApplication(this);
                        }

                        if (tmrRun.ElapsedMilliseconds > 30000)
                        {
                            success = false;
                        }
                    }

                    Controller.CaptureApplication(this);

                    System.Windows.Forms.Application.DoEvents();

                    tries++;
                }

                tmrRun.Restart();

                //wait for ad
                while (CheckPause() && ScreenState.CurrentArea != Area.Others.Ad && tmrRun.ElapsedMilliseconds < 20000)
                {
                    Thread.Sleep(100);

                    Controller.CaptureApplication(this);
                }

                if (tmrRun.ElapsedMilliseconds < 20000)
                {
                    Controller.SendClick(this, 390, 10, 200); //exit ad
                }
                else
                {
                    this.ClickBack(200); //click back
                }

                tmrRun.Stop();
            }

            return success;
        }

        public bool GoToCoordinate(System.Web.UI.DataVisualization.Charting.Point3D coord)
        {
            return GoToCoordinate((int)coord.X, (int)coord.Y);
        }

        public bool GoToCoordinate(int x, int y)
        {
            bool success = false;
            int retryCount = 0;

            Stopwatch tmrRun = new Stopwatch();
            tmrRun.Start();

            while (this.GoToBaseOrMapStep() && tmrRun.ElapsedMilliseconds < 3000) { };

            Controller.CaptureApplication(this);

            if (ScreenState.CurrentArea == Area.Unknown)
            {
                IsFucked = true;
                return false;
            }

            tmrRun.Restart();

            while (ScreenState.CurrentArea == Area.MainBases.Main && tmrRun.ElapsedMilliseconds < 2600)
            {
                Controller.SendClick(this, 20, 680, 1200);
                Controller.CaptureApplication(this);
            }

            if (ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.StateMaps.FullScreen)
            {
                do
                {
                    do
                    {
                        Controller.SendClick(this, 117, 18, (int)(150 * (retryCount / 2.0 + 1))); //click magnify glass
                        Controller.CaptureApplication(this);
                    }
                    while (ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.StateMaps.FullScreen);

                    System.Windows.Forms.Application.DoEvents();

                    if (ScreenState.CurrentArea == Area.StateMaps.Coordinate)
                    {
                        ushort chksum;
                        tmrRun.Start();

                        do
                        {
                            Controller.SendClick(this, 182, 194, (int)(225 * (retryCount / 2.0 + 1))); //click X
                            Controller.SendKey(this, x.ToString());
                            Thread.Sleep((int)((180 + x.ToString().Length * 80) * TimeoutFactor * (retryCount / 2.0 + 1)));

                            Controller.CaptureApplication(this);
                            chksum = ScreenState.GetScreenChecksum(this.SuperBitmap, 118, 184, 10);
                        }
                        while (chksum == 0xfde4 && tmrRun.ElapsedMilliseconds < 5000);

                        System.Windows.Forms.Application.DoEvents();
                        tmrRun.Restart();

                        do
                        {
                            Controller.SendClick(this, 298, 194, (int)(225 * (retryCount / 2.0 + 1))); //click Y
                            Controller.SendKey(this, y.ToString());
                            Thread.Sleep((int)((180 + y.ToString().Length * 80) * TimeoutFactor * (retryCount / 2.0 + 1)));

                            Controller.CaptureApplication(this);
                            chksum = ScreenState.GetScreenChecksum(this.SuperBitmap, 230, 184, 10);
                        }
                        while (chksum == 0xfde4 && tmrRun.ElapsedMilliseconds < 5000);

                        System.Windows.Forms.Application.DoEvents();

                        do
                        {
                            Thread.Sleep((int)((180 + y.ToString().Length * 80) * TimeoutFactor * (retryCount / 2.0 + 1)));
                            Controller.SendClick(this, 278, 250, (int)(450 * (retryCount / 2.0 + 1))); //click Go to

                            Controller.CaptureApplication(this);
                        }
                        while (ScreenState.CurrentArea == Area.StateMaps.Coordinate);

                        System.Windows.Forms.Application.DoEvents();
                        chksum = ScreenState.GetScreenChecksum(this.SuperBitmap, 230, 184, 10);

                        if (ScreenState.CurrentArea == Area.StateMaps.CoordinateError)
                        {
                            Controller.SendClick(this, 112, 264, (int)(300 * (retryCount / 2.0 + 1))); //click Cancel
                            retryCount++;
                        }
                        else
                        {
                            retryCount = 0;
                            success = true;
                        }
                    }
                    else
                    {
                        retryCount = 0;
                    }
                }
                while (retryCount > 0);
            }

            return success;
        }

        public void SendChat(string message, int chatroom = 2)
        {
            if (EmulatorProcess != null)
            {
                while (this.GoToBaseOrMapStep()) { };

                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.MainBases.Main)
                {
                    Controller.SendClick(this, 150, 610, 800); //click chat bar
                    Controller.SendClick(this, 130 + chatroom * 85, 20, 700); //click room
                    Controller.SendClick(this, 133, 682, 250); //click chat text
                    Controller.SendKey(this, message);
                    //Controller.SendClick(350, 200); //click out
                    //System.Threading.Thread.Sleep(300);
                    Controller.SendClick(this, 350, 674, 400); //click send
                    Controller.SendClick(this, 375, 20, 150); //click exit chat
                }
            }
        }

        public void SearchEnemies(int startAtX, int startAtY)
        {
            try
            {
                //this.CaptureApplication().Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);

                do
                {
                    Thread.Sleep(500);

                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea != Area.StateMaps.Main && ScreenState.CurrentArea != Area.StateMaps.FullScreen);

                while (ScreenState.CurrentArea != Area.StateMaps.FullScreen)
                {
                    Controller.SendClick(this, 370, 15, 300);

                    Controller.CaptureApplication(this);
                }

                Controller.ZoomOut(this);

                bool canBegin = false;

                for (int y = 9; y < 1015; y += 20)
                {
                    for (int x = 2; x < 510; x += 6)
                    {
                        if (!canBegin && x >= startAtX && y >= startAtY)
                        {
                            canBegin = true;
                        }

                        if (canBegin)
                        {
                            if (this.CheckPause())
                            {
                                if (GoToCoordinate(x, y))
                                {
                                    while (!this.CheckIfSSReady()) { }

                                    {
                                        Bitmap bmp = new Bitmap(1, 1), bmp2 = new Bitmap(1, 1);

                                        do
                                        {
                                            bmp.Dispose();
                                            bmp2.Dispose();

                                            Controller.CaptureApplication(this);
                                            bmp = new Bitmap(SuperBitmap.Bitmap);

                                            Thread.Sleep(200);

                                            Controller.CaptureApplication(this);
                                            bmp2 = new Bitmap(SuperBitmap.Bitmap);
                                        }
                                        while (this.CompareBitmaps(bmp, bmp2) < 94);

                                        bmp.Dispose();
                                        bmp2.Dispose();
                                    }

                                    int enemyCount = 0;

                                    for (int line = 0; line <= 18; line++)
                                    {
                                        SuperBitmap.Bitmap.Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                                        int firstX = 0, lastX = 0;
                                        int pY = Convert.ToInt32(line * 33.35 + 77);

                                        for (int pX = 5; pX < 390; pX++)
                                        {
                                            Color c = SuperBitmap.GetPixel(pX, pY);

                                            if (c.R > 195 && c.G < 45 && c.B < 45)
                                            {
                                                if (firstX == 0)
                                                {
                                                    firstX = pX;
                                                }

                                                lastX = pX;
                                            }

                                            if (lastX > 0 && pX - lastX > 10 && lastX - firstX > 40)
                                            {
                                                enemyCount++;
                                                firstX = 0;
                                                lastX = 0;
                                            }
                                        }
                                    }

                                    if (enemyCount > 0)
                                    {
                                        Controller.SendClick(this, 375, 20, 150); //click exit fullscreen

                                        this.SendChat(String.Format("{0} enemies at 96:{1}:{2}", enemyCount, x, y));

                                        Controller.SendClick(this, 375, 20); //click fullscreen

                                        enemyCount = 0;
                                    }
                                }
                                else
                                {
                                    x--;
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Thread.Sleep(20000);
            }
        }

        public void Map(int sXStartAt, int sYStartAt, int rowStartAt, int colStartAt)
        {
            if (EmulatorProcess != null)
            {
                Controller.CaptureApplication(this);
                //SuperBitmap.Bitmap.Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                
                while (this.GoToBaseOrMapStep())
                {
                    Thread.Sleep(300);
                    Controller.CaptureApplication(this);
                }

                while (ScreenState.CurrentArea != Area.StateMaps.Main && ScreenState.CurrentArea != Area.StateMaps.FullScreen)
                {
                    Controller.SendClick(this, 30, 675, 300);
                    Controller.CaptureApplication(this);
                }

                while (ScreenState.CurrentArea != Area.StateMaps.FullScreen)
                {
                    Controller.SendClick(this, 370, 15, 300);
                    Controller.CaptureApplication(this);
                }

                //Controller.ZoomOut(this); //DIFF MS
                System.Windows.Forms.Application.DoEvents();

                int numX = 102, numY = 54;//102/54
                int numSlicesX = 3, numSlicesY = 3;

                bool canBegin = false;

                for (int sY = 0; sY < numSlicesY; sY++)
                {
                    for (int sX = 0; sX < numSlicesX; sX++) //sX and sY determine the current slice
                    {
                        if (sY == sYStartAt && sX == sXStartAt)
                        {
                            canBegin = true;
                        }

                        if (canBegin)
                        {
                            //new slice
                            string filename = "worldmap";

                            if (sX == 1 && sY == 1)
                            {
                                filename += "C";
                            }
                            else
                            {
                                switch (sY)
                                {
                                    case 0:
                                        filename += "N";
                                        break;
                                    case 2:
                                        filename += "S";
                                        break;
                                }

                                switch (sX)
                                {
                                    case 0:
                                        filename += "W";
                                        break;
                                    case 2:
                                        filename += "E";
                                        break;
                                }
                            }

                            Bitmap worldMap;

                            if (System.IO.File.Exists(String.Format("{0}\\{1}.jpg", Controller.Instance.GetFullScreenshotDir(), filename)))
                            {
                                worldMap = this.LoadBitmapUnlocked(String.Format("{0}\\{1}.jpg", Controller.Instance.GetFullScreenshotDir(), filename));
                            }
                            else
                            {
                                worldMap = new Bitmap(334 * (numX / numSlicesX - 1) + 461, 636 * (numY / numSlicesY - 1) + 682, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
                            }

                            for (int y = (sY == sYStartAt && sX == sXStartAt ? rowStartAt : 0); y < numY / numSlicesY; y++)
                            {
                                using (Graphics graphics = Graphics.FromImage(worldMap))
                                {
                                    for (int x = (sY == sYStartAt && sX == sXStartAt && y == rowStartAt ? colStartAt : 0); x < numX / numSlicesX; x++) //x and y determine which screenshot within a slice
                                    {
                                        if (this.CheckPause())
                                        {
                                            int newX = x + sX * (numX / numSlicesX), newY = y + sY * (numY / numSlicesY); //newX and newY determine which screenshot relative to the whole

                                            int wX = newX * 5 + 3 - (newY % 2), wY = newY * 19 + 9 - (newX % 2); //wX and wY determine the coordinates within the game map

                                            System.Windows.Forms.Application.DoEvents();

                                            if (this.GoToCoordinate(wX, wY))
                                            {
                                                Stopwatch tmrContinue = new Stopwatch();
                                                tmrContinue.Start();

                                                while (!this.CheckIfSSReady() && tmrContinue.ElapsedMilliseconds < 8000) { }

                                                tmrContinue.Restart();

                                                Bitmap bmp, bmp2;
                                                do
                                                {
                                                    bmp = Controller.CaptureApplication(this, 0, 32, 394, 648);
                                                    Thread.Sleep(200);
                                                    bmp2 = Controller.CaptureApplication(this, 0, 32, 394, 648);

                                                    if (this.CompareBitmaps(bmp, bmp2) < 94)
                                                    {
                                                        bmp.Save(String.Format("{0}\\pic1.jpg", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Jpeg);
                                                        bmp2.Save(String.Format("{0}\\pic2.jpg", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Jpeg);
                                                    }
                                                }
                                                while (this.CompareBitmaps(bmp, bmp2) < 94 && tmrContinue.ElapsedMilliseconds < 2500);
                                                
                                                tmrContinue.Stop();

                                                if (ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.Rebel))
                                                {
                                                    this.ClickBack(300);
                                                    Controller.CaptureApplication(this);

                                                    while (ScreenState.CurrentArea != Area.StateMaps.Main)
                                                    {
                                                        Controller.SendClick(this, 370, 15, 300);
                                                        Controller.CaptureApplication(this);
                                                    }

                                                    while (ScreenState.CurrentArea != Area.StateMaps.FullScreen)
                                                    {
                                                        Controller.SendClick(this, 370, 15, 300);
                                                        Controller.CaptureApplication(this);
                                                    }

                                                    x--;
                                                }
                                                else if (ScreenState.CurrentArea == Area.StateMaps.Coordinate
                                                    || ScreenState.CurrentArea == Area.StateMaps.CoordinateError
                                                    || ScreenState.Overlays.Count > 0)
                                                {
                                                    this.ClickBack(300);
                                                    x--;
                                                }
                                                else if (ScreenState.CurrentArea == Area.StateMaps.FullScreen)
                                                {
                                                    //graphics.DrawImage(bmp, x * 334 - ((y % 2) * 67) + 67, y * 636 - ((x % 2) * 34) + 34, bmp.Width, bmp.Height);
                                                    graphics.DrawImage(bmp2, ((wX - 2) % (512 / numSlicesX)) * 467 / 7, ((wY - 8) % (1024 / numSlicesY)) * 601 / 18, bmp2.Width, bmp2.Height);
                                                }
                                                else
                                                {
                                                    bmp2.Save(String.Format("{0}\\file.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp);
                                                    SuperBitmap.Bitmap.Save(String.Format("{0}\\file2.bmp", Controller.Instance.GetFullScreenshotDir()), ImageFormat.Bmp); 
                                                    
                                                    Main.CurrentForm.SetLastMapParameters(sX, sY, y, x);

                                                    int minY = Math.Max((y + sY * (numY / numSlicesY)) * 19 + 9 - 11, 0), maxY = minY + 20;
                                                    int gridY = maxY / 25 * 25;

                                                    if (gridY > minY)
                                                    {
                                                        graphics.DrawLine(new Pen(Color.Black, (gridY % 100 == 0 ? 5 : 1)), new Point(0, ((gridY - 10) % (1024 / numSlicesY)) * 602 / 18 + 384), new Point(334 * (numX / numSlicesX - 1) + 461, ((gridY - 10) % (1024 / numSlicesY)) * 602 / 18 + 384));
                                                    }

                                                    for (int gridX = Math.Max((sX * (numX / numSlicesX)) * 5 / 25 * 25, 25); gridX < ((sX + 1) * (numX / numSlicesX)) * 5 + 3; gridX += 25)
                                                    {
                                                        graphics.DrawLine(new Pen(Color.Black, (gridX % 100 == 0 ? 5 : 1)), new Point(gridX * 1665 / 25 + 65, (((y + sY * (numY / numSlicesY)) * 19) % (1024 / numSlicesY)) * 602 / 18), new Point(gridX * 1665 / 25 + 65, (((y + sY * (numY / numSlicesY)) * 19) % (1024 / numSlicesY)) * 602 / 18 + 682));
                                                    }

                                                    worldMap.Save(String.Format("{0}\\{1}.jpg", Controller.Instance.GetFullScreenshotDir(), filename), ImageFormat.Jpeg);

                                                    while (ScreenState.CurrentArea == Area.Unknown)
                                                    {
                                                        ClickBack();
                                                        Thread.Sleep(300);
                                                    }
                                                    
                                                    Map(sX, sY, y, x);
                                                    
                                                    return;
                                                }

                                                bmp.Dispose();
                                                bmp2.Dispose();
                                            }
                                            else
                                            {
                                                x--;
                                            }
                                        }
                                    }

                                    //draw grid lines
                                    if (CheckPause())
                                    {
                                        int minY = Math.Max((y + sY * (numY / numSlicesY)) * 19 + 9 - 11, 0), maxY = minY + 20;
                                        int gridY = maxY / 25 * 25;

                                        if (gridY > minY)
                                        {
                                            graphics.DrawLine(new Pen(Color.Black, (gridY % 100 == 0 ? 5 : 1)), new Point(0, ((gridY - 10) % (1024 / numSlicesY)) * 602 / 18 + 384), new Point(334 * (numX / numSlicesX - 1) + 461, ((gridY - 10) % (1024 / numSlicesY)) * 602 / 18 + 384));
                                        }

                                        for (int gridX = Math.Max((sX * (numX / numSlicesX)) * 5 / 25 * 25, 25); gridX < ((sX + 1) * (numX / numSlicesX)) * 5 + 3; gridX += 25)
                                        {
                                            graphics.DrawLine(new Pen(Color.Black, (gridX % 100 == 0 ? 5 : 1)), new Point(gridX * 1665 / 25 + 65, (((y + sY * (numY / numSlicesY)) * 19) % (1024 / numSlicesY)) * 602 / 18), new Point(gridX * 1665 / 25 + 65, (((y + sY * (numY / numSlicesY)) * 19) % (1024 / numSlicesY)) * 602 / 18 + 682));
                                        }

                                        worldMap.Save(String.Format("{0}\\{1}.jpg", Controller.Instance.GetFullScreenshotDir(), filename), ImageFormat.Jpeg);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GrowXP()
        {
            int lotX = 40, lotY = 225;
            //int lotX = 85, lotY = 263;
            int desiredLevel = 2;

            Color c;

            while (this.GoToBaseOrMapStep())
            {
                Thread.Sleep(300);
                Controller.CaptureApplication(this);
            }

            while (ScreenState.CurrentArea != Area.MainBases.Main)
            {
                Controller.SendClick(this, 30, 675, 300);
                Controller.CaptureApplication(this);
            }

            //TODO: Fix click and drag, but assume starting at main base in the lower right corner
            ushort chksum = ScreenState.GetScreenChecksum(this.SuperBitmap, 330, 65, 20), finalChksum;
            /*do
            {
                Controller.SendClickDrag(this, 315, 480, 25, 355, 100, false, 1200);
                //Controller.SendClickDrag(this, 315, 480, 25, 355, 1000, false, 2000);
                Controller.CaptureApplication(this);
            }
            while (chksum != ScreenState.GetScreenChecksum(this.SuperBitmap, 330, 65, 20));*/

            finalChksum = chksum;

            while (CheckPause() && chksum == finalChksum)
            {
                //if base screen, click empty lot
                do
                {
                    Controller.SendClick(this, lotX, lotY, 1000);
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea != Area.Menus.BuildingList);

                //click Farm
                do
                {
                    Controller.SendClick(this, 60, 210, 500);
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea != Area.Menus.Buildings.Farm);

                //click Build
                do
                {
                    Controller.SendClick(this, 237, 145, 280);
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea != Area.MainBases.Main && ScreenState.CurrentArea != Area.Menus.Resources);

                if (ScreenState.CurrentArea == Area.Menus.Resources)
                {
                    ClickBack(300);
                    ClickBack(300);
                    ClickBack(300);
                    return;
                }

                Thread.Sleep(800);
                Controller.CaptureApplication(this);
                c = SuperBitmap.GetPixel(235, 82);

                while (!c.Within(185, 95, 33, 10))
                {
                    Thread.Sleep(50);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                //click Free
                while (c.Within(185, 95, 33, 10))
                {
                    Controller.SendClick(this, 235, 82, 280);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                while (c.Within(82, 81, 82, 3) || c.Within(185, 95, 33, 10))
                {
                    Thread.Sleep(50);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                for (int i = 0; i < desiredLevel - 1; i++)
                {
                    //double click Farm
                    do
                    {
                        Controller.SendClick(this, lotX, lotY, 80);
                        Controller.SendClick(this, lotX, lotY, 500);
                        Controller.CaptureApplication(this);
                    }
                    while (ScreenState.CurrentArea != Area.Menus.Buildings.Farm && ScreenState.CurrentArea != Area.Menus.BuildingList);

                    //click Upgrade if necessary
                    while (ScreenState.CurrentArea == Area.Menus.Buildings.Farm)
                    {
                        Controller.SendClick(this, 237, 145, 280);
                        Controller.CaptureApplication(this);
                    }

                    //click Upgrade
                    do
                    {
                        Controller.SendClick(this, 237, 145, 280);
                        Controller.CaptureApplication(this);
                    }
                    while (ScreenState.CurrentArea != Area.MainBases.Main && ScreenState.CurrentArea != Area.Menus.Resources);

                    if (ScreenState.CurrentArea == Area.Menus.Resources)
                    {
                        ClickBack(300);
                        ClickBack(300);
                        return;
                    }

                    Thread.Sleep(800);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(245, 90);

                    c = SuperBitmap.GetPixel(235, 82);

                    while (!c.Within(185, 95, 33, 10))
                    {
                        Thread.Sleep(50);
                        Controller.CaptureApplication(this);
                        c = SuperBitmap.GetPixel(235, 82);
                    }

                    //click Free
                    while (c.Within(185, 95, 33, 10))
                    {
                        Controller.SendClick(this, 235, 82, 1280);
                        Controller.CaptureApplication(this);
                        c = SuperBitmap.GetPixel(235, 82);
                    }

                    while (c.Within(82, 81, 82, 3) || c.Within(185, 95, 33, 10))
                    {
                        Thread.Sleep(50);
                        Controller.CaptureApplication(this);
                        c = SuperBitmap.GetPixel(235, 82);
                    }
                }

                //click completed Farm
                do
                {
                    Controller.SendClick(this, lotX, lotY, 500);
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea != Area.Menus.Buildings.Farm);

                //click Demolish
                do
                {
                    Controller.SendClick(this, 80, 160, 280);
                    Controller.CaptureApplication(this);
                }
                while (!ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.DemolishBuilding));

                //click Use
                do
                {
                    Controller.SendClick(this, 225, 315, 280);
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.DemolishBuilding));

                //click Yes
                do
                {
                    Controller.SendClick(this, 225, 280, 280);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(245, 90);
                }
                while (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.AreYouSure));

                Thread.Sleep(800);
                Controller.CaptureApplication(this);
                c = SuperBitmap.GetPixel(245, 90);

                while (!c.Within(185, 95, 33, 10))
                {
                    Thread.Sleep(50);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                //click Free
                while (c.Within(185, 95, 33, 10))
                {
                    Controller.SendClick(this, 235, 82, 280);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                while (c.Within(82, 81, 82, 3) || c.Within(185, 95, 33, 10))
                {
                    Thread.Sleep(50);
                    Controller.CaptureApplication(this);
                    c = SuperBitmap.GetPixel(235, 82);
                }

                Thread.Sleep(1500);

                chksum = ScreenState.GetScreenChecksum(this.SuperBitmap, 330, 65, 20);
            }
        }

        public bool CollectGiftsStep()
        {
            bool giftsLeft = false;

            if (EmulatorProcess != null && !EmulatorProcess.HasExited)
            {
                Controller.CaptureApplication(this);

                if (ScreenState.Overlays.Contains(Overlay.Widgets.AllianceGift))
                {
                    giftsLeft = true;

                    Color c = SuperBitmap.GetPixel(335, 175);

                    if (ScreenState.CurrentArea == Area.Menus.Alliance)
                    {
                        Controller.SendClick(this, 321, 198, 600); //click gifts
                    }
                    else if (ScreenState.CurrentArea == Area.Menus.Gifts && c.Equals(57, 121, 140)) //clear gifts button is available
                    {
                        c = SuperBitmap.GetPixel(200, 175);

                        if (c.Equals(33, 40, 49)) //open 50/All
                        {
                            Controller.SendClick(this, 100, 183, 3000); //click Open 50/All

                            Controller.SendClick(this, 350, 190, 100); //click X
                        }
                        else
                        {
                            for (int p = 217; p < 586; p++)
                            {
                                c = SuperBitmap.GetPixel(335, p);

                                if (c.Equals(90, 89, 90))
                                {
                                    //loading
                                    Thread.Sleep((int)(100 * TimeoutFactor));
                                    p = 586;
                                }
                                else if (c.Equals(57, 121, 140))
                                {
                                    //open
                                    Controller.SendClick(this, 335, p, 100);
                                    p = 586;
                                }
                                else if (c.Equals(206, 56, 57))
                                {
                                    //clear
                                }
                                else if (p == 585)
                                {
                                    Controller.SendClick(this, 335, 183, 100); //click Clear all
                                }
                            }
                        }
                    }
                    else
                    {
                        Controller.SendClick(this, 230, 675, 700); //click alliance
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.Alliance || ScreenState.CurrentArea == Area.Menus.Gifts)
                {
                    SuperBitmap.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);

                    if (ScreenState.CurrentArea == Area.Menus.Gifts && SuperBitmap.GetPixel(335, 175).Equals(57, 121, 140)) //clear gifts button is available
                    {
                        giftsLeft = true;

                        Controller.SendClick(this, 335, 183, 100); //click Clear all
                    }
                    else
                    {
                        Controller.SendClick(this, 15, 685, 500); //click Base
                    }
                }
            }

            return giftsLeft;
        }

        public bool CompleteMissionsStep()
        {
            bool missionsLeft = false;

            if (EmulatorProcess != null && !EmulatorProcess.HasExited)
            {
                Controller.CaptureApplication(this);

                if (ScreenState.Overlays.Contains(Overlay.Widgets.MissionsAvailable))
                {
                    ushort chksum;

                    Color c;

                    if (ScreenState.CurrentArea == Area.Menus.Mission)
                    {
                        bool clicked = false;

                        for (int m = 0; m < 3; m++)
                        {
                            //Main.CurrentForm.UpdateBmpChk(SuperBitmap, 347, (int)Math.Round(292 + 91.5 * m), 8);
                            //chksum = ScreenState.GetScreenChecksum(SuperBitmap, 347, (int)Math.Round(292 + 91.5 * m), 8); //DIFF MS
                            chksum = ScreenState.GetScreenChecksum(SuperBitmap, 355, 462 + 53 * m + (m == 2 ? 60 : 0), 8); //DIFF FF

                            //if (chksum != 0x2995 && chksum != 0x1583) //missions available
                            //if (chksum != 0x3900 && chksum != 0x5f0f && chksum != 0xfc2d) //DIFF MS
                            if (chksum != 0x2459) //DIFF FF
                            {
                                //c = SuperBitmap.GetPixel(101, (int)Math.Round(240 + 91.5 * m)); //DIFF MS
                                c = SuperBitmap.GetPixel(330, 492 + 53 * m); //DIFF FF

                                //0x5960 2287
                                if (!c.Equals(0, 0, 0))
                                {
                                    missionsLeft = true;
                                    clicked = true;

                                    //no missions running
                                    //Controller.SendClick(this, 200, 250 + 91 * m, 300); //DIFF MS
                                    Controller.SendClick(this, 200, 490 + 53 * m, 300); //DIFF FF
                                    break;
                                }
                            }
                        }

                        Controller.CaptureApplication(this);

                        //c = SuperBitmap.GetPixel(355, 445); //DIFF MS
                        c = SuperBitmap.GetPixel(193, 249); //DIFF FF
                        //if (c.Equals(90, 219, 156)) //DIFF MS
                        if (c.Equals(123, 121, 132)) //if no quests available //DIFF FF
                        {
                            //Controller.SendClick(this, 200, 432, 300); //DIFF MS
                            skipMissions = true;
                            this.ClickBack(300); //DIFF FF
                        }
                        //else if (c.Equals(49, 56, 57)) //if loading //DIFF MS
                        else if (c.Equals(57, 56, 66)) //if loading //DIFF FF
                        {
                            Thread.Sleep(50);
                        }
                        else if (!clicked)
                        {
                            skipMissions = true;
                            this.ClickBack(200); //click Back
                        }
                    }
                    else if (ScreenState.CurrentArea == Area.Menus.Missions.Daily || ScreenState.CurrentArea == Area.Menus.Missions.Alliance || ScreenState.CurrentArea == Area.Menus.Missions.VIP)
                    {
                        bool clicked = false;

                        int vipOffset = (ScreenState.CurrentArea == Area.Menus.Missions.VIP ? 60 : 0);

                        missionsLeft = true;

                        //138,191,243,295,347 //FF verified y coords

                        for (int m = 0; m < 8; m++) //DIFF FF
                        {
                            chksum = ScreenState.GetScreenChecksum(SuperBitmap, 363, (int)Math.Round(138.45 + 52.1 * m) + vipOffset, 10);

                            if (chksum == 0x89b8) //quest in progress
                            {
                                break;
                            }
                            else if (chksum == 0x399b)
                            {
                                //collect quest
                                clicked = true;

                                Controller.SendClick(this, 350, 145 + 53 * m + vipOffset, 500);
                                break;
                            }
                            //else if (c.Equals(90, 89, 90))
                            //{
                            //    clicked = true;
                            //    Thread.Sleep(50);
                            //    break;
                            //}
                            else if (chksum == 0x739b)
                            {
                                //start mission
                                clicked = true;

                                c = SuperBitmap.GetPixel(52, (int)Math.Round(144.45 + 52.1 * m) + vipOffset);

                                if (c.Equals(8, 8, 8)) //black
                                {

                                }
                                else if (c.Equals(0, 8, 57)) //blue
                                {

                                }
                                else if (c.Equals(115, 117, 115)) //white
                                {

                                }
                                /*else if (c.Equals(222, 182, 255)) //purple
                                {

                                }*/
                                else if (c.Equals(0, 56, 0)) //green
                                {

                                }
                                /*else if (c.Equals(255, 247, 189)) //orange
                                {

                                }*/
                                else
                                {
                                    SuperBitmap.Bitmap.Save(String.Format("{0}\\{1}.bmp", Controller.Instance.GetFullScreenshotDir(), c.Name.Replace("#", "")), System.Drawing.Imaging.ImageFormat.Bmp);
                                }

                                Controller.SendClick(this, 350, 145 + 53 * m + vipOffset, 400);
                                break;
                            }
                            else if (chksum == 0xfe80) //loading
                            {
                                clicked = true;
                                Thread.Sleep(50);
                                break;
                            }
                        }

                        /*for (int m = 128; m < 521; m++)
                        {
                            c = SuperBitmap.GetPixel(282, m);

                            if (c.Equals(49, 150, 90))
                            {
                                //collect mission
                                clicked = true;

                                Controller.SendClick(this, 300, m, 500);
                                break;
                            }
                            //else if (c.Equals(90, 89, 90))
                            //{
                            //    clicked = true;
                            //    Thread.Sleep(50);
                            //    break;
                            //}
                            else if (c.Equals(57, 121, 140))
                            {
                                //start mission
                                clicked = true;

                                c = SuperBitmap.GetPixel(60, m);

                                if (c.Equals(74, 77, 82)) //black
                                {

                                }
                                else if (c.Equals(156, 215, 239)) //blue
                                {

                                }
                                else if (c.Equals(255, 251, 255)) //white
                                {

                                }
                                else if (c.Equals(222, 182, 255)) //purple
                                {

                                }
                                else if (c.Equals(140, 231, 181)) //green
                                {

                                }
                                else if (c.Equals(255, 247, 189)) //orange
                                {

                                }
                                else
                                {
                                    SuperBitmap.Bitmap.Save(String.Format("{0}\\{1}.bmp", Controller.Instance.GetFullScreenshotDir(), c.Name.Replace("#", "")), System.Drawing.Imaging.ImageFormat.Bmp);
                                }

                                Controller.SendClick(this, 300, m, 400);
                                break;
                            }
                        }*/ //DIFF MS

                        if (!clicked)
                        {
                            this.ClickBack(300); //click Back
                        }
                    }
                    else
                    {
                        missionsLeft = true;

                        Controller.SendClick(this, 110, 670, 200); //click Missions/Quests
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.Missions.VIPStreak)
                {
                    missionsLeft = true;

                    Controller.SendClick(this, 195, 415, 100); //click Collect
                }
                else if (ScreenState.CurrentArea == Area.Menus.Missions.ActivateVIP)
                {
                    missionsLeft = false;

                    this.ClickBack(100); //click Back
                    this.ClickBack(300); //click Back
                }
                else if (ScreenState.CurrentArea != Area.MainBases.Main)
                {
                    missionsLeft = true;
                    skipMissions = true;
                    this.ClickBack(100); //click Back
                }
            }

            return missionsLeft;
        }

        public bool ResourceTransfer(DataObjects.ScheduleTask task)
        {
            return ResourceTransfer(task.X, task.Y, task.Type, task.Amount, task.Count, task.BackupX, task.BackupY);
        }

        public bool ResourceTransfer(int x, int y, ScheduleType type, int amount = 9999999, int deployments = 1, int backupX = 0, int backupY = 0)
        {
            bool success = false;

            if (EmulatorProcess != null && Emulator.LastKnownAccount != null)
            {
                Stopwatch watch = new Stopwatch(), tmrRun = new Stopwatch();
                watch.Start();

                while (this.GoToBaseOrMapStep() && watch.ElapsedMilliseconds < 3000) { };

                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea == Area.Unknown)
                {
                    IsFucked = true;
                    return false;
                }

                watch.Restart();

                while (ScreenState.CurrentArea == Area.MainBases.Main && watch.ElapsedMilliseconds < 2600)
                {
                    Controller.SendClick(this, 20, 680, 1200);
                    Controller.CaptureApplication(this);
                }

                if (ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.StateMaps.FullScreen)
                {
                    int tries = 0;
                    bool targetSelected = false;
                    Color c;
                    ushort chksum;

                    #region Select Base
                    do
                    {
                        tries++;

                        bool coordSuccess;
                        if (tries > 2 && backupX > 0 && backupY > 0)
                        {
                            coordSuccess = GoToCoordinate(backupX, backupY);
                        }
                        else
                        {
                            coordSuccess = GoToCoordinate(x, y);
                        }

                        if (coordSuccess)
                        {
                            Thread.Sleep((int)(400 * TimeoutFactor));

                            watch.Restart();
                            do
                            {
                                Controller.SendClick(this, 196, 382, 1000); //click on destination base
                                Controller.CaptureApplication(this);
                            }
                            while (!ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.PlayerFriend) && watch.ElapsedMilliseconds < 2500);

                            if (ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.PlayerFriend))
                            {
                                /*
                                //for (int i = 250; i < 335; i++) //DIFF MS
                                for (int i = 225; i < 335; i++)
                                {
                                    c = SuperBitmap.GetPixel(200, i);

                                    //if (c.Equals(57, 121, 140)) //DIFF MS
                                    if (c.Equals(8, 235, 255))
                                    {
                                        //chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, i - 5, 20); //DIFF MS
                                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, i + 5, 20);

                                        //if (chksum == 0x10b3) //DIFF MS
                                        if (chksum == 0x7899)
                                        {
                                            targetSelected = true;
                                        }

                                        break;
                                    }
                                }*/
                                targetSelected = true;
                            }
                        }
                    }
                    while (!targetSelected && tries < 5);
                    #endregion

                    if (targetSelected)
                    {
                        int offset = 0;
                        /* DIFF MS
                         * c = SuperBitmap.GetPixel(60, 130);
                        while (c.R <= 8 && offset < 600)
                        {
                            offset++;
                            c = SuperBitmap.GetPixel(60, 130 + offset);
                        }*/

                        for (int i = 225; i < 335; i++)
                        {
                            c = SuperBitmap.GetPixel(200, i);

                            if (c.Equals(8, 235, 255))
                            {
                                chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, i + 5, 20);

                                if (chksum == 0x7899)
                                {
                                    offset = i + 10;
                                }

                                break;
                            }
                        }

                        //if (ClickUntil(50, 280 + offset, Area.Menus.ResourceHelp, 400, 2000)) //click on rss help //DIFF MS
                        if (ClickUntil(50, offset, Area.Menus.ResourceHelp, 400, 2000)) //click on rss help
                        {
                            int p = 0;

                            //Color coinColor = Color.FromArgb(206, 207, 198); //coin color
                            //Color foodColor = Color.FromArgb(198, 125, 16);

                            watch.Restart();

                            do
                            {
                                switch (type)
                                {
                                    case ScheduleType.OilTransfer:
                                        //p = 120; //DIFF MS
                                        p = 170;
                                        break;
                                    case ScheduleType.CoinTransfer:
                                        //p = 195; //DIFF MS
                                        p = 380;
                                        break;
                                    case ScheduleType.StoneTransfer:
                                        //p = 270; //DIFF MS
                                        p = 105;
                                        break;
                                    case ScheduleType.IronTransfer:
                                        //p = 350; //DIFF MS
                                        p = 240;
                                        break;
                                    case ScheduleType.FoodTransfer:
                                        /* DIFF MS
                                         * Controller.SendClickDrag(this, 20, 400, 20, 340, 100, false, 1200);
                                        Controller.CaptureApplication(this);

                                        for (p = 300; p < 420; p++)
                                        {
                                            c = SuperBitmap.GetPixel(40, p);

                                            if (c.Equals(foodColor.R, foodColor.G, foodColor.B))
                                            {
                                                break;
                                            }
                                        }*/
                                        p = 310;
                                        break;
                                }
                            }
                            while (p >= 419 && p == 0 && watch.ElapsedMilliseconds < 5000);

                            if (p != 419 && p != 0)
                            {
                                bool pending = false, rssNotSet = true, negative = false;

                                int deploymentsSent = 0;

                                tmrRun.Start();

                                while (tmrRun.ElapsedMilliseconds < 65000 && deployments > 0 || pending)
                                {
                                    watch.Restart();

                                    #region Setting RSS Amount
                                    if (rssNotSet)
                                    {
                                        do
                                        {
                                            if (negative && type == ScheduleType.FoodTransfer)
                                            {
                                                /*Controller.SendClick(this, 50, 355, 200);
                                                Controller.SendClick(this, 255, 355, 100); //click just a tad less than max*/
                                            }
                                            else
                                            {
                                                do
                                                {
                                                    /* DIFF MS
                                                     * if (type == ScheduleType.FoodTransfer)
                                                    {
                                                        Controller.CaptureApplication(this);

                                                        for (p = 105; p < 420; p++) 
                                                        {
                                                            c = SuperBitmap.GetPixel(40, p);

                                                            if (c.Equals(foodColor.R, foodColor.G, foodColor.B))
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }*/

                                                    //Controller.SendClick(this, 285, p, 100); //click white box
                                                    Controller.SendClick(this, 300, p, 100); //click white box
                                                    Controller.CaptureApplication(this);
                                                    c = SuperBitmap.GetPixel(230, 675);
                                                }
                                                //while (!c.Equals(247, 255, 255) && watch.ElapsedMilliseconds < 7000); //DIFF MS
                                                while (!c.Equals(214, 215, 214) && watch.ElapsedMilliseconds < 7000);

                                                //if (c.Equals(247, 255, 255)) //DIFF MS
                                                if (c.Equals(214, 215, 214))
                                                {
                                                    watch.Restart();

                                                    tries = 0;
                                                    do
                                                    {
                                                        //Controller.SendClick(this, 280, 675, 650);
                                                        Controller.SendKey(this, amount.ToString());
                                                        Thread.Sleep((int)((450 + (350 * tries)) * TimeoutFactor));

                                                        tries++;

                                                        Controller.CaptureApplication(this);
                                                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 14, 662, 20);
                                                    }
                                                    //while ((chksum == 0x58c8 || chksum == 0xbd90 || chksum == 0x174f) && watch.ElapsedMilliseconds < 7000); //DIFF MS
                                                    while ((chksum == 0x12a2 || chksum == 0xa5b2 || chksum == 0xaaf6) && watch.ElapsedMilliseconds < 7000);

                                                    Thread.Sleep((int)(600 * TimeoutFactor));

                                                    Controller.CaptureApplication(this);
                                                    //if (type == ScheduleType.CoinTransfer)
                                                    //{
                                                    chksum = ScreenState.GetScreenChecksum(SuperBitmap, 38, 662, 20); //38 = <10k  43 = <100k  48 = <1m
                                                    //}
                                                    //else
                                                    //{
                                                    //    chksum = ScreenState.GetScreenChecksum(SuperBitmap, 48, 662, 20); //38 = <10k  43 = <100k  48 = <1m
                                                    //}

                                                    //if (chksum == 0x174f) //less than 10k rss //DIFF MS
                                                    if (chksum == 0xaaf6) //less than 10k rss
                                                    {
                                                        //SuperBitmap.Bitmap.Save(String.Format("{0}{1}\\rss{2}.bmp", AppDomain.CurrentDomain.BaseDirectory, "output\\ss", LastChecksum.ToString("X4")), ImageFormat.Bmp);
                                                        Controller.SendClick(this, 345, 680, 400); //click Done
                                                        this.ClickBack(300); //click Back
                                                        return true;
                                                    }

                                                    Controller.SendClick(this, 345, 680, 400); //click Done
                                                }
                                            }

                                            Controller.CaptureApplication(this);
                                            //c = SuperBitmap.GetPixel(65, 520); //DIFF MS
                                            c = SuperBitmap.GetPixel(48, 533);
                                        }
                                        //while (!c.Within(57, 121, 140, 1) && watch.ElapsedMilliseconds < 7000); //DIFF MS
                                        while (!c.Within(8, 235, 255, 5) && watch.ElapsedMilliseconds < 7000);

                                        rssNotSet = false;
                                    }
                                    #endregion

                                    if (watch.ElapsedMilliseconds > 7000)
                                    {
                                        deployments = 0;
                                        pending = false;
                                        success = false;
                                    }
                                    else
                                    {
                                        Controller.CaptureApplication(this);
                                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 190, 115, 20);

                                        if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.TransferConfirmation))
                                        {
                                            //Controller.SendClick(this, 250, 215, 100); //Click Yes //DIFF MS
                                            Controller.SendClick(this, 235, 275, 100); //Click Yes
                                            //Controller.SendClick(this, 245, 65, 700); //click on rss //DIFF MS
                                            deploymentsSent++;
                                            deployments--;
                                            tmrRun.Restart();
                                            pending = true;
                                        }
                                        /* DIFF MS
                                         * else if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.MaxDeployments))
                                        {
                                            Controller.SendClick(this, 250, 215, 1000); //Click OK
                                            pending = false;
                                        }*/
                                        else if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.InsufficientResources))
                                        {
                                            Controller.SendClick(this, 250, 215, 400); //Click OK
                                            this.ClickBack(300);
                                            deployments = 1;
                                            if (type == ScheduleType.FoodTransfer && Emulator.LastKnownAccount.FoodNegativeAmount > 0)
                                            {
                                                negative = true;
                                            }
                                            rssNotSet = true;
                                            pending = false;
                                        }
                                        else if (ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.StateMaps.FullScreen)
                                        {
                                            pending = false;
                                        }
                                        else if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.Unknown))
                                        {
                                            SuperBitmap.Bitmap.Save(String.Format("{0}{1}\\rss{2}.bmp", AppDomain.CurrentDomain.BaseDirectory, "output\\ss\\unknown", chksum.ToString("X4")), ImageFormat.Bmp);
                                            Controller.Instance.SendNotification(String.Format("Rss Transfer Unknown dialog {0}", chksum.ToString("X4")), NotificationType.General);

                                            this.ClickBack(300);
                                            pending = false;
                                        }
                                        else
                                        {
                                            //c = SuperBitmap.GetPixel(65, 520); //DIFF MS
                                            c = SuperBitmap.GetPixel(65, 533);
                                            //if (c.Equals(57, 121, 140))
                                            if (c.Equals(8, 235, 255))
                                            {
                                                pending = false;
                                            }
                                            if (deployments > 0)
                                            {
                                                if (ScreenState.CurrentArea == Area.Menus.ResourceHelp)
                                                {
                                                    //Controller.SendClick(this, 65, 520, 200); //click Help //DIFFMS
                                                    Controller.SendClick(this, 65, 550, 200); //click Help
                                                }
                                            }
                                        }
                                    }
                                }

                                success = deploymentsSent > 0 && tmrRun.ElapsedMilliseconds < 60000;

                                tmrRun.Stop();
                            }
                        }
                    }
                }

                watch.Stop();
            }

            return success;
        }

        public bool ActivateVIP(int amount)
        {
            bool success = false;

            if (EmulatorProcess != null && Emulator.LastKnownAccount != null)
            {
                ushort chksum;
                Stopwatch watch = new Stopwatch(), tmrRun = new Stopwatch();
                tmrRun.Start();

                while (!success && tmrRun.ElapsedMilliseconds < 60000)
                {
                    watch.Start();

                    while (this.GoToBaseOrMapStep() && watch.ElapsedMilliseconds < 3000) { };

                    Controller.CaptureApplication(this);

                    if (ScreenState.CurrentArea == Area.Unknown)
                    {
                        IsFucked = true;
                        Emulator.LastKnownAccount = null;
                        return false;
                    }

                    watch.Restart();

                    while (ScreenState.CurrentArea == Area.StateMaps.Main && watch.ElapsedMilliseconds < 2500)
                    {
                        Controller.SendClick(this, 20, 680, 1200); //Click Base
                        Controller.CaptureApplication(this);
                    }

                    //Click VIP
                    if (ScreenState.CurrentArea == Area.MainBases.Main)
                    {
                        watch.Restart();

                        while (ScreenState.CurrentArea != Area.Menus.VIP && watch.ElapsedMilliseconds < 2000)
                        {
                            Controller.SendClick(this, 60, 20, 800); //Click VIP
                            Controller.CaptureApplication(this);
                        }

                        //click Add VIP Button
                        if (ScreenState.CurrentArea == Area.Menus.VIP)
                        {
                            chksum = ScreenState.GetScreenChecksum(SuperBitmap, 185, 137, 20);
                            if (chksum != 0x43bb)
                            {
                                //TODO: Revisit if this should just add the VIP time regardless
                                success = true;
                            }
                            else
                            {
                                watch.Restart();

                                while (ScreenState.CurrentArea != Area.Menus.VIPSubscriptions && watch.ElapsedMilliseconds < 2000)
                                {
                                    Controller.SendClick(this, 180, 145, 600); //Click Activate VIP
                                    Controller.CaptureApplication(this);
                                }

                                //click VIP Item
                                if (ScreenState.CurrentArea == Area.Menus.VIPSubscriptions)
                                {
                                    watch.Restart();

                                    int offset = 0;
                                    switch (amount)
                                    {
                                        case 30:
                                            offset = 0;
                                            break;
                                        case 60:
                                            offset = 1;
                                            break;
                                        case 1:
                                            offset = 2;
                                            break;
                                        case 7:
                                            offset = 3;
                                            break;
                                        default:
                                            offset = 2;
                                            break;
                                    }

                                    Controller.SendClick(this, 300, 153 + 116 * offset, 1500); //Click on item
                                    Controller.CaptureApplication(this);

                                    this.ClickBack(500);

                                    //check if active, success true
                                    Controller.CaptureApplication(this);

                                    chksum = ScreenState.GetScreenChecksum(SuperBitmap, 185, 137, 20);
                                    if (ScreenState.CurrentArea == Area.Menus.VIP && chksum != 0x43bb)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }

                        this.ClickBack(500);
                    }
                }
            }

            return success;
        }

        public bool ActivateBoost(DataObjects.ScheduleTask task)
        {
            return ActivateBoost(task.Type, task.Amount);
        }

        public bool ActivateBoost(ScheduleType type, int amount)
        {
            bool success = false;

            if (EmulatorProcess != null && Emulator.LastKnownAccount != null)
            {
                ushort chksum;
                Stopwatch watch = new Stopwatch(), tmrRun = new Stopwatch();
                tmrRun.Start();

                while (!success && tmrRun.ElapsedMilliseconds < 60000)
                {
                    watch.Start();

                    while (this.GoToBaseOrMapStep() && watch.ElapsedMilliseconds < 3000) { };

                    Controller.CaptureApplication(this);

                    if (ScreenState.CurrentArea == Area.Unknown)
                    {
                        IsFucked = true;
                        Emulator.LastKnownAccount = null;
                        return false;
                    }

                    watch.Restart();

                    while (ScreenState.CurrentArea == Area.StateMaps.Main && watch.ElapsedMilliseconds < 2000)
                    {
                        Controller.SendClick(this, 20, 680, 1200); //Click Base
                        Controller.CaptureApplication(this);
                    }

                    watch.Restart();

                    while (ScreenState.CurrentArea == Area.MainBases.Main && watch.ElapsedMilliseconds < 2000)
                    {
                        Controller.SendClick(this, 360, 200, 1200); //Click Boosts
                        Controller.CaptureApplication(this);
                    }

                    watch.Restart();

                    int y = 0;
                    bool found = false;

                    while (!found && watch.ElapsedMilliseconds < 2500)
                    {
                        ushort chkType = 0;
                        switch (type)
                        {
                            case ScheduleType.Shield:
                                //chkType = 0x4b1a; //DIFF MS
                                chkType = 0x89de;
                                break;
                            case ScheduleType.AntiScout:
                                //chkType = 0x1dd5; //DIFF MS
                                chkType = 0x02d5;
                                break;
                            case ScheduleType.UpkeepReduction:
                                //chkType = 0xdb1e; //DIFF MS
                                chkType = 0xe629;
                                break;
                            case ScheduleType.Health:
                                //chkType = 0x656a; //DIFF MS
                                chkType = 0x13d8;
                                break;
                            case ScheduleType.Defense:
                                chkType = 0x3d9e;
                                break;
                            case ScheduleType.Milestone:
                                chkType = 0xb5d2;
                                break;
                            case ScheduleType.EliteRebelTarget:
                                chkType = 0x7831;
                                break;
                        }

                        y = 0;
                        int tries = 0;
                        found = false;
                        do
                        {
                            Controller.CaptureApplication(this);
                            //for (y = 90; y < 455; y++) //DIFF MS
                            for (y = 115; y < 580; y++)
                            {
                                //chksum = ScreenState.GetScreenChecksum(SuperBitmap, 44, y, 2); //DIFF MS
                                //Main.CurrentForm.UpdateBmpChk(SuperBitmap, 44, y, 2); //DIFF MS
                                chksum = ScreenState.GetScreenChecksum(SuperBitmap, 26, y, 2);
                                Main.CurrentForm.UpdateBmpChk(SuperBitmap, 26, y, 2);

                                if (chksum == chkType)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                Controller.SendClickDrag(this, 44, 400, 44, 118, 800, false, 500); //Scroll down
                            }

                            tries++;
                        }
                        while (!found && tries < 20);
                    }

                    //if (found && ScreenState.CurrentArea == Area.Menus.Boost && SuperBitmap.GetPixel(312, y + 20).Within(49, 117, 148, 15)) //DIFF MS
                    if (found && ScreenState.CurrentArea == Area.Menus.Boost && SuperBitmap.GetPixel(80, y + 20).Within(0, 0, 0, 5))
                    {
                        success = true;
                    }
                    else if (found)
                    {
                        Controller.SendClick(this, 44, y, 800); //Click the specific Boost
                        Controller.CaptureApplication(this);

                        int offset = 0;
                        switch (type)
                        {
                            case ScheduleType.Shield:
                                if (ScreenState.CurrentArea != Area.Menus.Boosts.PeaceShield)
                                {
                                    return false;
                                }
                                switch (amount)
                                {
                                    case 8:
                                        offset = 0;
                                        break;
                                    case 24:
                                        offset = 1;
                                        break;
                                    case 3:
                                        offset = 2;
                                        break;
                                    case 30:
                                        offset = 3;
                                        break;
                                    default:
                                        //offset = 2; //DIFF MS
                                        offset = 0;
                                        break;
                                }
                                break;
                            case ScheduleType.AntiScout:
                                if (ScreenState.CurrentArea != Area.Menus.Boosts.AntiScout)
                                {
                                    return false;
                                }
                                switch (amount)
                                {
                                    case 24:
                                        offset = 0;
                                        break;
                                    case 7:
                                        offset = 1;
                                        break;
                                    default:
                                        offset = 0;
                                        break;
                                }
                                break;
                        }

                        //Controller.SendClick(this, 300, 190 + 116 * offset, 300); //Click on item //DIFF MS
                        Controller.SendClick(this, 300, 140 + 111 * offset, 300); //Click on item

                        Controller.CaptureApplication(this);
                        //chksum = ScreenState.GetScreenChecksum(SuperBitmap, 190, 115, 20);
                        //if (chksum == 0x4d8d || chksum == 0x3375) //Purchase Confirmation or Replace Boosts
                        if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.ReplaceBoost))
                        {
                            //Controller.SendClick(this, 275, 220, 300); //Click Yes //DIFF MS
                            Controller.SendClick(this, 275, 280, 300); //Click Yes
                        }
                        else if (ScreenState.Overlays.Contains(Overlay.Dialogs.Popups.Unknown)) //TODO: remove this check after purchase confirm dialog box is tracked
                        {
                            Controller.Instance.SendNotification("Boost fail, suspected purchase confirm", NotificationType.BoostActivationFail);
                        }

                        Thread.Sleep((int)(3500 * TimeoutFactor));
                        Controller.CaptureApplication(this);

                        //if (ScreenState.CurrentArea == Area.Menus.Boost && SuperBitmap.GetPixel(312, y + 20).Within(49, 117, 148, 15)) //DIFF MS
                        if (ScreenState.CurrentArea == Area.Menus.Boost && SuperBitmap.GetPixel(80, y + 20).Within(0, 0, 0, 5))
                        {
                            success = true;
                        }
                        else
                        {
                            //Controller.Instance.SendPushover(String.Format("Activate {0} Boost Fail", Enum.GetName(typeof(ScheduleType), type)), 1);
                        }
                    }

                    this.ClickBack(500);
                }

                watch.Stop();
                tmrRun.Stop();
            }

            return success;
        }

        public void MissionXP()
        {
            if (EmulatorProcess != null)
            {
                //Controller.CaptureApplication(this);

                //do
                {
                    Controller.SendClick(this, 110, 675, 1000); //click missions

                    //Controller.CaptureApplication(this);
                }
                //while (state.CurrentArea != Area.Menus.Alliance);

                //do
                {
                    //this.SendClick(125, 265); //click Daily
                    Controller.SendClick(this, 125, 360, 1000); //click Alliance

                    //Controller.CaptureApplication(this);
                }
                //while (state.CurrentArea != Area.Menus.Gifts);

                int i = 100;

                while (i > 0 && this.CheckPause())
                {
                    Controller.CaptureApplication(this);
                    Color c = SuperBitmap.GetPixel(290, 141);

                    while (!c.Equals(16, 28, 33))
                    {
                        Controller.CaptureApplication(this);

                        c = SuperBitmap.GetPixel(290, 141);

                        if (c.Equals(90, 89, 90))
                        {
                            //loading
                            Thread.Sleep((int)(200 * TimeoutFactor));
                        }
                        else if (c.Equals(57, 121, 140))
                        {
                            //complete
                            Controller.SendClick(this, 290, 141, 100);
                        }
                    }

                    Controller.SendClick(this, 270, 565, 500); //click chance

                    Controller.SendClick(this, 190, 270, 2000); //click chance

                    i--;
                }

                //bmp.Dispose();
                do
                {
                    Controller.SendClick(this, 15, 15, 1000); //click back
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea == Area.Menus.Gifts);

                do
                {
                    Controller.SendClick(this, 15, 15, 1000); //click back
                    Controller.CaptureApplication(this);
                }
                while (ScreenState.CurrentArea == Area.Menus.Alliance);
            }
        }

        public bool GoToBaseOrMapStep()
        {
            bool tasksLeft = false;

            if (EmulatorProcess != null)
            {
                Controller.CaptureApplication(this);

                //back out of any popups
                while (ScreenState.CurrentArea == Area.StateMaps.FullScreen
                    && ScreenState.Overlays.Count > 0)
                {
                    this.ClickBack(300);
                    Controller.CaptureApplication(this);
                }

                //Exit fullscreen
                if (ScreenState.CurrentArea == Area.StateMaps.FullScreen)
                {
                    tasksLeft = false;
                    Controller.SendClick(this, 375, 10, 200); //click Fullscreen
                }

                //exit monster screen
                if (ScreenState.Overlays.Contains(Overlay.Dialogs.Tiles.Rebel))
                {
                    this.ClickBack(300);
                }

                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea == Area.Others.Quit)
                {
                    tasksLeft = true;
                    this.ClickBack(300);
                }
                else
                {
                    //get back until base or map screen
                    if (!(ScreenState.CurrentArea == Area.StateMaps.Main || ScreenState.CurrentArea == Area.MainBases.Main || ScreenState.CurrentArea == Area.Others.Login || ScreenState.CurrentArea == Area.Emulators.Android || ScreenState.CurrentArea == Area.Emulators.Loading || ScreenState.CurrentArea == Area.Others.Splash || ScreenState.CurrentArea == Area.Emulators.Crash || ScreenState.CurrentArea == Area.Emulators.TaskManager || ScreenState.CurrentArea == Area.Emulators.TaskManagerApp || ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove))
                    {
                        tasksLeft = true;

                        if (ScreenState.CurrentArea == Area.Others.Quit)
                        {
                            TimeoutFactor += 0.1;
                        }

                        this.ClickBack(500); //click Back
                    }
                }
            }

            return tasksLeft;
        }

        /*public void GoToBaseOrMap()
        {
            bool tasksLeft = true;

            int curActiveWindow = this.ActiveWindow;

            Bitmap bmp = new Bitmap(1, 1);
            ScreenState state;

            while (tasksLeft)
            {
                tasksLeft = false;

                for (int i = 0; i < procs.Length; i++)
                {
                    ActiveWindow = i;

                    if (procs[ActiveWindow] != null)
                    {
                        bmp = this.CaptureApplication();
                        state = ScreenState.GetScreenState(bmp);

                        //Exit fullscreen
                        if (state.CurrentArea == Area.StateMaps.FullScreen)
                        {
                            tasksLeft = true;

                            this.SendClick(375, 10, 100); //click Fullscreen
                        }
                        //TODO: Move this check to active monitor
                        else if (state.CurrentArea == Area.Others.SessionTimeout)
                        {
                            tasksLeft = true;

                            this.KillApp();

                            Thread.Sleep(100);
                        }

                        bmp.Dispose();
                    }
                }
            }

            tasksLeft = true;
            int limit = 25;

            while (tasksLeft && limit > 0)
            {
                tasksLeft = false;

                for (int i = 0; i < procs.Length; i++)
                {
                    ActiveWindow = i;

                    if (procs[ActiveWindow] != null)
                    {
                        bmp = this.CaptureApplication();
                        state = ScreenState.GetScreenState(bmp);

                        //get back until base or map screen
                        if (!(state.CurrentArea == Area.StateMaps.Main || state.CurrentArea == Area.MainBases.Main || state.CurrentArea == Area.Others.Login || state.CurrentArea == Area.Others.Android || state.CurrentArea == Area.Others.Splash || state.CurrentArea == Area.Others.Crash || state.CurrentArea == Area.Others.TaskManager || state.CurrentArea == Area.Others.TaskManagerApp || state.CurrentArea == Area.Others.TaskManagerRemove))
                        {
                            tasksLeft = true;

                            if (state.CurrentArea == Area.Others.Quit)
                            {
                                this.timeoutFactor += 10;
                            }

                            limit--;

                            this.ClickBack(500); //click Back
                        }

                        bmp.Dispose();
                    }
                }
            }

            this.timeoutFactor = 100;

            this.ActiveWindow = curActiveWindow;

            bmp.Dispose();
        }*/

        public bool RegularTasksStep()
        {
            Stopwatch tmrRun = new Stopwatch();

            bool tasksLeft = false;

            if (EmulatorProcess != null && !EmulatorProcess.HasExited)
            {
                Controller.CaptureApplication(this);

                if (ScreenState.Overlays.Contains(Overlay.Widgets.AllianceHelp))
                {
                    tasksLeft = true;
                    Controller.SendClick(this, 365, 565, 250); //click Alliance Help
                }
                else if (ScreenState.CurrentArea == Area.MainBases.Main)
                {
                    if (ScreenState.Overlays.Contains(Overlay.Widgets.AmmoFreeAttack))
                    {
                        tasksLeft = true;
                        //Controller.SendClick(this, 210, 558, 1200); //click Free Attack
                        Controller.SendClick(this, 275, 600, 2000); //click Free Attack DIFF ff
                    }
                    else if (ScreenState.Overlays.Contains(Overlay.Widgets.GlobalGift))
                    {
                        tasksLeft = true;
                        Controller.SendClick(this, 30, 575, 200); //click Global Gift
                    }
                    else if (ScreenState.Overlays.Contains(Overlay.Widgets.SecretGift))
                    {
                        tasksLeft = true;
                        Controller.SendClick(this, 90, 575, 200); //click Secret Gift
                    }
                    else if (ScreenState.Overlays.Contains(Overlay.Widgets.DailyLogin))
                    {
                        tasksLeft = true;
                        Controller.SendClick(this, 372, 365, 100); //click Daily Login
                    }
                    else if (ScreenState.Overlays.Contains(Overlay.Widgets.RewardsCrate) && !skipRewards)
                    {
                        tasksLeft = true;
                        Controller.SendClick(this, 50, 570, 300); //click Rewards Crate
                    }
                    else if (ScreenState.Overlays.Contains(Overlay.Widgets.AllianceGift))
                    {
                        tasksLeft = this.CollectGiftsStep(); //Collect Gifts
                    }
                    else if (!skipMissions)
                    {
                        tasksLeft = true;
                        Controller.SendClick(this, 110, 670, 200); //click Missions
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.AllianceHelp && !ScreenState.Overlays.Contains(Overlay.Statuses.Loading))
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 290, 560, 10);
                    
                    //if (chksum == 0xe94d) //nox help //MS DIFF
                    if (chksum == 0xa960) //ff DIFF
                    {
                        //Controller.SendClick(this, 365, 565, 50); //click Help All DIFF MS
                        Controller.SendClick(this, 365, 568, 50); //click Help All DIFF ff
                    }
                    else
                    {
                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 150, 273, 10); //check if loading
                        ushort chksum2 = ScreenState.GetScreenChecksum(SuperBitmap, 192, 273, 10); //check if loaded but help is needed
                        //if (ScreenState.GetScreenChecksum(bmp, 150, 273, 10) == 0xe6f5 && ScreenState.GetScreenChecksum(bmp, 192, 273, 10) != 0xf143) //loading //f143 depricated?
                        //if (chksum == 0xe6f5 && chksum2 != 0x4266)
                        //if (chksum == 0xd923 && chksum2 != 0x4266) //nox, not true for some reason
                        if (chksum == 0x3968 && chksum2 != 0xc3d1) //memu
                        {
                            Thread.Sleep((int)(50 * TimeoutFactor));
                        }
                        else //none
                        {
                            this.ClickBack(300);
                        }

                    }
                }
                else if (ScreenState.CurrentArea == Area.MainBases.SecretGiftCollect)
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 190, 225, 20);
                    if (chksum == 0x4f25) //gift not ready
                    {
                        Controller.SendClick(this, 190, 370, 500); //click OK
                    }
                    else
                    {
                        Controller.SendClick(this, 140, 425, 500); //click Collect
                    }
                }
                else if (ScreenState.CurrentArea == Area.MainBases.GlobalGiftCollect)
                {
                    tasksLeft = true;
                    Controller.SendClick(this, 140, 440, 500); //click Collect
                }
                else if (ScreenState.CurrentArea == Area.Menus.RewardCrate)
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, 485, 10);
                    //if (chksum == 0x61d8)
                    if (chksum == 0x02bb) //nox
                    {
                        Controller.SendClick(this, 195, 485, 1000); //click Collect
                    }
                    else
                    {
                        skipRewards = true;
                        this.ClickBack(300);
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.Casino)
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 192, 438, 20);

                    if (chksum == 0x6734) //Free Spin
                    {
                        Controller.SendClick(this, 200, 445, 5000);
                    }
                    else
                    {
                        this.ClickBack(300);
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.ShootingRanges.Main)
                {
                    tasksLeft = true;

                    //seasonal shooting range modal dialog
                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 189, 435, 20);

                    if (chksum == 0x0c9b)
                    {
                        Controller.SendClick(this, 189, 435, 300);
                    }

                    /*bool done = false;

                    for (int p = 15; p < 100; p++)
                    {
                        Color c = SuperBitmap.GetPixel(p, 455);
                        if (!c.Equals(0, 0, 0))
                        {
                            Controller.SendClick(this, 40, 680, 300); //Click Base
                            done = true;
                            break;
                        }
                    }

                    if (!done)
                    {
                        Controller.SendClick(this, 200, 200, 4000); //Shoot
                    }*/
                    Controller.SendClick(this, 200, 200, 4000); //Shoot		
                    Controller.CaptureApplication(this);		
                    if (ScreenState.CurrentArea == Area.Menus.ShootingRanges.Main)		
                    {		
                        this.ClickBack(500);		
                        this.ClickBack(500);		
                    }
                }
                else if (ScreenState.CurrentArea == Area.Menus.ShootingRanges.NormalCrate)
                {
                    tasksLeft = true;

                    //ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 185, 225, 10);
                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 188, 388, 20); //DIFF ff
                    if (chksum == 0xe2f2) //if shooting range Collect Button (doesn't account for animated button)
                    {
                        //Random r = new Random();
                        //Controller.SendClick(this, 188, 415 + r.Next(0, 20), 1000); //click Collect
                        Controller.SendClick(this, 188, 388, 1000); //click Collect
                        Controller.SendClick(this, 40, 680, 300); //Click Base
                    }
                    else
                    {
                        chksum = ScreenState.GetScreenChecksum(SuperBitmap, 188, 486, 20); //DIFF ff
                        if (chksum == 0x6782) //if casino jackpot crate Collect Button (doesn't account for animated button)
                        {
                            //Random r = new Random();
                            //Controller.SendClick(this, 188, 415 + r.Next(0, 20), 1000); //click Collect
                            Controller.SendClick(this, 188, 488, 1000); //click Collect
                            Controller.SendClick(this, 40, 680, 300); //Click Base
                        }
                        else
                        {
                            int r = new Random().Next(0, 2);
                            Controller.SendClick(this, 75 + 120 * r, 295, 1500); //click Crate
                        }
                    }

                    /* DIFF MS
                    //if (chksum == 0x24a6)//pick a crate
                    if (chksum == 0x66b5 || chksum == 0xb40e || chksum == 0x0aad) //nox and nox new
                    {
                        int r = new Random().Next(0, 2);
                        Controller.SendClick(this, 100 + 98 * r, 305, 1500); //click Crate
                    }
                    else
                    {
                        Random r = new Random();
                        Controller.SendClick(this, 200, 415 + r.Next(0, 20), 1000); //click Collect
                        Controller.SendClick(this, 40, 680, 300); //Click Base
                    }*/
                }
                else if (ScreenState.CurrentArea == Area.Menus.ShootingRanges.Crates)
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, 551, 10);
                    
                    if (chksum == 0xf636) //memu
                    {
                        Controller.SendClick(this, 200, 560, 1500); //click Collect
                        Controller.SendClick(this, 40, 680, 300); //Click Base
                    }
                    else
                    {
                        Random r = new Random();
                        //int x = r.Next(0, 4), y = r.Next(0, 4);
                        //Controller.SendClick(this, 60 + 69 * x, 160 + 62 * y, 1000); //click Crate
                        int x = r.Next(24, 380), y = r.Next(164, 410);
                        Controller.SendClick(this, x, y, 1000); //click Crate
                    }
                }
                /*else if (ScreenState.CurrentArea == Area.Menus.ShootingRanges.UltimateCrate)
                {
                    tasksLeft = true;

                    ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 195, 557, 10);
                    if (chksum == 0xb265)
                    {
                        Controller.SendClick(this, 200, 560, 1500); //click Collect
                        Controller.SendClick(this, 40, 680, 300); //Click Base
                    }
                    else
                    {
                        Random r = new Random();
                        int x = r.Next(0, 9), y = r.Next(0, 4);
                        Controller.SendClick(this, 28 + 38 * x, 184 + 54 * y, 1000); //click Crate
                    }
                }*/
                else if (ScreenState.CurrentArea == Area.MainBases.DailyLogin)
                {
                    tasksLeft = true;
                    Controller.SendClick(this, 130, 430, 500); //click Claim
                }
                else if (ScreenState.CurrentArea == Area.MainBases.DailyLoginClaimed)
                {
                    tasksLeft = true;
                    this.ClickBack(100);
                }
                else if (ScreenState.CurrentArea == Area.Menus.Alliance || ScreenState.CurrentArea == Area.Menus.Gifts)
                {
                    tasksLeft = this.CollectGiftsStep(); //Collect Gifts
                }
                else if ((ScreenState.CurrentArea == Area.Menus.Mission && !ScreenState.Overlays.Contains(Overlay.Statuses.Loading))
                    || ScreenState.CurrentArea == Area.Menus.Missions.Daily || ScreenState.CurrentArea == Area.Menus.Missions.Alliance || ScreenState.CurrentArea == Area.Menus.Missions.VIP
                    || ScreenState.CurrentArea == Area.Menus.Missions.VIPStreak)
                {
                    if (ScreenState.CurrentArea == Area.Menus.Mission && !ScreenState.Overlays.Contains(Overlay.Statuses.Loading))
                    {
                        ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 125, 470, 20);
                        if (chksum == 0x09ac || chksum == 0xccb2) //missions at 00:00
                        {
                            DataObjects.Account account = Emulator.LastKnownAccount;
                            while (!this.Logout()) { }
                            Emulator.LastKnownAccount = account;
                        }
                    }
                    tasksLeft = this.CompleteMissionsStep(); //Complete Missions
                }
                else if (ScreenState.CurrentArea == Area.Menus.Missions.ActivateVIP)
                {
                    this.skipMissions = true;
                    this.ClickBack(300);
                    this.ClickBack(300);
                }
                else if (ScreenState.CurrentArea == Area.Others.Quit || ScreenState.CurrentArea == Area.Menus.Resources)
                {
                    tasksLeft = true;
                    //this.ClickBack(1000);
                    Controller.SendClick(this, 145, 480, 1000);
                }
            }

            return tasksLeft;
        }

        public void GetScreenState()
        {
            ScreenState state;

            switch (Emulator.App.ShortName)
            {
                case "MS":
                    state = new ScreenStateMS();
                    break;
                case "FFXV":
                    state = new ScreenStateFFXV();
                    break;
                default:
                    return;
            }

            state.CurrentArea = Area.Unknown;

            int failure = 100;
            do
            {
                if (!state.UpdateScreenState(SuperBitmap))
                {
                    failure--;
                }
                else
                {
                    failure = 0;
                }
            }
            while (failure > 0);

            if (ScreenState != null && ScreenState.CurrentArea != state.CurrentArea)
            {
                TimeSinceAreaChanged = DateTime.Now;
            }

            ScreenState = state;

            if (ScreenState.CurrentArea == Area.Others.SessionTimeout)
            {
                PreventFromOpening = true;
            }
        }
    }
}
