using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ServiceModel;

namespace CodeStrikeBot.Services
{
    [ServiceContract]
    public interface ICodeBotService
    {
        [OperationContract]
        Bitmap GetScreen(int screenId);
    }
}
