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
        
        //MEmu 2.9.6.1
        //WINDOW_TITLEBAR_H = 34;
        //WINDOW_MARGIN_L = 4;

        //MEmu 3.5.0.2
        public static new int WINDOW_TITLEBAR_H = 32;
        public static new int WINDOW_MARGIN_L = 2;
        public static new int WINDOW_MARGIN_R = 38;
        public static new int WINDOW_GAP = 14;

        public MEmuScreen(DataObjects.EmulatorInstance emulator)
            : base(emulator)
        {
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
                    if (p.MainWindowTitle.Contains(emulator.WindowName))
                    {
                        bool found = false;
                        
                        if (p.CommandLineArgs(EmulatorType.MEmu).Trim() == emulator.Command.Trim())
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

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            foreach (Process p in procs)
            {
                if (p.MainWindowTitle.Contains(windowName))
                {
                    EmulatorProcess = p;
                    Emulator = new DataObjects.EmulatorInstance(0, EmulatorType.MEmu, windowName, p.CommandLineArgs(EmulatorType.MEmu), new DataObjects.Account(0), new DataObjects.App(0));
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

        public override int WindowTitlebarH
        {
            get { return MEmuScreen.WINDOW_TITLEBAR_H; }
        }

        public override int WindowMarginL
        {
            get { return MEmuScreen.WINDOW_MARGIN_L; }
        }

        public override int WindowMarginR
        {
            get { return MEmuScreen.WINDOW_MARGIN_R; }
        }

        public override int WindowGap
        {
            get { return MEmuScreen.WINDOW_GAP; }
        }

        public override void ClickBack(int timeout)
        {
            if (this.ToString().Contains("2"))
            {
                timeout = timeout;
            }

            if (ScreenState.CurrentArea == Area.Menus.Missions.ActivateVIP)
            {
                Controller.SendClick(this, 348, 122, timeout);
            }
            else if (ScreenState.CurrentArea == Area.Others.Ad)
            {
                Controller.SendClick(this, 380, 12, timeout);
            }
            else if (ScreenState.CurrentArea == Area.Others.Quit)
            {
                Controller.SendClick(this, 255, 390, timeout);
            }
            else if (ScreenState.CurrentArea == Area.Emulators.ProcessStopped)
            {
                Controller.SendClick(this, 335, 380, timeout);
            }
            else
            {
                if (ScreenState.CurrentArea == Area.MainBases.Main)
                {
                    timeout = timeout;
                }

                ushort chksum = ScreenState.GetScreenChecksum(SuperBitmap, 15, 4, 20);
                if (chksum == 0x133d) //if screen is a menu
                {
                    Controller.SendClick(this, 25, 14, timeout);
                }
                else
                {
                    Controller.SendClick(this, Controller.SCREEN_W + WINDOW_MARGIN_L + WINDOW_MARGIN_R / 2, 582, timeout);
                }
            }
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
                    //Controller.SendClick(this, 127, 115, 2000); //click app //DIFF ff MEmu 2.9.6.1
                    Controller.SendClick(this, 60, 395, 2000); //click app //MEmu 3.0.5.2

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
                        //Emulator.LastKnownAccount = null;
                    }
                }
                else
                {
                    success = false;
                }

                tmrRun.Stop();
            }

            if (Emulator.LastKnownAccount == null)
            {
                Emulator.Save();
            }

            return success;
        }
    }
}
