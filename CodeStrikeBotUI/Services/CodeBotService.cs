using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ServiceModel;

namespace CodeStrikeBot.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConfigurationName = "bitmapOverTcp")]
    public class CodeBotService : ICodeBotService
    {
        #region Service Members
        public Bitmap GetScreen(int screenId)
        {
            if (screenId >= 0 && screenId < Controller.Instance.sc.Length)
            {
                Screen s = Controller.Instance.sc[screenId];
                if (s != null && s.SuperBitmap != null && s.SuperBitmap.Bitmap != null)
                {
                    return new Bitmap(s.SuperBitmap.Bitmap);
                }
            }
            
            return new Bitmap(0, 0);
        }
        #endregion
    }
}
