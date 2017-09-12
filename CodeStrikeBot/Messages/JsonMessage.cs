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
        public JToken Json;
        
        public bool Error;

        public JsonMessage(Message message)
            : base(message)
        {
            this.Error = false;
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

                    ret.LoadXml();
                    node = ret.Document.DocumentElement.FirstChild.FirstChild;
                    
                    ret.RawJson = ret.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']").InnerText;

                    try
                    {
                        ret.Json = JToken.Parse(ret.RawJson);

                        switch (node.Attributes["node"].Value)
                        {
                            case "EVENT_WAR_RALLY_BEGAN": //rally
                                ret = new WarRallyMessage(ret);
                                break;
                            case "EVENT_WAR_RALLY_ENDED": //rally end
                                ret = new WarRallyEndedMessage(ret);
                                break;
                            case "EVENT_MARCH": //march
                                ret = new MarchMessage(ret);
                                break;
                            case "EVENT_SYNCEDDATA": //various data
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
                            case "EVENT_ALLIANCE_UPDATE":
                                ret = new AllianceUpdateMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_FUNDS_UPDATE":
                                ret = new AllianceFundsUpdateMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_GIFT_CREATED":
                                ret = new AllianceGiftCreatedMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_GIFT_READY":
                                break;
                            case "EVENT_ALLIANCE_HELP_FINISHED":
                                ret = new AllianceHelpFinishedMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_HELP_REQUESTED":
                                ret = new AllianceHelpRequestedMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_HELPED":
                                ret = new AllianceHelpedMessage(ret);
                                break;
                            case "EVENT_ALLIANCE_STORE_HISTORY_UPDATE":
                                ret = new AllianceStoreHistoryUpdateMessage(ret);
                                break;
                            case "EVENT_TILE_UPDATED":
                                ret = new TileUpdatedMessage(ret);
                                break;
                            default:
                                System.IO.Directory.CreateDirectory(String.Format(".\\output\\debug\\unknownJson"));
                                System.IO.File.WriteAllText(String.Format(".\\output\\debug\\unknownJson\\{0}-{1}.txt", node.Attributes["node"].Value, ret.Id), Utilities.FormatJSON(ret.RawJson));
                                break;
                        }

                        //TODO: Remove this debugging eventually
                        if (!(ret is SyncedDataMessage) && ret.Error)
                        {
                            System.IO.Directory.CreateDirectory(String.Format(".\\output\\debug\\error"));
                            System.IO.File.WriteAllText(String.Format(".\\output\\debug\\error\\{0}-{1}.txt", node.Attributes["node"].Value, ret.Id), Utilities.FormatJSON(ret.RawJson));
                        }
                    }
                    catch (Newtonsoft.Json.JsonReaderException ex)
                    {
                        System.IO.Directory.CreateDirectory(String.Format(".\\output\\debug\\unknownJson"));
                        System.IO.File.WriteAllText(String.Format(".\\output\\debug\\unknownJson\\-ERROR-{0}-{1}.txt", node.Attributes["node"].Value, ret.Id), Utilities.FormatJSON(ret.RawJson));
                    }
                }
            }
            catch (System.Xml.XmlException ex) { }

            return ret;
        }
    }
}
