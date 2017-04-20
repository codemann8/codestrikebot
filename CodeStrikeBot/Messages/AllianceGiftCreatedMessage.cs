using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceGiftCreatedMessage : JsonMessage
    {
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int alliance_id { get; set; }
        public int allianceawardedgift_id { get; set; }
        public int from_user { get; set; }
        public int from_empire { get; set; }
        public int gift_points { get; set; }
        public int alliancegift_id { get; set; }
        public int tier { get; set; }
        public string gift_contents { get; set; }
        public DateTime expires { get; set; }
        public int status { get; set; }
        public DateTime created_ts { get; set; }
        public int source_code { get; set; }
        public int _shardID { get; set; }

        public AllianceGiftCreatedMessage(JsonMessage message)
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
                            case "user_id": this.user_id = (int)stat.Value; break;
                            case "empire_id": this.empire_id = (int)stat.Value; break;
                            case "alliance_id": this.alliance_id = (int)stat.Value; break;
                            case "allianceawardedgift_id": this.allianceawardedgift_id = (int)stat.Value; break;
                            case "from_user": this.from_user = (int)stat.Value; break;
                            case "from_empire": this.from_empire = (int)stat.Value; break;
                            case "gift_points": this.gift_points = (int)stat.Value; break;
                            case "alliancegift_id": this.alliancegift_id = (int)stat.Value; break;
                            case "tier": this.tier = (int)stat.Value; break;
                            case "gift_contents": this.gift_contents = stat.Value.ToString(); break;
                            case "expires": this.expires = ((int)stat.Value).ToDateTime(); break;
                            case "status": this.status = (int)stat.Value; break;
                            case "created_ts": this.created_ts = ((int)stat.Value).ToDateTime(); break;
                            case "source_code": this.source_code = (int)stat.Value; break;
                            case "_shardID": this._shardID = (((JValue)stat.Value).Type == JTokenType.Null ? -1 : (int)stat.Value); break;
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
