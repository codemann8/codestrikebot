﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class MarchMessage : JsonMessage
    {
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
        public Objects.March.MarchState state { get; set; }
        public DateTime start_time { get; set; }
        public DateTime dest_time { get; set; }
        public Objects.March.MarchType type { get; set; }
        public int alliance_id { get; set; }
        public string alliance_tag { get; set; }
        public Objects.March.MarchEmoji emoji { get; set; }
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
        public string companion_anims { get; set; }

        public MarchMessage(JsonMessage message)
            : base(message)
        {
            this.Type = MessageType.March;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> root in (JObject)this.Json)
                    {
                        march_id = root.Key;

                        foreach (KeyValuePair<string, JToken> m in (JObject)root.Value)
                        {
                            switch (m.Key)
                            {
                                case "user_id": this.user_id = (int)m.Value; break;
                                case "empire_id": this.empire_id = (int)m.Value; break;
                                case "id": this.id = (int)m.Value; break;
                                case "city_id": this.city_id = (int)m.Value; break;
                                case "army_id": this.army_id = (int)m.Value; break;
                                case "home_id": this.home_id = (int)m.Value; break;
                                case "dest_province_id": this.dest_province_id = (int)m.Value; break;
                                case "dest_chunk_id": this.dest_chunk_id = (int)m.Value; break;
                                case "dest_tile_id": this.dest_tile_id = (int)m.Value; break;
                                case "from_province_id": this.from_province_id = (int)m.Value; break;
                                case "from_chunk_id": this.from_chunk_id = (int)m.Value; break;
                                case "from_tile_id": this.from_tile_id = (int)m.Value; break;
                                case "state":
                                    switch (m.Value.ToString())
                                    {
                                        case "advancing": this.state = Objects.March.MarchState.Advancing; break;
                                        case "returning": this.state = Objects.March.MarchState.Returning; break;
                                        case "busy": this.state = Objects.March.MarchState.Busy; break;
                                        default:
                                            this.state = Objects.March.MarchState.Unknown;
                                            this.Error = true;
                                            break;
                                    }
                                    break;
                                case "start_time": this.start_time = ((int)m.Value).ToDateTime(); break;
                                case "dest_time": this.dest_time = ((int)m.Value).ToDateTime(); break;
                                case "type":
                                    switch (m.Value.ToString())
                                    {
                                        case "attack": this.type = Objects.March.MarchType.Attack; break;
                                        case "hero_attack": this.type = Objects.March.MarchType.RebelAttack; break;
                                        case "hero_escape": this.type = Objects.March.MarchType.HeroEscape; break;
                                        case "rally": this.type = Objects.March.MarchType.Rally; break;
                                        case "scout": this.type = Objects.March.MarchType.Scout; break;
                                        case "reinforce": this.type = Objects.March.MarchType.Reinforcement; break;
                                        case "war": this.type = Objects.March.MarchType.War; break;
                                        case "trade": this.type = Objects.March.MarchType.Trade; break;
                                        case "encamp": this.type = Objects.March.MarchType.Tile; break;
                                        case "digging": this.type = Objects.March.MarchType.Digging; break;
                                        default:
                                            this.type = Objects.March.MarchType.Unknown;
                                            this.Error = true;
                                            break;
                                    }
                                    break;
                                case "alliance_id": this.alliance_id = (int)m.Value; break;
                                case "alliance_tag": this.alliance_tag = m.Value.ToString(); break;
                                case "emoji":
                                    switch (m.Value.ToString())
                                    {
                                        case "EMOJI_MARCH_DEFAULT": this.emoji = Objects.March.MarchEmoji.Default; break;
                                        default: this.emoji = Objects.March.MarchEmoji.Unknown; break;
                                    }
                                    break;
                                case "emoji_starttime": this.emoji_starttime = ((int)m.Value).ToDateTime(); break;
                                case "type_data": this.type_data = m.Value.ToString(); break;
                                case "update_ts": this.update_ts = ((int)m.Value).ToDateTime(); break;
                                case "anim_attrib": this.anim_attrib = (int)m.Value; break;
                                case "truce_type": this.truce_type = (int)m.Value; break;
                                case "color": this.color = (int)m.Value; break;
                                case "king": this.king = (bool)m.Value; break;
                                case "hero_gender": this.hero_gender = m.Value.ToString(); break;
                                case "hero_name": this.hero_name = m.Value.ToString(); break;
                                case "dest_name": this.dest_name = m.Value.ToString(); break;
                                case "dest_name_need_localize": this.dest_name_need_localize = (bool)m.Value; break;
                                case "from_name": this.from_name = m.Value.ToString(); break;
                                case "companion_anims":
                                    if (((JValue)m.Value).Type == JTokenType.Null)
                                    {
                                        this.companion_anims = null;
                                    }
                                    else if (((JValue)m.Value).Type == JTokenType.String)
                                    {
                                        this.companion_anims = m.Value.ToString();
                                    }
                                    else
                                    {
                                        this.Error = true;
                                    }
                                    break;
                                default: this.Error = true; break;
                            }
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

        public override string ToString()
        {
            return (this.Error ? "*ERROR* " : "") + String.Format("{0}: {1} {2}->{3}", this.march_id, Enum.GetName(typeof(Objects.March.MarchType), this.type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.from_name, this.dest_name);
        }
    }
}
