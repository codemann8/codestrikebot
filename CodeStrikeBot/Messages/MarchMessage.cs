using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
//using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace CodeStrikeBot.Messages
{
    public class MarchMessage : JsonMessage
    {
        public Data.March March;

        public MarchMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.March;

            System.Xml.XmlNode node = this.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']");
            string json = node.InnerText;

            json = json.Substring(json.IndexOf("\"") + 1);
            this.March = new Data.March(json.Substring(json.IndexOf("\"")));

            json = json.Substring(json.IndexOf("user_id") + 9);
            this.March.user_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("empire_id") + 11);
            this.March.empire_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("\"id\"") + 6);
            this.March.id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("city_id") + 9);
            this.March.city_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("army_id") + 9);
            this.March.army_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("home_id") + 9);
            this.March.home_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("dest_province_id") + 18);
            this.March.dest_province_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("dest_chunk_id") + 15);
            this.March.dest_chunk_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("dest_tile_id") + 14);
            this.March.dest_tile_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("from_province_id") + 18);
            this.March.from_province_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("from_chunk_id") + 15);
            this.March.from_chunk_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("from_tile_id") + 14);
            this.March.from_tile_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("state") + 8);
            switch (json.Substring(0, json.IndexOf("\"")))
            {
                case "advancing":
                    this.March.state = Data.MarchState.Advancing;
                    break;
                default:
                    this.March.state = Data.MarchState.Unknown;
                    break;
            }

            json = json.Substring(json.IndexOf("start_time") + 12);
            this.March.start_time = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();

            json = json.Substring(json.IndexOf("dest_time") + 11);
            this.March.dest_time = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();

            json = json.Substring(json.IndexOf("type") + 7);
            switch (json.Substring(0, json.IndexOf("\"")))
            {
                case "attack":
                    this.March.type = Data.MarchType.Attack;
                    break;
                default:
                    this.March.type = Data.MarchType.Unknown;
                    break;
            }

            json = json.Substring(json.IndexOf("alliance_id") + 13);
            this.March.alliance_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("emoji") + 8);
            switch (json.Substring(0, json.IndexOf("\"")))
            {
                case "EMOJI_MARCH_DEFAULT":
                    this.March.emoji = Data.MarchEmoji.Default;
                    break;
                default:
                    this.March.emoji = Data.MarchEmoji.Default;
                    break;
            }

            json = json.Substring(json.IndexOf("emoji_starttime") + 17);
            this.March.emoji_starttime = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();

            json = json.Substring(json.IndexOf("type_data") + 11);
            this.March.type_data = json.Substring(0, json.IndexOf("update_ts") - 2);

            json = json.Substring(json.IndexOf("update_ts") + 11);
            this.March.update_ts = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();

            json = json.Substring(json.IndexOf("anim_attrib") + 13);
            this.March.anim_attrib = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("color") + 7);
            this.March.color = Int32.Parse(json.Substring(0, json.IndexOf(",")));

            json = json.Substring(json.IndexOf("king") + 6);
            this.March.king = json.Substring(0, json.IndexOf(",")) == "true";

            json = json.Substring(json.IndexOf("dest_name") + 12);
            this.March.dest_name = json.Substring(0, json.IndexOf("\""));

            json = json.Substring(json.IndexOf("from_name") + 12);
            this.March.from_name = json.Substring(0, json.IndexOf("\""));
        }

        public override string ToString()
        {
            return String.Format("\"{0}\": {1}->{2}", this.March.march_id, this.March.from_name, this.March.dest_name);
        }
    }
}
