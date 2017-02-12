using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
//using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace CodeStrikeBot.Messages
{
    public class WarRallyBeginMessage : JsonMessage
    {
        public string AttackerAlliance;
        public string AttackerName;
        public string DefenderAlliance;
        public string DefenderName;
        public int RallyTime;

        public WarRallyBeginMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.Rally;

            System.Xml.XmlNode node = this.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']");
            string json = node.InnerText;

            json = json.Substring(json.IndexOf("timer\"") + 7);
            this.RallyTime = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("alliance_tag") + 15);
            this.AttackerAlliance = json.Substring(0, json.IndexOf("\""));

            json = json.Substring(json.IndexOf("empire") + 9);
            this.AttackerName = json.Substring(0, json.IndexOf("\""));

            json = json.Substring(json.IndexOf("alliance_tag") + 15);
            this.DefenderAlliance = json.Substring(0, json.IndexOf("\""));

            json = json.Substring(json.IndexOf("empire") + 9);
            this.DefenderName = json.Substring(0, json.IndexOf("\""));
        }
    }
}
