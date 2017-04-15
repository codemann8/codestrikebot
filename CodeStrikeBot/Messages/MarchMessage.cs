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
        public string RawJson;
        public bool Error;

        public string march_id { get; set; }
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int id { get; set; }
        public int city_id { get; set; }
        public int army_id { get; set; }
        public int home_id { get; set; }
        public int dest_province_id { get; set; }
        public int dest_chunk_id { get; set; }
        public int dest_tile_id { get; set; }
        public int from_province_id { get; set; }
        public int from_chunk_id { get; set; }
        public int from_tile_id { get; set; }
        public Data.MarchState state { get; set; }
        public DateTime start_time { get; set; }
        public DateTime dest_time { get; set; }
        public Data.MarchType type { get; set; }
        public int alliance_id { get; set; }
        public Data.MarchEmoji emoji { get; set; }
        public DateTime emoji_starttime { get; set; }
        public string type_data { get; set; }
        public DateTime update_ts { get; set; }
        public int anim_attrib { get; set; }
        public int truce_type { get; set; }
        public int color { get; set; }
        public bool king { get; set; }
        public string hero_gender { get; set; }
        public string hero_name { get; set; }
        public string dest_name { get; set; }
        public bool dest_name_need_localize { get; set; }
        public string from_name { get; set; }

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
                this.march_id = json.Substring(0, json.IndexOf("\""));
                json = json.Substring(json.IndexOf("{") + 1);
                json = json.Substring(0, json.IndexOf("}"));

                string[] pairs = json.Split(',');

                foreach (string pair in pairs)
                {
                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(pair.Substring(0, pair.IndexOf(":")).Replace("\"", ""), pair.Substring(pair.IndexOf(":") + 1).Replace("\"", ""));

                    switch (kvp.Key)
                    {
                        case "user_id":
                            this.user_id = Int32.Parse(kvp.Value);
                            break;
                        case "empire_id":
                            this.empire_id = Int32.Parse(kvp.Value);
                            break;
                        case "id":
                            this.id = Int32.Parse(kvp.Value);
                            break;
                        case "city_id":
                            this.city_id = Int32.Parse(kvp.Value);
                            break;
                        case "army_id":
                            this.army_id = Int32.Parse(kvp.Value);
                            break;
                        case "home_id":
                            this.home_id = Int32.Parse(kvp.Value);
                            break;
                        case "dest_province_id":
                            this.dest_province_id = Int32.Parse(kvp.Value);
                            break;
                        case "dest_chunk_id":
                            this.dest_chunk_id = Int32.Parse(kvp.Value);
                            break;
                        case "dest_tile_id":
                            this.dest_tile_id = Int32.Parse(kvp.Value);
                            break;
                        case "from_province_id":
                            this.from_province_id = Int32.Parse(kvp.Value);
                            break;
                        case "from_chunk_id":
                            this.from_chunk_id = Int32.Parse(kvp.Value);
                            break;
                        case "from_tile_id":
                            this.from_tile_id = Int32.Parse(kvp.Value);
                            break;
                        case "state":
                            switch (kvp.Value)
                            {
                                case "advancing":
                                    this.state = Data.MarchState.Advancing;
                                    break;
                                case "returning":
                                    this.state = Data.MarchState.Returning;
                                    break;
                                case "busy":
                                    this.state = Data.MarchState.Busy;
                                    break;
                                default:
                                    this.state = Data.MarchState.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "start_time":
                            this.start_time = Int32.Parse(kvp.Value).ToDateTime();
                            break;
                        case "dest_time":
                            this.dest_time = Int32.Parse(kvp.Value).ToDateTime();
                            break;
                        case "type":
                            switch (kvp.Value)
                            {
                                case "attack":
                                    this.type = Data.MarchType.Attack;
                                    break;
                                case "hero_attack":
                                    this.type = Data.MarchType.RebelAttack;
                                    break;
                                case "hero_escape":
                                    this.type = Data.MarchType.HeroEscape;
                                    break;
                                case "rally":
                                    this.type = Data.MarchType.Rally;
                                    break;
                                case "scout":
                                    this.type = Data.MarchType.Scout;
                                    break;
                                case "reinforce":
                                    this.type = Data.MarchType.Reinforcement;
                                    break;
                                case "war":
                                    this.type = Data.MarchType.War;
                                    break;
                                case "trade":
                                    this.type = Data.MarchType.Trade;
                                    break;
                                case "encamp":
                                    this.type = Data.MarchType.Tile;
                                    break;
                                default:
                                    this.type = Data.MarchType.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "alliance_id":
                            this.alliance_id = Int32.Parse(kvp.Value);
                            break;
                        case "emoji":
                            switch (kvp.Value)
                            {
                                case "EMOJI_MARCH_DEFAULT":
                                    this.emoji = Data.MarchEmoji.Default;
                                    break;
                                default:
                                    this.emoji = Data.MarchEmoji.Unknown;
                                    //this.Error = true;
                                    break;
                            }
                            break;
                        case "emoji_starttime":
                            this.emoji_starttime = Int32.Parse(kvp.Value).ToDateTime();
                            break;
                        case "type_data":
                            this.type_data = kvp.Value;
                            break;
                        case "update_ts":
                            this.update_ts = Int32.Parse(kvp.Value).ToDateTime();
                            break;
                        case "anim_attrib":
                            this.anim_attrib = Int32.Parse(kvp.Value);
                            break;
                        case "truce_type":
                            this.truce_type = Int32.Parse(kvp.Value);
                            break;
                        case "color":
                            this.color = Int32.Parse(kvp.Value);
                            break;
                        case "king":
                            this.king = kvp.Value == "true";
                            break;
                        case "hero_gender":
                            this.hero_gender = kvp.Value;
                            break;
                        case "hero_name":
                            this.hero_name = kvp.Value;
                            break;
                        case "dest_name":
                            this.dest_name = kvp.Value;
                            break;
                        case "dest_name_need_localize":
                            this.dest_name_need_localize = kvp.Value == "true";
                            break;
                        case "from_name":
                            this.from_name = kvp.Value;
                            break;
                        default:
                            this.Error = true;
                            break;
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

        public override string ToString()
        {
            return (this.Error ? "*ERROR* " : "") + String.Format("{0}: {1} {2}->{3}", this.march_id, Enum.GetName(typeof(Data.MarchType), this.type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.from_name, this.dest_name);
        }
    }
}
