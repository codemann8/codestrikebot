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
    public class Droid4XScreen : Screen
    {
        public static new string PROCESSNAME = "Droid4X";

        public Droid4XScreen(DataObjects.EmulatorInstance emulator) : base(emulator) { }

        public override string ProcessName
        {
            get { return Droid4XScreen.PROCESSNAME; }
        }

        public override void ClickBack(int timeout)
        {
            Controller.SendClick(this, -15, 545, timeout);
        }

        public override void ClickHome(int timeout)
        {
            Controller.SendClick(this, -15, 575, timeout);
        }

        public override bool KillApp()
        {
            bool success = true;

            Stopwatch tmrRun = new Stopwatch();

            if (EmulatorProcess != null)
            {
                Controller.CaptureApplication(this);

                if (ScreenState.CurrentArea != Area.Others.Splash && ScreenState.CurrentArea != Area.Emulators.Android)
                {
                    tmrRun.Start();

                    Controller.SendClick(this, -15, 685, 2000); //click Task Manager

                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                        Controller.CaptureApplication(this);
                    }
                    while (ScreenState.CurrentArea != Area.Emulators.TaskManagerApp && tmrRun.ElapsedMilliseconds < 10000);

                    if (ScreenState.CurrentArea == Area.Emulators.TaskManagerApp)
                    {
                        tmrRun.Restart();

                        do
                        {
                            Controller.SendClick(this, 380, 680, 500, 2000); //Click and Hold
                            Controller.CaptureApplication(this);
                        }
                        while (ScreenState.CurrentArea != Area.Emulators.TaskManagerRemove && tmrRun.ElapsedMilliseconds < 8000);

                        if (ScreenState.CurrentArea == Area.Emulators.TaskManagerRemove)
                        {
                            tmrRun.Restart();

                            do
                            {
                                Controller.SendClick(this, 170, 330, 2000); //Click Remove
                                Controller.CaptureApplication(this);
                            }
                            while (ScreenState.CurrentArea != Area.Emulators.TaskManagerRemove && tmrRun.ElapsedMilliseconds < 5000);
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

                    tmrRun.Stop();
                }
            }

            return success;
        }

        public override bool StartApp()
        {
            bool success = true;

            Stopwatch tmrRun = new Stopwatch();

            if (EmulatorProcess != null)
            {
                Controller.CaptureApplication(this);

                tmrRun.Start();

                while (ScreenState.CurrentArea == Area.Emulators.Android && tmrRun.ElapsedMilliseconds < 5000)
                {
                    Controller.SendClick(this, 172, 230, 2000); //click app

                    Controller.CaptureApplication(this);
                }

                if (ScreenState.CurrentArea != Area.Emulators.Android)
                {
                    tmrRun.Restart();

                    //wait for login/ad screen
                    while (CheckPause() && !(ScreenState.CurrentArea == Area.Others.Login || ScreenState.CurrentArea == Area.Others.Ad) && tmrRun.ElapsedMilliseconds < 15000)
                    {
                        Thread.Sleep(500);

                        Controller.CaptureApplication(this);
                    }

                    if (ScreenState.CurrentArea != Area.Others.Login && ScreenState.CurrentArea != Area.Others.Ad)
                    {
                        success = false;
                    }

                    if (ScreenState.CurrentArea == Area.Others.Login)
                    {
                        Emulator.LastKnownAccount = null;
                    }
                }
                else
                {
                    success = false;
                }

                tmrRun.Stop();
            }

            return success;
        }

        /*public override const string PROCESSNAME = "Droid4X";

        public Process EmulatorProcess { get; set; }
        public Rect WindowRect { get; set; }
        public EmulatorInstance Emulator { get; set; }

        public double TimeoutFactor;
        public SuperBitmap SuperBitmap;
        public ScreenState ScreenState { get; set; }

        public bool IsFucked;
        public bool ClipboardFailed;
        public bool PreventFromOpening;
        public ushort LastChecksum { get; set; }
        public DateTime TimeSinceChecksumChanged { get; set; }

        public bool skipMissions, skipRewards, skipVault;

        public Droid4XScreen(EmulatorInstance emulator)
        {
            Emulator = emulator;
            ClipboardFailed = false;
            PreventFromOpening = false;
            TimeoutFactor = 1.0;
            TimeSinceChecksumChanged = DateTime.Now;

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            if (emulator.WindowName != "")
            {
                foreach (Process p in procs)
                {
                    if (p.MainWindowTitle.StartsWith(emulator.WindowName))
                    {
                        EmulatorProcess = p;
                        string wmiQuery = String.Format("select CommandLine, ProcessId from Win32_Process where Name='{0}.exe' and ProcessId={1}", PROCESSNAME, p.Id);
                        System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(wmiQuery);
                        foreach (System.Management.ManagementObject retObject in searcher.Get())
                        {
                            emulator.Command = retObject["CommandLine"].ToString();
                        }
                        break;
                    }
                }
            }

            //emulator.Save();

            //bmp1 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);
            //bmp2 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);

            SuperBitmap = new SuperBitmap(Controller.SCREEN_W, Controller.SCREEN_H);
        }*/
    }
}
