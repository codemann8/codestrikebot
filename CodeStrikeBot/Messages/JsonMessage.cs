using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class JsonMessage : XmlMessage
    {
        public string RawJson;
        public JObject Json;
        
        public bool Error;

        public JsonMessage(Message message)
            : base(message)
        {
            
        }

        public JsonMessage(JsonMessage message)
            : base(message)
        {
            this.RawJson = message.RawJson;
            this.Json = message.Json;

            this.Error = false;
        }

        public static JsonMessage Parse(XmlMessage message)
        {
            JsonMessage ret = new JsonMessage(message);

            try
            {
                ret.LoadXml();
                System.Xml.XmlNode node = ret.Document.DocumentElement.FirstChild.FirstChild;

                if (node != null && node.Name == "items")
                {
                    ret.Id = node.FirstChild.Attributes["id"].Value;
                    ret.Timestamp = Int32.Parse(node.FirstChild.Attributes["timestamp"].Value).ToDateTime();

                    node = ret.Document.DocumentElement.FirstChild.FirstChild;
                    node = ret.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']");
                    ret.RawJson = node.InnerText;
                    ret.Json = JObject.Parse(ret.RawJson);

                    switch (node.Attributes["node"].Value)
                    {
                        case "EVENT_WAR_RALLY_BEGAN": //rally defense
                            ret.LoadXml();
                            ret = new WarRallyBeginMessage(ret);
                            break;
                        case "EVENT_MARCH": //march
                            ret.LoadXml();
                            ret = new MarchMessage(ret);
                            break;
                        case "EVENT_SYNCEDDATA": //various data
                            ret.LoadXml();
                            ret = new SyncedDataMessage(ret);

                            //TODO: Remove debug output eventually
                            if (((SyncedDataMessage)ret).Watchtowers.Count > 0)
                            {
                                System.IO.Directory.CreateDirectory(String.Format(".\\output\\debug\\synceddata\\_watchtower"));
                                System.IO.File.WriteAllText(String.Format(".\\output\\debug\\synceddata\\_watchtower\\{0}.txt", (ret.Error ? "ERROR_" : "") + ret.Id), Utilities.FormatJSON(ret.RawJson));
                            }
                            else
                            {
                                System.IO.Directory.CreateDirectory(String.Format(".\\output\\debug\\synceddata"));
                                System.IO.File.WriteAllText(String.Format(".\\output\\debug\\synceddata\\{0}.txt", ret.Id), Utilities.FormatJSON(ret.RawJson));
                            }
                            break;
                    }
                }
            }
            catch (System.Xml.XmlException ex) { }

            return ret;
        }
    }
}
