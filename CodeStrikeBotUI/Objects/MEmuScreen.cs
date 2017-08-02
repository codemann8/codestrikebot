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
    public class MEmuScreen : Screen
    {
        public static new string PROCESSNAME = "MEmu";

        public MEmuScreen(EmulatorInstance emulator) : base(emulator)
        {
            WINDOW_TITLEBAR_H = 34;
            WINDOW_MARGIN_L = 4;
            WINDOW_MARGIN_R = 52;

            Emulator = emulator;
            ClipboardFailed = false;
            PreventFromOpening = false;
            //TODO Slow mode
            TimeoutFactor = 1.0;
            TimeSinceChecksumChanged = DateTime.Now;

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            if (emulator.WindowName != "")
            {
                foreach (Process p in procs)
                {
                    if (p.MainWindowTitle.StartsWith(emulator.WindowName))
                    {
                        bool found = false;
                        
                        if (p.CommandLineArgs(EmulatorType.MEmu) == emulator.Command)
                        {
                            EmulatorProcess = p;
                            found = true;
                            break;
                        }

                        if (found)
                        {
                            break;
                        }
                    }
                }
            }

            //emulator.Save();

            //bmp1 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);
            //bmp2 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);

            SuperBitmap = new SuperBitmap(Controller.SCREEN_W, Controller.SCREEN_H);
        }

        public MEmuScreen(string windowName)
            : base(windowName)
        {
            //Emulator = emulator;
            ClipboardFailed = false;
            PreventFromOpening = false;
            //TODO Slow mode
            TimeoutFactor = 1.0;
            //TimeoutFactor = 5;
            TimeSinceChecksumChanged = DateTime.Now;

            WINDOW_TITLEBAR_H = 44;
            WINDOW_MARGIN_L = 4;
            WINDOW_MARGIN_R = 52;

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            foreach (Process p in procs)
            {
                if (p.MainWindowTitle.StartsWith(windowName))
                {
                    EmulatorProcess = p;
                    Emulator = new EmulatorInstance(0, EmulatorType.Leapdroid, windowName, p.CommandLineArgs(EmulatorType.MEmu), new Account(0), new App(0));
                    break;
                }
            }

            //emulator.Save();

            //bmp1 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);
            //bmp2 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);

            SuperBitmap = new SuperBitmap(Controller.SCREEN_W, Controller.SCREEN_H);
        }

        public override string ProcessName
        {
            get { return MEmuScreen.PROCESSNAME; }
        }

        public override void ClickBack(int timeout)
        {
            Controller.SendClick(this, 420, 582, timeout);
        }

        public override void ClickHome(int timeout)
        {
            Controller.SendClick(this, 420, 616, timeout);
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
                    ClickHome(600);
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

                while (ScreenState.CurrentArea == Area.Emulators.Android && tmrRun.ElapsedMilliseconds < 8000)
                {
                    Controller.SendClick(this, 127, 115, 2000); //click app //DIFF ff

                    Controller.CaptureApplication(this);
                }

                if (ScreenState.CurrentArea != Area.Emulators.Android)
                {
                    tmrRun.Restart();

                    //wait for login/ad screen
                    while (CheckPause() && !(ScreenState.CurrentArea == Area.Others.Login || ScreenState.CurrentArea == Area.Others.Ad || ScreenState.CurrentArea == Area.MainBases.Main) && tmrRun.ElapsedMilliseconds < 15000)
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
    }
}
