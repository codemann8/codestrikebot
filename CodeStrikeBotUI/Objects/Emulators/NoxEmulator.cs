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
    public class NoxScreen : Screen
    {
        public static new string PROCESSNAME = "Nox";
        public static new int WINDOW_TITLEBAR_H = 36;
        public static new int WINDOW_MARGIN_L = 2;
        public static new int WINDOW_MARGIN_R = 36;
        public static new int WINDOW_GAP = 5;

        public NoxScreen(DataObjects.EmulatorInstance emulator) : base(emulator)
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
                        emulator.Command = p.CommandLineArgs(EmulatorType.Nox);
                        break;
                    }
                }
            }

            //emulator.Save();

            //bmp1 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);
            //bmp2 = new Bitmap(Controller.SCREEN_W, Controller.SCREEN_H, PixelFormat.Format16bppRgb565);

            SuperBitmap = new SuperBitmap(Controller.SCREEN_W, Controller.SCREEN_H);
        }

        public NoxScreen(string windowName) : base(windowName)
        {
            //Emulator = emulator;
            ClipboardFailed = false;
            PreventFromOpening = false;
            TimeoutFactor = 1.0;
            TimeSinceChecksumChanged = DateTime.Now;

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            foreach (Process p in procs)
            {
                if (p.MainWindowTitle.StartsWith(windowName))
                {
                    EmulatorProcess = p;
                    Emulator = new DataObjects.EmulatorInstance(0, EmulatorType.Nox, windowName, p.CommandLineArgs(EmulatorType.Nox), new DataObjects.Account(0), new DataObjects.App(0));
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
            get { return NoxScreen.PROCESSNAME; }
        }

        public override int WindowTitlebarH
        {
            get { return NoxScreen.WINDOW_TITLEBAR_H; }
        }

        public override int WindowMarginL
        {
            get { return NoxScreen.WINDOW_MARGIN_L; }
        }

        public override int WindowMarginR
        {
            get { return NoxScreen.WINDOW_MARGIN_R; }
        }

        public override int WindowGap
        {
            get { return NoxScreen.WINDOW_GAP; }
        }

        public override void ClickBack(int timeout)
        {
            Controller.SendClick(this, Controller.SCREEN_W + WINDOW_MARGIN_L * 2 + WINDOW_MARGIN_R / 2, 600, timeout);
        }

        public override void ClickHome(int timeout)
        {
            //TODO: Found out correct y coord
            Controller.SendClick(this, Controller.SCREEN_W + WINDOW_MARGIN_L * 2 + WINDOW_MARGIN_R / 2, 600, timeout);
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
                    Controller.SendClick(this, Controller.SCREEN_W + WINDOW_MARGIN_L * 2 + WINDOW_MARGIN_R / 2, 345, 300);
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
                    Controller.SendClick(this, 810, 300, 2000); //click app

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
    }
}
