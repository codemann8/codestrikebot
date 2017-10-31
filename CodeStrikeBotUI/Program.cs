using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CodeStrikeBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, @"Global\" + Program.AssemblyGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }

                GC.Collect();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //catch all exceptions
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(CatchThreadExceptions);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CatchUnhandledExceptions);

                //Controller.SendPushoverStatic("CodeStrikeBot Hello");

                try
                {
                    //Controller.SendPushoverStatic("Bot started");
                    Application.Run(new Main());
                }
                catch (Exception e)
                {
                    BotDatabase.InsertLog(0, String.Format("{0} {1}", e.GetType(), e.Message), e.StackTrace, new byte[1] {0x0});
                    Controller.Instance.SendNotification("Bot Crash", NotificationType.Crash);
                    RestartApp();
                }
            }
        }

        private static void CatchThreadExceptions(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (!(e.Exception.Message == "Bitmap region is already locked." || e.Exception.Message != ""))
            {
                e = e;
            }
            BotDatabase.InsertLog(0, String.Format("{0} {1}", e.Exception.GetType(), e.Exception.Message), e.Exception.StackTrace, new byte[1] { 0x0 });
            Controller.Instance.SendNotification(String.Format("Bot Crash Threaded {0} {1} {2}", e.Exception.GetType(), e.Exception.Message, e.Exception.StackTrace), NotificationType.Crash);
            System.Threading.Thread.Sleep(1000);
            Program.RestartApp();
        }

        private static void CatchUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Exception ex = (Exception)e.ExceptionObject;
                BotDatabase.InsertLog(0, String.Format("{0} {1}", ex.GetType(), ex.Message), ex.StackTrace, new byte[1] { 0x0 });
                Controller.Instance.SendNotification(String.Format("Bot Crash Unhandled {0} {1} {2}", ex.GetType(), ex.Message, ex.StackTrace), NotificationType.Crash);
            }
            else
            {
                BotDatabase.InsertLog(0, String.Format("Unhandled exception on {0}", e.ExceptionObject.GetType().ToString()), e.ToString(), e.ExceptionObject.ToByteArray());
                Controller.Instance.SendNotification("Bot Crash Unhandled", NotificationType.Crash);
            }
            System.Threading.Thread.Sleep(1000);
            Program.RestartApp();
        }

        public static void RestartApp()
        {
            System.Threading.Thread.Sleep(5000);
            //Controller.Instance.SendNotification("Bot shutdown", NotificationType.General);
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 2 && ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            System.Diagnostics.Process.Start(Info);
            Application.Exit();
        }

        public static string AssemblyGuid
        {
            get
            {
                var assembly = typeof(Program).Assembly;
                var attribute = (System.Runtime.InteropServices.GuidAttribute)assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true)[0];
                return attribute.Value;
            }
        }
    }
}
