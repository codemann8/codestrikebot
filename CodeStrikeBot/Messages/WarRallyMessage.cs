using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class WarRallyMessage : JsonMessage
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
        public Objects.Rally.HeroComposite hero_composite_id { get; set; }
        public int troop_max { get; set; }
        public int super_troop_count { get; set; }
        public int super_troop_max { get; set; }
        public int total_super_troop_count { get; set; }
        public int total_super_troop_max { get; set; }
        public int rallied_troop_count { get; set; }
        public int trap_max { get; set; }
        public int trap_count { get; set; }
        public int monster_count { get; set; }
        public bool copy_leader_ratio_enabled { get; set; }
        public Objects.Rally.Attacker attacker { get; set; }
        public Objects.Rally.Defender defender { get; set; }
        public List<Objects.Rally.RallySlot> slots { get; set; }
        public Objects.Rally.SharedCounts shared_counts { get; set; }
        public bool bypass_final_confirmation { get; set; }
        public bool war_commission_required { get; set; }
        public string war_group_type { get; set; }

        public WarRallyMessage(JsonMessage message)
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
                            case "hero_composite_id":
                                if (war.Value.Type == JTokenType.Null)
                                {
                                    this.hero_composite_id = null;
                                }
                                else
                                {
                                    if (war.Value is JObject)
                                    {
                                        this.hero_composite_id = new Objects.Rally.HeroComposite();

                                        foreach (KeyValuePair<string, JToken> hero in (JObject)war.Value)
                                        {
                                            switch (hero.Key)
                                            {
                                                case "user_id": this.hero_composite_id.user_id = (int)hero.Value; break;
                                                case "city_id": this.hero_composite_id.city_id = (int)hero.Value; break;
                                                default: this.Error = true; break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case "troop_max": this.troop_max = (int)war.Value; break;
                            case "super_troop_count": this.super_troop_count = (int)war.Value; break;
                            case "super_troop_max": this.super_troop_max = (int)war.Value; break;
                            case "total_super_troop_count": this.total_super_troop_count = (int)war.Value; break;
                            case "total_super_troop_max": this.total_super_troop_max = (int)war.Value; break;
                            case "rallied_troop_count": this.rallied_troop_count = (int)war.Value; break;
                            case "trap_max": this.trap_max = (int)war.Value; break;
                            case "trap_count": this.troop_count = (int)war.Value; break;
                            case "monster_count": this.monster_count = (int)war.Value; break;
                            case "copy_leader_ratio_enabled": this.copy_leader_ratio_enabled = (bool)war.Value; break;
                            case "bypass_final_confirmation": this.bypass_final_confirmation = (bool)war.Value; break;
                            case "war_comission_required": this.war_commission_required = (bool)war.Value; break;
                            case "war_group_type": this.war_group_type = war.Value.ToString(); break;
                            case "attacker":
                                this.attacker = new Objects.Rally.Attacker();

                                foreach (KeyValuePair<string, JToken> att in (JObject)war.Value)
                                {
                                    switch (att.Key)
                                    {
                                        case "alliance": this.attacker.AllianceFullName = att.Value.ToString(); break;
                                        case "alliance_tag": this.attacker.AllianceTag = att.Value.ToString(); break;
                                        case "empire": this.attacker.UserName = att.Value.ToString(); break;
                                        case "home_province_id": this.attacker.HomeProvinceId = (int)att.Value; break;
                                        case "city": this.attacker.CityName = att.Value.ToString(); break;
                                        case "city_id": this.attacker.CityId = (int)att.Value; break;
                                        case "province_id": break;
                                        case "tile":
                                            this.attacker.Tile = new Point3D();
                                            foreach (KeyValuePair<string, JToken> tile in (JObject)att.Value)
                                            {
                                                switch (tile.Key)
                                                {
                                                    case "province_id": this.attacker.Tile.Z = (int)tile.Value; break;
                                                    case "chunk_id":
                                                        this.attacker.Tile.X += Utilities.ChunkId2XCoordinate((int)tile.Value);
                                                        this.attacker.Tile.Y += Utilities.ChunkId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "tile_id":
                                                        this.attacker.Tile.X += Utilities.TileId2XCoordinate((int)tile.Value);
                                                        this.attacker.Tile.Y += Utilities.TileId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "overlay": this.attacker.TileOverlay = (int)tile.Value; break;
                                                    case "rank": this.attacker.TileRank = (int)tile.Value; break;
                                                    default: this.Error = true; break;
                                                }
                                            }
                                            break;
                                        case "rank": this.attacker.Rank = (int)att.Value; break;
                                        case "vip": this.attacker.VIPLevel = (int)att.Value; break;
                                        case "user_id": this.attacker.UserId = (int)att.Value; break;
                                        case "empire_id": this.attacker.EmpireId = (int)att.Value; break;
                                        case "army_id": this.attacker.ArmyId = (int)att.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
                            case "defender":
                                this.defender = new Objects.Rally.Defender();

                                foreach (KeyValuePair<string, JToken> def in (JObject)war.Value)
                                {
                                    switch (def.Key)
                                    {
                                        case "alliance": this.defender.AllianceFullName = def.Value.ToString(); break;
                                        case "alliance_tag": this.defender.AllianceTag = def.Value.ToString(); break;
                                        case "rank": this.defender.Rank = (int)def.Value; break;
                                        case "vip": this.defender.VIPLevel = (int)def.Value; break;
                                        case "empire": this.defender.UserName = def.Value.ToString(); break;
                                        case "user_id": this.defender.UserId = (int)def.Value; break;
                                        case "empire_id": this.defender.EmpireId = (int)def.Value; break;
                                        case "city": this.defender.CityName = def.Value.ToString(); break;
                                        case "city_id": this.defender.CityId = (int)def.Value; break;
                                        case "province_id": break;
                                        case "tile":
                                            this.defender.Tile = new Point3D();
                                            foreach (KeyValuePair<string, JToken> tile in (JObject)def.Value)
                                            {
                                                switch (tile.Key)
                                                {
                                                    case "province_id": this.defender.Tile.Z = (int)tile.Value; break;
                                                    case "chunk_id":
                                                        this.defender.Tile.X += Utilities.ChunkId2XCoordinate((int)tile.Value);
                                                        this.defender.Tile.Y += Utilities.ChunkId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "tile_id":
                                                        this.defender.Tile.X += Utilities.TileId2XCoordinate((int)tile.Value);
                                                        this.defender.Tile.Y += Utilities.TileId2YCoordinate((int)tile.Value);
                                                        break;
                                                    case "wonder_id": this.defender.TileControlPointId = (int)tile.Value; break;
                                                    case "overlay": this.defender.TileOverlay = (int)tile.Value; break;
                                                    default: this.Error = true; break;
                                                }
                                            }
                                            break;
                                        case "wonder_id": this.defender.ControlPointId = (int)def.Value; break;
                                        case "wonder_alliance_id": this.defender.ControlPointAllianceId = (int)def.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
                            case "slots":
                                this.slots = new List<Objects.Rally.RallySlot>();

                                foreach (JObject s in war.Value)
                                {
                                    Objects.Rally.RallySlot slot = new Objects.Rally.RallySlot();

                                    foreach (KeyValuePair<string, JToken> kvp in s)
                                    {
                                        switch (kvp.Key)
                                        {
                                            case "war_key": slot.RallyKey = kvp.Value.ToString(); break;
                                            case "alliance_id": slot.AllianceId = (int)kvp.Value; break;
                                            case "war_id": slot.RallyId = (int)kvp.Value; break;
                                            case "slot_id": slot.SlotId = (int)kvp.Value; break;
                                            case "status": slot.Status = (Objects.Rally.RallySlot.SlotStatus)(int)kvp.Value; break;
                                            case "empire": slot.UserName = kvp.Value.ToString(); break;
                                            case "user_id": slot.UserId = (int)kvp.Value; break;
                                            case "empire_id": slot.EmpireId = (int)kvp.Value; break;
                                            case "city_id": slot.CityId = (int)kvp.Value; break;
                                            case "army_id": slot.ArmyId = (int)kvp.Value; break;
                                            case "rank": slot.Rank = (int)kvp.Value; break;
                                            case "vip": slot.VIPLevel = (int) kvp.Value; break;
                                            case "alliance_tag": slot.AllianceTag = kvp.Value.ToString(); break;
                                            case "timer_length": slot.TimerLength = (int)kvp.Value; break;
                                            case "timer": slot.Timer = (int)kvp.Value; break;
                                            case "timer_start": slot.TimerStart = ((int)kvp.Value).ToDateTime(); break;
                                            case "timer_end": slot.TimerEnd = ((int)kvp.Value).ToDateTime(); break;
                                            case "troop_count": slot.TroopCount = (int)kvp.Value; break;
                                            case "gathered_troops":
                                                if (kvp.Value is JObject)
                                                {
                                                    slot.Troops = new List<KeyValuePair<string, int>>();
                                                    foreach (KeyValuePair<string, JToken> t in (JObject)kvp.Value)
                                                    {
                                                        slot.Troops.Add(new KeyValuePair<string, int>(t.Key, (int)t.Value));
                                                    }
                                                }
                                                break;
                                            case "gathered_units":
                                                if (kvp.Value is JObject)
                                                {
                                                    slot.TroopUnits = new List<KeyValuePair<string, int>>();
                                                    foreach (KeyValuePair<string, JToken> t in (JObject)kvp.Value)
                                                    {
                                                        slot.TroopUnits.Add(new KeyValuePair<string, int>(t.Key, (int)t.Value));
                                                    }
                                                }
                                                break;
                                            case "total_troop_count": slot.TotalTroopCount = (int)kvp.Value; break;
                                            case "total_troop_max": slot.TotalTroopMax = (int)kvp.Value; break;
                                            case "super_troop_count": slot.SuperTroopCount = (int)kvp.Value; break;
                                            case "super_troop_max": slot.SuperTroopMax = (int)kvp.Value; break;
                                            case "total_super_troop_count": slot.TotalSuperTroopCount = (int)kvp.Value; break;
                                            case "total_super_troop_max": slot.TotalSuperTroopMax = (int)kvp.Value; break;
                                            case "trap_count": slot.TrapCount = (int)kvp.Value; break;
                                            case "total_trap_count": slot.TotalTrapCount = (int)kvp.Value; break;
                                            case "total_trap_max": slot.TotalTrapMax = (int)kvp.Value; break;
                                            case "gathered_unittroops": this.Error = true; break; //TODO: figure out what this is
                                            default: this.Error = true; break;
                                        }
                                    }

                                    this.slots.Add(slot);
                                }
                                break;
                            case "shared_counts":
                                this.shared_counts = new Objects.Rally.SharedCounts();

                                foreach (KeyValuePair<string, JToken> kvp in (JObject)war.Value)
                                {
                                    switch (kvp.Key)
                                    {
                                        case "alliance_incoming_invites": this.shared_counts.AllianceIncomingInvites = (int)kvp.Value; break;
                                        case "alliance_war_attack": this.shared_counts.AllianceWarAttacks = (int)kvp.Value; break;
                                        case "alliance_war_defense": this.shared_counts.AllianceWarDefenses = (int)kvp.Value; break;
                                        case "alliance_ac_war_attack": this.shared_counts.AllianceACWarAttacks = (int)kvp.Value; break;
                                        case "alliance_ac_war_defense": this.shared_counts.AllianceACWarDefenses = (int)kvp.Value; break;
                                        case "alliance_group_war_attack": this.shared_counts.AllianceGroupWarAttacks = (int)kvp.Value; break;
                                        case "alliance_group_war_defense": this.shared_counts.AllianceGroupWarDefenses = (int)kvp.Value; break;
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
    }
}
