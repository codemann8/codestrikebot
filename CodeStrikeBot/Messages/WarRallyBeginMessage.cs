using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class WarRallyBeginMessage : JsonMessage
    {
        public string war_key { get; set; }
        public int alliance_id { get; set; }
        public int war_id { get; set; }
        public int war_type { get; set; }
        public int role { get; set; }
        public int state { get; set; }
        public int defeat_emoji { get; set; }
        public int timer_length { get; set; }
        public int timer { get; set; }
        public DateTime timer_start { get; set; }
        public DateTime timer_end { get; set; }
        public int troop_count { get; set; }
        public int hero_composite_id { get; set; }
        public int troop_max { get; set; }
        public int rallied_troop_count { get; set; }
        public int trap_max { get; set; }
        public int trap_count { get; set; }
        public int monster_count { get; set; }
        public bool copy_leader_ratio_enabled { get; set; }
        public Attacker attacker { get; set; }
        public Defender defender { get; set; }
        public List<Slot> slots { get; set; }
        public SharedCounts shared_counts { get; set; }

        public WarRallyBeginMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.Rally;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> war in (JObject)this.Json)
                    {
                        switch (war.Key)
                        {
                            case "war_key": this.war_key = war.Value.ToString(); break;
                            case "alliance_id": this.alliance_id = (int)war.Value; break;
                            case "war_id": this.war_id = (int)war.Value; break;
                            case "war_type": this.war_type = (int)war.Value; break;
                            case "role": this.role = (int)war.Value; break;
                            case "state": this.state = (int)war.Value; break;
                            case "defeat_emoji": this.defeat_emoji = (int)war.Value; break;
                            case "timer_length": this.timer_length = (int)war.Value; break;
                            case "timer": this.timer = (int)war.Value; break;
                            case "timer_start": this.timer_start = ((int)war.Value).ToDateTime(); break;
                            case "timer_end": this.timer_end = ((int)war.Value).ToDateTime(); break;
                            case "troop_count": this.troop_count = (int)war.Value; break;
                            case "hero_composite_id": this.hero_composite_id = (((JValue)war.Value).Type == JTokenType.Null ? -1 : (int)war.Value); break;
                            case "troop_max": this.troop_max = (int)war.Value; break;
                            case "rallied_troop_count": this.rallied_troop_count = (int)war.Value; break;
                            case "trap_max": this.trap_max = (int)war.Value; break;
                            case "trap_count": this.troop_count = (int)war.Value; break;
                            case "monster_count": this.monster_count = (int)war.Value; break;
                            case "copy_leader_ratio_enabled": this.copy_leader_ratio_enabled = (bool)war.Value; break;
                            case "attacker":
                                this.attacker = new Attacker();

                                foreach (KeyValuePair<string, JToken> att in (JObject)war.Value)
                                {
                                    switch (att.Key)
                                    {
                                        case "alliance": this.attacker.alliance = att.Value.ToString(); break;
                                        case "alliance_tag": this.attacker.alliance_tag = att.Value.ToString(); break;
                                        case "empire": this.attacker.empire = att.Value.ToString(); break;
                                        case "home_province_id": this.attacker.home_province_id = (int)att.Value; break;
                                        case "city": this.attacker.city = att.Value.ToString(); break;
                                        case "city_id": this.attacker.city_id = (int)att.Value; break;
                                        case "province_id": break;
                                        case "tile":
                                            this.attacker.tile = new Point3D();
                                            foreach (KeyValuePair<string, JToken> tile in (JObject)att.Value)
                                            {
                                                switch (tile.Key)
                                                {
                                                    case "province_id": this.attacker.tile.Z = (int)tile.Value; break;
                                                    case "chunk_id":
                                                        this.attacker.tile.X += Utilities.ChunkId2XCoordinate((int)tile.Value);
                                                        this.attacker.tile.Y += Utilities.ChunkId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "tile_id":
                                                        this.attacker.tile.X += Utilities.TileId2XCoordinate((int)tile.Value);
                                                        this.attacker.tile.Y += Utilities.TileId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "overlay": this.attacker.overlay = (int)tile.Value; break;
                                                    default: this.Error = true; break;
                                                }
                                            }
                                            break;
                                        case "rank": this.attacker.rank = (int)att.Value; break;
                                        case "vip": this.attacker.vip = (int)att.Value; break;
                                        case "user_id": this.attacker.user_id = (int)att.Value; break;
                                        case "empire_id": this.attacker.empire_id = (int)att.Value; break;
                                        case "army_id": this.attacker.army_id = (int)att.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
                            case "defender":
                                this.defender = new Defender();

                                foreach (KeyValuePair<string, JToken> def in (JObject)war.Value)
                                {
                                    switch (def.Key)
                                    {
                                        case "alliance": this.defender.alliance = def.Value.ToString(); break;
                                        case "alliance_tag": this.defender.alliance_tag = def.Value.ToString(); break;
                                        case "rank": this.defender.rank = (int)def.Value; break;
                                        case "vip": this.defender.vip = (int)def.Value; break;
                                        case "empire": this.defender.empire = def.Value.ToString(); break;
                                        case "user_id": this.defender.user_id = (int)def.Value; break;
                                        case "empire_id": this.defender.empire_id = (int)def.Value; break;
                                        case "city": this.defender.city = def.Value.ToString(); break;
                                        case "city_id": this.defender.city_id = (int)def.Value; break;
                                        case "province_id": break;
                                        case "tile":
                                            this.defender.tile = new Point3D();
                                            foreach (KeyValuePair<string, JToken> tile in (JObject)def.Value)
                                            {
                                                switch (tile.Key)
                                                {
                                                    case "province_id": this.defender.tile.Z = (int)tile.Value; break;
                                                    case "chunk_id":
                                                        this.defender.tile.X += Utilities.ChunkId2XCoordinate((int)tile.Value);
                                                        this.defender.tile.Y += Utilities.ChunkId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "tile_id":
                                                        this.defender.tile.X += Utilities.TileId2XCoordinate((int)tile.Value);
                                                        this.defender.tile.Y += Utilities.TileId2YCoordinate((int)tile.Value);
                                                        break;
                                                    default: this.Error = true; break;
                                                }
                                            }
                                            break;
                                        case "wonder_id": this.defender.wonder_id = (int)def.Value; break;
                                        case "wonder_alliance_id": this.defender.wonder_alliance_id = (int)def.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
                            case "slots":
                                this.slots = new List<Slot>();

                                foreach (JObject s in war.Value)
                                {
                                    Slot slot = new Slot();

                                    foreach (KeyValuePair<string, JToken> kvp in s)
                                    {
                                        switch (kvp.Key)
                                        {
                                            case "war_key": slot.war_key = kvp.Value.ToString(); break;
                                            case "alliance_id": slot.alliance_id = (int)kvp.Value; break;
                                            case "war_id": slot.war_id = (int)kvp.Value; break;
                                            case "slot_id": slot.slot_id = (int)kvp.Value; break;
                                            case "status": slot.status = (SlotStatus)(int)kvp.Value; break;
                                            case "empire": slot.empire = kvp.Value.ToString(); break;
                                            case "user_id": slot.user_id = (int)kvp.Value; break;
                                            case "empire_id": slot.empire_id = (int)kvp.Value; break;
                                            case "city_id": slot.city_id = (int)kvp.Value; break;
                                            case "army_id": slot.army_id = (int)kvp.Value; break;
                                            case "rank": slot.rank = (int)kvp.Value; break;
                                            case "vip": slot.vip =(int) kvp.Value; break;
                                            case "alliance_tag": slot.alliance_tag = kvp.Value.ToString(); break;
                                            case "timer_length": slot.timer_length = (int)kvp.Value; break;
                                            case "timer": slot.timer = (int)kvp.Value; break;
                                            case "timer_start": slot.timer_start = ((int)kvp.Value).ToDateTime(); break;
                                            case "timer_end": slot.timer_end = ((int)kvp.Value).ToDateTime(); break;
                                            case "troop_count": slot.troop_count = (int)kvp.Value; break;
                                            case "gathered_troops": break;
                                            case "gathered_units": break;
                                            case "total_troop_count": slot.total_troop_count = (int)kvp.Value; break;
                                            case "total_troop_max": slot.total_troop_max = (int)kvp.Value; break;
                                            case "trap_count": slot.trap_count = (int)kvp.Value; break;
                                            case "total_trap_count": slot.total_trap_count = (int)kvp.Value; break;
                                            case "total_trap_max": slot.total_trap_max = (int)kvp.Value; break;
                                            default: this.Error = true; break;
                                        }
                                    }

                                    this.slots.Add(slot);
                                }
                                break;
                            case "shared_counts":
                                this.shared_counts = new SharedCounts();

                                foreach (KeyValuePair<string, JToken> kvp in (JObject)war.Value)
                                {
                                    switch (kvp.Key)
                                    {
                                        case "alliance_incoming_invites": this.shared_counts.alliance_incoming_invites = (int)kvp.Value; break;
                                        case "alliance_war_attack": this.shared_counts.alliance_war_attack = (int)kvp.Value; break;
                                        case "alliance_war_defense": this.shared_counts.alliance_war_defense = (int)kvp.Value; break;
                                        case "alliance_ac_war_attack": this.shared_counts.alliance_ac_war_attack = (int)kvp.Value; break;
                                        case "alliance_ac_war_defense": this.shared_counts.alliance_ac_war_defense = (int)kvp.Value; break;
                                        default: this.Error = true; break;
                                    }
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

        public class Attacker
        {
            public string alliance { get; set; }
            public string alliance_tag { get; set; }
            public string empire { get; set; }
            public int home_province_id { get; set; }
            public string city { get; set; }
            public int city_id { get; set; }
            public int province_id { get; set; }
            public Point3D tile { get; set; }
            public int overlay { get; set; }
            public int rank { get; set; }
            public int vip { get; set; }
            public int user_id { get; set; }
            public int empire_id { get; set; }
            public int army_id { get; set; }
        }

        public class Defender
        {
            public string alliance { get; set; }
            public string alliance_tag { get; set; }
            public int rank { get; set; }
            public int vip { get; set; }
            public string empire { get; set; }
            public int user_id { get; set; }
            public int empire_id { get; set; }
            public string city { get; set; }
            public int city_id { get; set; }
            public int province_id { get; set; }
            public Point3D tile { get; set; }
            public int wonder_id { get; set; }
            public int wonder_alliance_id { get; set; }
        }

        public class Slot
        {
            public string war_key { get; set; }
            public int alliance_id { get; set; }
            public int war_id { get; set; }
            public int slot_id { get; set; }
            public SlotStatus status { get; set; }
            public string empire { get; set; }
            public int user_id { get; set; }
            public int empire_id { get; set; }
            public int city_id { get; set; }
            public int army_id { get; set; }
            public int rank { get; set; }
            public int vip { get; set; }
            public string alliance_tag { get; set; }
            public int timer_length { get; set; }
            public int timer { get; set; }
            public DateTime timer_start { get; set; }
            public DateTime timer_end { get; set; }
            public int troop_count { get; set; }
            //public object gathered_troops { get; set; }
            //public object gathered_units { get; set; }
            public int total_troop_count { get; set; }
            public int total_troop_max { get; set; }
            public int trap_count { get; set; }
            public int total_trap_count { get; set; }
            public int total_trap_max { get; set; }
        }

        //TODO: Move to outer scope, preferably a floating Rally object
        public class SharedCounts
        {
            public int alliance_incoming_invites { get; set; }
            public int alliance_war_attack { get; set; }
            public int alliance_war_defense { get; set; }
            public int alliance_ac_war_attack { get; set; }
            public int alliance_ac_war_defense { get; set; }
        }

        public enum SlotStatus : int
        {
            Free = 0,
            Filled = 2
        }
    }
}
