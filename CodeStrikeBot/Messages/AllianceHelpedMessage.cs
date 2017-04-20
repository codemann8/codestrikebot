using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceHelpedMessage : JsonMessage
    {
        public string _event { get; set; }
        public List<HelpData> help_data { get; set; }

        public AllianceHelpedMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.AllianceUpdate;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> root in (JObject)this.Json)
                    {
                        switch (root.Key)
                        {
                            case "_event": this._event = root.Value.ToString(); break;
                            case "help_data":
                                this.help_data = new List<HelpData>();
                                foreach (KeyValuePair<string, JToken> help in (JObject)root.Value)
                                {
                                    HelpData data = new HelpData();
                                    data.help_id = help.Key;
                                    
                                    foreach (KeyValuePair<string, JToken> d in (JObject)help.Value)
                                    {
                                       switch (d.Key)
                                       {
                                           case "help_count": data.help_count = (int)d.Value; break;
                                           case "helper_user_id": data.helper_userid = (int)d.Value; break;
                                           default: this.Error = true; break;
                                       }
                                    }

                                    this.help_data.Add(data);
                                }
                                break;
                            default: this.Error = true; break;
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                this.Error = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.Error = true;
            }
        }

        public class HelpData
        {
            public string help_id { get; set; }
            public int help_count { get; set; }
            public int helper_userid { get; set; }
        }
    }
}
