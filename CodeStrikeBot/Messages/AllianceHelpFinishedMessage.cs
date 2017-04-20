using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceHelpFinishedMessage : JsonMessage
    {
        public string _event { get; set; }
        public string help_id { get; set; }
        public int help_currency { get; set; }

        public AllianceHelpFinishedMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.AllianceUpdate;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> stat in (JObject)this.Json)
                    {
                        switch (stat.Key)
                        {
                            case "_event": this._event = stat.Value.ToString(); break;
                            case "help_id": this.help_id = stat.Value.ToString(); break;
                            case "help_currency": this.help_currency = (int)stat.Value; break;
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
    }
}
