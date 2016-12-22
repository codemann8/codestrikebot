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
    public class LeapdroidScreen : Screen
    {
        public static new string PROCESSNAME = "LeapdroidVM";

        public LeapdroidScreen(EmulatorInstance emulator) : base(emulator)
        {
            WINDOW_TITLEBAR_H = 30;
            WINDOW_MARGIN_L = 8;
            WINDOW_MARGIN_R = 79;

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
                        string wmiQuery = String.Format("select CommandLine, ProcessId from Win32_Process where Name='{0}.exe' and ProcessId={1}", PROCESSNAME, p.Id);
                        System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(wmiQuery);
                        bool found = false;
                        foreach (System.Management.ManagementObject retObject in searcher.Get())
                        {
                            string res = retObject["CommandLine"].ToString();
                            if (retObject["CommandLine"].ToString() == emulator.Command)
                            {
                                EmulatorProcess = p;
                                found = true;
                                break;
                            }
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

        public LeapdroidScreen(string windowName)
            : base(windowName)
        {
            //Emulator = emulator;
            ClipboardFailed = false;
            PreventFromOpening = false;
            TimeoutFactor = 1.0;
            TimeSinceChecksumChanged = DateTime.Now;

            WINDOW_TITLEBAR_H = 30;
            WINDOW_MARGIN_L = 8;
            WINDOW_MARGIN_R = 79;

            Process[] procs = Process.GetProcessesByName(PROCESSNAME);

            foreach (Process p in procs)
            {
                if (p.MainWindowTitle.StartsWith(windowName))
                {
                    EmulatorProcess = p;
                    string wmiQuery = String.Format("select CommandLine, ProcessId from Win32_Process where Name='{0}.exe' and ProcessId={1}", PROCESSNAME, p.Id);
                    System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(wmiQuery);
                    foreach (System.Management.ManagementObject retObject in searcher.Get())
                    {
                        Emulator = new EmulatorInstance(0, EmulatorType.Leapdroid, windowName, retObject["CommandLine"].ToString(), new Account(0));
                    }
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
            get { return LeapdroidScreen.PROCESSNAME; }
        }

        public override void ClickBack(int timeout)
        {
            Controller.SendClick(this, 150, 750, timeout);
        }

        public override void ClickHome(int timeout)
        {
            Controller.SendClick(this, 320, 750, timeout);
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

            if (EmulatorProcess != null && !PreventFromOpening)
            {
                Controller.CaptureApplication(this);

                tmrRun.Start();

                while (ScreenState.CurrentArea == Area.Emulators.Android && tmrRun.ElapsedMilliseconds < 5000)
                {
                    Controller.SendClick(this, 115, 225, 2000); //click app

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
