using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceStoreHistoryUpdateMessage : JsonMessage
    {
        public string _event { get; set; }
        public int member_id { get; set; }
        public string name { get; set; }
        public int glory_earned { get; set; }
        public int loyalty_spent { get; set; }

        public AllianceStoreHistoryUpdateMessage(JsonMessage message)
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
                            case "event": this._event = stat.Value.ToString(); break;
                            case "member_id": this.member_id = (int)stat.Value; break;
                            case "name": this.name = stat.Value.ToString(); break;
                            case "glory_earned": this.glory_earned = (int)stat.Value; break;
                            case "loyalty_spent": this.loyalty_spent = (int)stat.Value; break;
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
