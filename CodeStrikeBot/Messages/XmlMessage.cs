using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
//using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace CodeStrikeBot.Messages
{
    public class XmlMessage : Message
    {
        public XmlDocument Document;

        //public 

        public XmlMessage(Message message)
            : base(message)
        {
            this.Document = new XmlDocument();
        }

        public XmlMessage(XmlMessage message)
            : base(message)
        {
            this.Document = message.Document;
        }

        public static XmlMessage Parse(Message message)
        {
            XmlMessage ret = new XmlMessage(message);

            try
            {
                ret.LoadXml();
                System.Xml.XmlNode node = ret.Document.DocumentElement.SelectSingleNode("/message/body");

                if (node != null)
                {
                    ret = new ChatMessage(ret);
                }
                else
                {
                    ret.LoadXml();
                    node = ret.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']");

                    if (node != null)
                    {
                        ret = JsonMessage.Parse(ret);
                    }
                }
            }
            catch (System.Xml.XmlException ex) {
                ret = ret;
            }

            return ret;
        }

        public void LoadXml()
        {
            this.Document.LoadXml(System.Net.WebUtility.HtmlDecode(System.Text.Encoding.Default.GetString(this.PayloadData)));
        }
    }
}
