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
    public class NullScreen : Screen
    {
        public static new string PROCESSNAME = "";
        public static new int WINDOW_TITLEBAR_H = 0;
        public static new int WINDOW_MARGIN_L = 0;
        public static new int WINDOW_MARGIN_R = 0;
        public static new int WINDOW_GAP = 0;

        public NullScreen(string windowName) : base (windowName) { }

        public override string ProcessName
        {
            get { return NullScreen.PROCESSNAME; }
        }

        public override int WindowTitlebarH
        {
            get { return NullScreen.WINDOW_TITLEBAR_H; }
        }

        public override int WindowMarginL
        {
            get { return NullScreen.WINDOW_MARGIN_L; }
        }

        public override int WindowMarginR
        {
            get { return NullScreen.WINDOW_MARGIN_R; }
        }

        public override int WindowGap
        {
            get { return NoxScreen.WINDOW_GAP; }
        }

        public override void ClickBack(int timeout)
        {
            
        }

        public override void ClickHome(int timeout)
        {
            
        }

        public override bool KillApp()
        {
            return true;
        }

        public override bool StartApp()
        {
            return true;
        }
    }
}
