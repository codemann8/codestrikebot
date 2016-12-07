using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeStrikeBot.Messages
{
    public class ChatMessage : XmlMessage
    {
        public string Message { get; set; }

        public ChatMessage(XmlMessage message)
            : base(message)
        {
            this.Type = MessageType.Chat;

            System.Xml.XmlNode node = this.Document.DocumentElement.SelectSingleNode("/message/body");

            if (node.FirstChild != null) //regular text
            {
                this.Message = node.FirstChild.Value;
            }
            else //8ball-flip-roll-etc
            {
                this.Message = "";
            }
        }
    }
}
