using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceUpdateMessage : JsonMessage
    {
        public int gift_level { get; set; }
        public long gift_level_start { get; set; }
        public long gift_level_end { get; set; }
        public long gift_level_progress { get; set; }
        public int alliance_id { get; set; }

        public AllianceUpdateMessage(JsonMessage message)
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
                            case "gift_level": this.gift_level = (int)stat.Value; break;
                            case "gift_level_start": this.gift_level_start = (long)stat.Value; break;
                            case "gift_level_end": this.gift_level_end = (long)stat.Value; break;
                            case "gift_level_progress": this.gift_level_progress = (long)stat.Value; break;
                            case "alliance_id": this.alliance_id = (int)stat.Value; break;
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
