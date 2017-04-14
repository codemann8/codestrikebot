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
        public string RawJson;
        public bool Error;

        public MarchMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.March;

            System.Xml.XmlNode node = this.Document.DocumentElement.SelectSingleNode("//*[local-name()='payload']");
            this.RawJson = node.InnerText;
            string json = this.RawJson;

            this.Error = false;

            try
            {
                json = json.Substring(json.IndexOf("\"") + 1);
                this.March = new Data.March(json.Substring(0, json.IndexOf("\"")));

                json = json.Substring(json.IndexOf("user_id") + 9);
                this.March.user_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

                json = json.Substring(json.IndexOf("empire_id") + 11);
                this.March.empire_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

                json = json.Substring(json.IndexOf("\"id\"") + 5);
                this.March.id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

                json = json.Substring(json.IndexOf("city_id") + 9);
                this.March.city_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

                json = json.Substring(json.IndexOf("army_id") + 9);
                this.March.army_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));

                if (json.IndexOf("home_id") > -1)
                {
                    json = json.Substring(json.IndexOf("home_id") + 9);
                    this.March.home_id = Int32.Parse(json.Substring(0, json.IndexOf(",")));
                }

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
                    case "returning":
                        this.March.state = Data.MarchState.Returning;
                        break;
                    case "busy":
                        this.March.state = Data.MarchState.Busy;
                        break;
                    default:
                        this.March.state = Data.MarchState.Unknown;
                        break;
                }

                json = json.Substring(json.IndexOf("start_time") + 12);
                if (json.IndexOf("\"") == 0)
                {
                    json = json.Substring(1);
                    this.March.start_time = Int32.Parse(json.Substring(0, json.IndexOf("\""))).ToDateTime();
                }
                else
                {
                    this.March.start_time = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();
                }

                json = json.Substring(json.IndexOf("dest_time") + 11);
                this.March.dest_time = Int32.Parse(json.Substring(0, json.IndexOf(","))).ToDateTime();

                json = json.Substring(json.IndexOf("type") + 7);
                switch (json.Substring(0, json.IndexOf("\"")))
                {
                    case "attack":
                        this.March.type = Data.MarchType.Attack;
                        break;
                    case "hero_attack":
                        this.March.type = Data.MarchType.RebelAttack;
                        break;
                    case "hero_escape":
                        this.March.type = Data.MarchType.HeroEscape;
                        break;
                    case "rally":
                        this.March.type = Data.MarchType.Rally;
                        break;
                    case "scout":
                        this.March.type = Data.MarchType.Scout;
                        break;
                    case "reinforce":
                        this.March.type = Data.MarchType.Reinforcement;
                        break;
                    case "war":
                        this.March.type = Data.MarchType.War;
                        break;
                    case "encamp":
                        this.March.type = Data.MarchType.Encampment;
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

                if (this.March.type != Data.MarchType.HeroEscape)
                {
                    json = json.Substring(json.IndexOf("king") + 6);
                    this.March.king = json.Substring(0, json.IndexOf(",")) == "true";
                }

                if (json.IndexOf("dest_name") > -1)
                {
                    json = json.Substring(json.IndexOf("dest_name") + 12);
                    this.March.dest_name = json.Substring(0, json.IndexOf("\""));
                }

                json = json.Substring(json.IndexOf("from_name") + 12);
                this.March.from_name = json.Substring(0, json.IndexOf("\""));
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

        public override string ToString()
        {
            return (this.Error ? "*ERROR* " : "") + this.March.ToString();
        }
    }
}
