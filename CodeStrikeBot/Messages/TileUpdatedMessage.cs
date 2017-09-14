using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class TileUpdatedMessage : JsonMessage
    {
        public List<Chunk> chunks { get; set; }
        public List<object> empires { get; set; }
        public List<object> alliances { get; set; }

        public TileUpdatedMessage(JsonMessage message)
            : base(message)
        {
            this.Type = MessageType.TileUpdate;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> root in (JObject)this.Json)
                    {
                        switch (root.Key)
                        {
                            case "chunks":
                                chunks = new List<Chunk>();

                                if (root.Value.Type != JTokenType.Array)
                                {
                                    this.Error = true;
                                }
                                else
                                {
                                    foreach (JObject chk in (JArray)root.Value)
                                    {
                                        Chunk chunk = new Chunk();

                                        foreach (KeyValuePair<string, JToken> c in chk)
                                        {
                                            switch (c.Key)
                                            {
                                                case "p_id": chunk.p_id = (int)c.Value; break;
                                                case "c_id": chunk.c_id = (int)c.Value; break;
                                                case "tiles":
                                                    chunk.tiles = new List<Tile>();

                                                    JObject chunkStart;

                                                    if (c.Value.Type == JTokenType.Array)
                                                    {
                                                        if (((JArray)c.Value).Count > 1)
                                                        {
                                                            this.Error = true;
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            chunkStart = (JObject)((JArray)c.Value)[0];
                                                        }
                                                    }
                                                    else
                                                    {
                                                        chunkStart = (JObject)c.Value;
                                                    }

                                                    foreach (KeyValuePair<string, JToken> tl in chunkStart)
                                                    {
                                                        Tile tile = new Tile();

                                                        foreach (KeyValuePair<string, JToken> t in (JObject)tl.Value)
                                                        {
                                                            switch (t.Key)
                                                            {
                                                                case "id": tile.tile_id = (int)t.Value; break;
                                                                case "overlay": tile.overlay = (int)t.Value; break;
                                                                case "object_id": tile.object_id = (int)t.Value; break;
                                                                case "last_updated": tile.last_updated = ((int)t.Value).ToDateTime(); break;
                                                                case "health": tile.health = (int)t.Value; break;
                                                                case "max_health": tile.max_health = (int)t.Value; break;
                                                                case "creature_id": tile.creature_id = (int)t.Value; break;
                                                                case "state": tile.state = (int)t.Value; break;
                                                                case "event_id": tile.event_id = (int)t.Value; break;
                                                                case "creature_type": tile.creature_type = (int)t.Value; break;
                                                                case "death_time": tile.death_time = ((int)t.Value).ToDateTime(); break;
                                                                case "city":
                                                                    tile.city = new City();
                                                                    foreach (KeyValuePair<string, JToken> city in (JObject)t.Value)
                                                                    {
                                                                        switch (city.Key)
                                                                        {
                                                                            case "user_id": tile.city.user_id = (int)city.Value; break;
                                                                            case "empire_id": tile.city.empire_id = (int)city.Value; break;
                                                                            case "city_id": tile.city.city_id = (int)city.Value; break;
                                                                            case "scout_cost": tile.city.scout_cost = (int)city.Value; break;
                                                                            case "city_name": tile.city.city_name = city.Value.ToString(); break;
                                                                            case "last_state": tile.city.last_state = (int)city.Value; break;
                                                                            case "is_last_state_ac_war": tile.city.is_last_state_ac_war = (bool)city.Value; break;
                                                                            case "state_timestamp": tile.city.state_timestamp = ((int)city.Value).ToDateTime(); break;
                                                                            case "defeated_vanity_id": tile.city.defeated_vanity_id = (int)city.Value; break;
                                                                            case "city_level": tile.city.city_level = (int)city.Value; break;
                                                                            default: break; //TODO: finish checking if incomplete
                                                                        }
                                                                    }
                                                                    break;
                                                                case "army":
                                                                    tile.army = new Army();
                                                                    foreach (KeyValuePair<string, JToken> army in (JObject)t.Value)
                                                                    {
                                                                        switch (army.Key)
                                                                        {
                                                                            case "user_id": tile.army.user_id = (int)army.Value; break;
                                                                            case "empire_id": tile.army.empire_id = (int)army.Value; break;
                                                                            case "city_id": tile.army.city_id = (int)army.Value; break;
                                                                            case "army_id": tile.army.army_id = (int)army.Value; break;
                                                                            case "scout_cost": tile.army.scout_cost = Int32.Parse(army.Value.ToString()); break;
                                                                            case "army_load": tile.army.army_load = (int)army.Value; break;
                                                                            default: break; //TODO: finish checking if incomplete
                                                                        }
                                                                    }
                                                                    break;
                                                                case "r_level": tile.r_level = (int)t.Value; break;
                                                                case "r_amount": tile.r_amount = (int)t.Value; break;
                                                                case "r_custom_expire_ts": tile.r_custom_expire_ts = ((int)t.Value).ToDateTime(); break;
                                                                case "r_gather_start_time": tile.r_gather_start_time = ((int)t.Value).ToDateTime(); break;
                                                                case "r_gather_duration": tile.r_gather_duration = (int)t.Value; break;
                                                                case "r_truce_expire_ts": tile.r_truce_expire_ts = ((int)t.Value).ToDateTime(); break;
                                                                case "r_tick_duration": tile.r_tick_duration = (double)t.Value; break;
                                                                default: this.Error = true; break;
                                                            }
                                                        }

                                                        chunk.tiles.Add(tile);
                                                    }
                                                    break;
                                                default: this.Error = true; break;
                                            }
                                        }

                                        this.chunks.Add(chunk);
                                    }
                                }
                                break;
                            case "empires":
                                //TODO: finish this
                                break;
                            case "alliances":
                                //TODO: finish this
                                break;
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
            catch (InvalidCastException ex)
            {
                this.Error = true;
            }
        }

        public override string ToString()
        {
            //return (this.Error ? "*ERROR* " : "") + String.Format("{0}: {1} {2}->{3}", this.march_id, Enum.GetName(typeof(Objects.March.MarchType), this.type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.from_name, this.dest_name);
            return "";
        }

        public class Chunk
        {
            public int p_id { get; set; }
            public int c_id { get; set; }
            public List<Tile> tiles { get; set; }
        }

        public class Tile
        {
            public int tile_id { get; set; }
            public int overlay { get; set; }
            public int object_id { get; set; }
            public DateTime last_updated { get; set; }
            public int health { get; set; }
            public int max_health { get; set; }
            public int creature_id { get; set; }
            public int state { get; set; }
            public int event_id { get; set; }
            public int creature_type { get; set; }
            public DateTime death_time { get; set; }
            public City city { get; set; }
            public Army army { get; set; }
            public int r_level { get; set; }
            public int r_amount { get; set; }
            public DateTime r_custom_expire_ts { get; set; }
            public DateTime r_gather_start_time { get; set; }
            public int r_gather_duration { get; set; }
            public DateTime r_truce_expire_ts { get; set; }
            public double r_tick_duration { get; set; }
        }

        public class City
        {
            public int user_id { get; set; }
            public int empire_id { get; set; }
            public int city_id { get; set; }
            public int scout_cost { get; set; }
            public string city_name { get; set; }
            public int last_state { get; set; }
            public bool is_last_state_ac_war { get; set; }
            public DateTime state_timestamp { get; set; }
            public int defeated_vanity_id { get; set; }
            public int city_level { get; set; }
        }

        public class Army
        {
            public int user_id { get; set; }
            public int empire_id { get; set; }
            public int city_id { get; set; }
            public int army_id { get; set; }
            public int scout_cost { get; set; }
            public int army_load { get; set; }
        }
    }
}
