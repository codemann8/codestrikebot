using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages.Data
{
    public class Watchtower
    {
        public MarchType march_type { get; set; }
        public MarchState march_state { get; set; }
        public string march_id { get; set; }
        public DateTime timestamp { get; set; }
        public Point3D target_coordinate { get; set; }
        public int target_level { get; set; }
        public int target_city { get; set; }
        public string target_name { get; set; }
        public TargetType target_type { get; set; }
        public string player_name { get; set; }
        public int title { get; set; }
        public string alliance_tag { get; set; }
        public string alliance_name { get; set; }
        public int alliance_id { get; set; }
        public Point3D coordinate { get; set; }
        public DateTime start_time { get; set; }
        public DateTime dest_time { get; set; }
        public bool speedup_empire { get; set; }
        public string approx_total_units { get; set; }
        public string approx_total_trap_units { get; set; }
        public ValuelessUnitTypes valueless_unit_types { get; set; }
        public ValuelessTrapUnitTypes valueless_trap_unit_types { get; set; }
        public ApproxUnitTypes approx_unit_types { get; set; }
        public string hero_name { get; set; }
        public SpecificUnitTypes specific_unit_types { get; set; }
        public int hero_level { get; set; }
        public ResearchLevels research { get; set; }

        public int ActualTotalUnits { get; private set; }

        public bool Error { get; set; }

        public Watchtower(string march_id)
        {
            this.march_id = march_id;

            this.Error = false;
        }

        public Watchtower(JObject obj)
        {
            this.target_coordinate = new System.Web.UI.DataVisualization.Charting.Point3D();
            this.coordinate = new System.Web.UI.DataVisualization.Charting.Point3D();

            this.Error = false;
            
            foreach (KeyValuePair<string, JToken> w in obj)
            {
                try
                {
                    switch (w.Key.Replace("\"", ""))
                    {
                        case "march_type":
                            switch (w.Value.ToString().Replace("\"", ""))
                            {
                                case "attack":
                                    this.march_type = MarchType.Attack;
                                    break;
                                case "encamp":
                                    this.march_type = MarchType.Tile;
                                    break;
                                case "scout":
                                    this.march_type = MarchType.Scout;
                                    break;
                                default:
                                    this.march_type = MarchType.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "march_state":
                            switch (w.Value.ToString().Replace("\"", ""))
                            {
                                case "advancing":
                                    this.march_state = MarchState.Advancing;
                                    break;
                                default:
                                    this.march_state = MarchState.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "id":
                            this.march_id = w.Value.ToString();
                            break;
                        case "timestamp":
                            this.timestamp = Int32.Parse(w.Value.ToString().Replace("\"", "")).ToDateTime();
                            break;
                        case "target_province_id":
                            this.target_coordinate.Z = (int)w.Value;
                            break;
                        case "target_chunk_id":
                            this.target_coordinate.X += Utilities.ChunkId2XCoordinate((int)w.Value);
                            this.target_coordinate.Y += Utilities.ChunkId2YCoordinate((int)w.Value);
                            break;
                        case "target_tile_id":
                            this.target_coordinate.X += Utilities.TileId2XCoordinate((int)w.Value);
                            this.target_coordinate.Y += Utilities.TileId2YCoordinate((int)w.Value);
                            break;
                        case "target_level":
                            this.target_level = (int)w.Value;
                            break;
                        case "target_city":
                            this.target_city = (int)w.Value;
                            break;
                        case "target_name":
                            this.target_name = w.Value.ToString();
                            break;
                        case "target_type":
                            switch (w.Value.ToString().Replace("\"", ""))
                            {
                                case "city":
                                    this.target_type = TargetType.City;
                                    break;
                                case "encampment":
                                    this.target_type = TargetType.Encampment;
                                    break;
                                case "UNKNOWN":
                                    this.target_type = TargetType.GameUnknown;
                                    break;
                                default:
                                    this.target_type = TargetType.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "player_name":
                            this.player_name = w.Value.ToString();
                            break;
                        case "title":
                            this.title = (int)w.Value;
                            break;
                        case "province_id":
                            this.coordinate.Z = (int)w.Value;
                            break;
                        case "chunk_id":
                            this.coordinate.X += Utilities.ChunkId2XCoordinate((int)w.Value);
                            this.coordinate.Y += Utilities.ChunkId2YCoordinate((int)w.Value);
                            break;
                        case "tile_id":
                            this.coordinate.X += Utilities.TileId2XCoordinate((int)w.Value);
                            this.coordinate.Y += Utilities.TileId2YCoordinate((int)w.Value);
                            break;
                        case "start_time":
                            this.start_time = Int32.Parse(w.Value.ToString().Replace("\"", "")).ToDateTime();
                            break;
                        case "dest_time":
                            this.dest_time = Int32.Parse(w.Value.ToString().Replace("\"", "")).ToDateTime();
                            break;
                        case "speedup_empire":
                            this.speedup_empire = (bool)w.Value;
                            break;
                        case "alliance_tag":
                            this.alliance_tag = w.Value.ToString();
                            break;
                        case "alliance_name":
                            this.alliance_name = w.Value.ToString();
                            break;
                        case "alliance_id":
                            this.alliance_id = (int)w.Value;
                            break;
                        case "approx_total_units":
                            this.approx_total_units = w.Value.ToString();
                            break;
                        case "approx_total_trap_units":
                            this.approx_total_trap_units = w.Value.ToString();
                            break;
                        case "valueless_unit_types":
                            if (w.Value is JObject)
                            {
                                this.valueless_unit_types = new Watchtower.ValuelessUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key.Replace("\"", ""))
                                    {
                                        case "TYPE0":
                                            this.valueless_unit_types.TYPE0 = (bool)t.Value;
                                            break;
                                        case "TYPE1":
                                            this.valueless_unit_types.TYPE1 = (bool)t.Value;
                                            break;
                                        case "TYPE2":
                                            this.valueless_unit_types.TYPE2 = (bool)t.Value;
                                            break;
                                        case "TYPE3":
                                            this.valueless_unit_types.TYPE3 = (bool)t.Value;
                                            break;
                                        default:
                                            this.Error = true;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "valueless_trap_unit_types":
                            if (w.Value is JObject)
                            {
                                this.valueless_trap_unit_types = new Watchtower.ValuelessTrapUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key.Replace("\"", ""))
                                    {
                                        case "TYPE4":
                                            this.valueless_trap_unit_types.TYPE4 = (bool)t.Value;
                                            break;
                                        default:
                                            this.Error = true;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "approx_unit_types":
                            if (w.Value is JObject)
                            {
                                this.approx_unit_types = new Watchtower.ApproxUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key.Replace("\"", ""))
                                    {
                                        case "troop_hoplites":
                                            this.approx_unit_types.troop_hoplites = t.Value.ToString();
                                            break;
                                        case "troop_t5_normal_siege":
                                            this.approx_unit_types.troop_t5_normal_siege = t.Value.ToString();
                                            break;
                                        case "troop_t5_normal_cavalry":
                                            this.approx_unit_types.troop_t5_normal_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t5_normal_ranged":
                                            this.approx_unit_types.troop_t5_normal_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t5_normal_infantry":
                                            this.approx_unit_types.troop_t5_normal_infantry = t.Value.ToString();
                                            break;
                                        case "troop_t5_strategic_siege":
                                            this.approx_unit_types.troop_t5_strategic_siege = t.Value.ToString();
                                            break;
                                        case "troop_t5_strategic_cavalry":
                                            this.approx_unit_types.troop_t5_strategic_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t5_strategic_ranged":
                                            this.approx_unit_types.troop_t5_strategic_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t5_strategic_infantry":
                                            this.approx_unit_types.troop_t5_strategic_infantry = t.Value.ToString();
                                            break;
                                        case "troop_t5_wild_siege":
                                            this.approx_unit_types.troop_t5_wild_siege = t.Value.ToString();
                                            break;
                                        case "troop_t5_wild_cavalry":
                                            this.approx_unit_types.troop_t5_wild_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t5_wild_ranged":
                                            this.approx_unit_types.troop_t5_wild_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t5_wild_infantry":
                                            this.approx_unit_types.troop_t5_wild_infantry = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_inf_strategic_trap":
                                            this.approx_unit_types.defense_c_t5_anti_inf_strategic_trap = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_cav_strategic_trap":
                                            this.approx_unit_types.defense_c_t5_anti_cav_strategic_trap = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_ran_strategic_trap":
                                            this.approx_unit_types.defense_c_t5_anti_ran_strategic_trap = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_inf_wild_trap":
                                            this.approx_unit_types.defense_c_t5_anti_inf_wild_trap = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_cav_wild_trap":
                                            this.approx_unit_types.defense_c_t5_anti_cav_wild_trap = t.Value.ToString();
                                            break;
                                        case "defense_c_t5_anti_ran_wild_trap":
                                            this.approx_unit_types.defense_c_t5_anti_ran_wild_trap = t.Value.ToString();
                                            break;
                                        case "troop_t6_normal_siege":
                                            this.approx_unit_types.troop_t6_normal_siege = t.Value.ToString();
                                            break;
                                        case "troop_t6_normal_cavalry":
                                            this.approx_unit_types.troop_t6_normal_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t6_normal_ranged":
                                            this.approx_unit_types.troop_t6_normal_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t6_normal_infantry":
                                            this.approx_unit_types.troop_t6_normal_infantry = t.Value.ToString();
                                            break;
                                        case "troop_t6_strategic_siege":
                                            this.approx_unit_types.troop_t6_strategic_siege = t.Value.ToString();
                                            break;
                                        case "troop_t6_strategic_cavalry":
                                            this.approx_unit_types.troop_t6_strategic_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t6_strategic_ranged":
                                            this.approx_unit_types.troop_t6_strategic_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t6_strategic_infantry":
                                            this.approx_unit_types.troop_t6_strategic_infantry = t.Value.ToString();
                                            break;
                                        case "troop_t6_wild_siege":
                                            this.approx_unit_types.troop_t6_wild_siege = t.Value.ToString();
                                            break;
                                        case "troop_t6_wild_cavalry":
                                            this.approx_unit_types.troop_t6_wild_cavalry = t.Value.ToString();
                                            break;
                                        case "troop_t6_wild_ranged":
                                            this.approx_unit_types.troop_t6_wild_ranged = t.Value.ToString();
                                            break;
                                        case "troop_t6_wild_infantry":
                                            this.approx_unit_types.troop_t6_wild_infantry = t.Value.ToString();
                                            break;
                                        default:
                                            this.Error = true;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "hero_name":
                            this.hero_name = w.Value.ToString();
                            break;
                        case "specific_unit_types":
                            if (w.Value is JObject)
                            {
                                this.specific_unit_types = new Watchtower.SpecificUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    this.ActualTotalUnits += (int)t.Value;

                                    switch (t.Key.Replace("\"", ""))
                                    {
                                        case "troop_hoplites":
                                            this.specific_unit_types.troop_hoplites = (int)t.Value;
                                            break;
                                        case "troop_t5_normal_siege":
                                            this.specific_unit_types.troop_t5_normal_siege = (int)t.Value;
                                            break;
                                        case "troop_t5_normal_cavalry":
                                            this.specific_unit_types.troop_t5_normal_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t5_normal_ranged":
                                            this.specific_unit_types.troop_t5_normal_ranged = (int)t.Value;
                                            break;
                                        case "troop_t5_normal_infantry":
                                            this.specific_unit_types.troop_t5_normal_infantry = (int)t.Value;
                                            break;
                                        case "troop_t5_strategic_siege":
                                            this.specific_unit_types.troop_t5_strategic_siege = (int)t.Value;
                                            break;
                                        case "troop_t5_strategic_cavalry":
                                            this.specific_unit_types.troop_t5_strategic_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t5_strategic_ranged":
                                            this.specific_unit_types.troop_t5_strategic_ranged = (int)t.Value;
                                            break;
                                        case "troop_t5_strategic_infantry":
                                            this.specific_unit_types.troop_t5_strategic_infantry = (int)t.Value;
                                            break;
                                        case "troop_t5_wild_siege":
                                            this.specific_unit_types.troop_t5_wild_siege = (int)t.Value;
                                            break;
                                        case "troop_t5_wild_cavalry":
                                            this.specific_unit_types.troop_t5_wild_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t5_wild_ranged":
                                            this.specific_unit_types.troop_t5_wild_ranged = (int)t.Value;
                                            break;
                                        case "troop_t5_wild_infantry":
                                            this.specific_unit_types.troop_t5_wild_infantry = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_inf_strategic_trap":
                                            this.specific_unit_types.defense_c_t5_anti_inf_strategic_trap = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_cav_strategic_trap":
                                            this.specific_unit_types.defense_c_t5_anti_cav_strategic_trap = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_ran_strategic_trap":
                                            this.specific_unit_types.defense_c_t5_anti_ran_strategic_trap = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_inf_wild_trap":
                                            this.specific_unit_types.defense_c_t5_anti_inf_wild_trap = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_cav_wild_trap":
                                            this.specific_unit_types.defense_c_t5_anti_cav_wild_trap = (int)t.Value;
                                            break;
                                        case "defense_c_t5_anti_ran_wild_trap":
                                            this.specific_unit_types.defense_c_t5_anti_ran_wild_trap = (int)t.Value;
                                            break;
                                        case "troop_t6_normal_siege":
                                            this.specific_unit_types.troop_t6_normal_siege = (int)t.Value;
                                            break;
                                        case "troop_t6_normal_cavalry":
                                            this.specific_unit_types.troop_t6_normal_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t6_normal_ranged":
                                            this.specific_unit_types.troop_t6_normal_ranged = (int)t.Value;
                                            break;
                                        case "troop_t6_normal_infantry":
                                            this.specific_unit_types.troop_t6_normal_infantry = (int)t.Value;
                                            break;
                                        case "troop_t6_strategic_siege":
                                            this.specific_unit_types.troop_t6_strategic_siege = (int)t.Value;
                                            break;
                                        case "troop_t6_strategic_cavalry":
                                            this.specific_unit_types.troop_t6_strategic_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t6_strategic_ranged":
                                            this.specific_unit_types.troop_t6_strategic_ranged = (int)t.Value;
                                            break;
                                        case "troop_t6_strategic_infantry":
                                            this.specific_unit_types.troop_t6_strategic_infantry = (int)t.Value;
                                            break;
                                        case "troop_t6_wild_siege":
                                            this.specific_unit_types.troop_t6_wild_siege = (int)t.Value;
                                            break;
                                        case "troop_t6_wild_cavalry":
                                            this.specific_unit_types.troop_t6_wild_cavalry = (int)t.Value;
                                            break;
                                        case "troop_t6_wild_ranged":
                                            this.specific_unit_types.troop_t6_wild_ranged = (int)t.Value;
                                            break;
                                        case "troop_t6_wild_infantry":
                                            this.specific_unit_types.troop_t6_wild_infantry = (int)t.Value;
                                            break;
                                        default:
                                            this.Error = true;
                                            break;
                                    }
                                }
                            }
                            break;
                        case "hero_level":
                            this.hero_level = (int)w.Value;
                            break;
                        case "research":
                            if (w.Value is JObject)
                            {
                                this.research = new Watchtower.ResearchLevels();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key.Replace("\"", ""))
                                    {
                                        case "research_c_infatt":
                                            this.research.research_c_infatt = (int)t.Value;
                                            break;
                                        case "research_c_ranatt":
                                            this.research.research_c_ranatt = (int)t.Value;
                                            break;
                                        case "research_c_cavatt":
                                            this.research.research_c_cavatt = (int)t.Value;
                                            break;
                                        case "research_c_infdef":
                                            this.research.research_c_infdef = (int)t.Value;
                                            break;
                                        case "research_c_randef":
                                            this.research.research_c_randef = (int)t.Value;
                                            break;
                                        case "research_c_cavdef":
                                            this.research.research_c_cavdef = (int)t.Value;
                                            break;
                                        case "research_c_siege_attack":
                                            this.research.research_c_siege_attack = (int)t.Value;
                                            break;
                                        case "research_c_siege_defense":
                                            this.research.research_c_siege_defense = (int)t.Value;
                                            break;
                                        case "research_c_troop_health":
                                            this.research.research_c_troop_health = (int)t.Value;
                                            break;
                                        case "research_c_troop_defense":
                                            this.research.research_c_troop_defense = (int)t.Value;
                                            break;
                                        case "research_c_strategic_infatt":
                                            this.research.research_c_strategic_infatt = (int)t.Value;
                                            break;
                                        case "research_c_strategic_ranatt":
                                            this.research.research_c_strategic_ranatt = (int)t.Value;
                                            break;
                                        case "research_c_strategic_cavatt":
                                            this.research.research_c_strategic_cavatt = (int)t.Value;
                                            break;
                                        case "research_c_strategic_infdef":
                                            this.research.research_c_strategic_infdef = (int)t.Value;
                                            break;
                                        case "research_c_strategic_randef":
                                            this.research.research_c_strategic_randef = (int)t.Value;
                                            break;
                                        case "research_c_strategic_cavdef":
                                            this.research.research_c_strategic_cavdef = (int)t.Value;
                                            break;
                                        case "research_c_strategic_troop_health":
                                            this.research.research_c_strategic_troop_health = (int)t.Value;
                                            break;
                                        case "research_c_strategic_troop_defense":
                                            this.research.research_c_strategic_troop_defense = (int)t.Value;
                                            break;
                                        case "research_c_trap_attack2":
                                            this.research.research_c_trap_attack2 = (int)t.Value;
                                            break;
                                        case "research_c_trap_defense2":
                                            this.research.research_c_trap_defense2 = (int)t.Value;
                                            break;
                                        case "research_c_troop_attack2":
                                            this.research.research_c_troop_attack2 = (int)t.Value;
                                            break;
                                        case "research_c_troop_defense2":
                                            this.research.research_c_troop_defense2 = (int)t.Value;
                                            break;
                                        default:
                                            this.Error = true;
                                            break;
                                    }
                                }
                            }
                            break;
                        default:
                            this.Error = true;
                            break;
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

        public class ValuelessUnitTypes
        {
            public bool TYPE3 { get; set; } //art
            public bool TYPE2 { get; set; } //arm
            public bool TYPE1 { get; set; } //tact
            public bool TYPE0 { get; set; } //inf
        }

        public class ValuelessTrapUnitTypes
        {
            public bool TYPE4 { get; set; } // defense_c_t5_anti_all_wild_trap //all wild //also, all strategic
        }

        public class ApproxUnitTypes
        {
            public string troop_hoplites { get; set; } //machine gunner//reg inf t2

            //t5
            public string troop_t5_normal_siege { get; set; }
            public string troop_t5_normal_cavalry { get; set; }
            public string troop_t5_normal_ranged { get; set; }
            public string troop_t5_normal_infantry { get; set; }
            public string troop_t5_strategic_siege { get; set; }
            public string troop_t5_strategic_cavalry { get; set; }
            public string troop_t5_strategic_ranged { get; set; }
            public string troop_t5_strategic_infantry { get; set; }
            public string troop_t5_wild_siege { get; set; }
            public string troop_t5_wild_cavalry { get; set; }
            public string troop_t5_wild_ranged { get; set; }
            public string troop_t5_wild_infantry { get; set; }

            public string defense_c_t5_anti_inf_strategic_trap { get; set; }
            public string defense_c_t5_anti_cav_strategic_trap { get; set; }
            public string defense_c_t5_anti_ran_strategic_trap { get; set; }
            public string defense_c_t5_anti_inf_wild_trap { get; set; }
            public string defense_c_t5_anti_cav_wild_trap { get; set; }
            public string defense_c_t5_anti_ran_wild_trap { get; set; }

            //t6
            public string troop_t6_normal_siege { get; set; }
            public string troop_t6_normal_cavalry { get; set; }
            public string troop_t6_normal_ranged { get; set; }
            public string troop_t6_normal_infantry { get; set; }
            public string troop_t6_strategic_siege { get; set; }
            public string troop_t6_strategic_cavalry { get; set; }
            public string troop_t6_strategic_ranged { get; set; }
            public string troop_t6_strategic_infantry { get; set; }
            public string troop_t6_wild_siege { get; set; }
            public string troop_t6_wild_cavalry { get; set; }
            public string troop_t6_wild_ranged { get; set; }
            public string troop_t6_wild_infantry { get; set; }
        }

        public class SpecificUnitTypes
        {
            public int troop_hoplites { get; set; }

            //t5
            public int troop_t5_normal_siege { get; set; }
            public int troop_t5_normal_cavalry { get; set; }
            public int troop_t5_normal_ranged { get; set; }
            public int troop_t5_normal_infantry { get; set; }
            public int troop_t5_strategic_siege { get; set; }
            public int troop_t5_strategic_cavalry { get; set; }
            public int troop_t5_strategic_ranged { get; set; }
            public int troop_t5_strategic_infantry { get; set; }
            public int troop_t5_wild_siege { get; set; }
            public int troop_t5_wild_cavalry { get; set; }
            public int troop_t5_wild_ranged { get; set; }
            public int troop_t5_wild_infantry { get; set; }

            public int defense_c_t5_anti_inf_strategic_trap { get; set; }
            public int defense_c_t5_anti_cav_strategic_trap { get; set; }
            public int defense_c_t5_anti_ran_strategic_trap { get; set; }
            public int defense_c_t5_anti_inf_wild_trap { get; set; }
            public int defense_c_t5_anti_cav_wild_trap { get; set; }
            public int defense_c_t5_anti_ran_wild_trap { get; set; }

            //t6
            public int troop_t6_normal_siege { get; set; }
            public int troop_t6_normal_cavalry { get; set; }
            public int troop_t6_normal_ranged { get; set; }
            public int troop_t6_normal_infantry { get; set; }
            public int troop_t6_strategic_siege { get; set; }
            public int troop_t6_strategic_cavalry { get; set; }
            public int troop_t6_strategic_ranged { get; set; }
            public int troop_t6_strategic_infantry { get; set; }
            public int troop_t6_wild_siege { get; set; }
            public int troop_t6_wild_cavalry { get; set; }
            public int troop_t6_wild_ranged { get; set; }
            public int troop_t6_wild_infantry { get; set; }
        }

        public class ResearchLevels
        {
            public int research_c_infatt { get; set; }
            public int research_c_ranatt { get; set; }
            public int research_c_cavatt { get; set; }
            public int research_c_infdef { get; set; }
            public int research_c_randef { get; set; }
            public int research_c_cavdef { get; set; }
            public int research_c_siege_attack { get; set; }
            public int research_c_siege_defense { get; set; }
            public int research_c_troop_health { get; set; }
            public int research_c_troop_defense { get; set; }
            public int research_c_strategic_infatt { get; set; }
            public int research_c_strategic_ranatt { get; set; }
            public int research_c_strategic_cavatt { get; set; }
            public int research_c_strategic_infdef { get; set; }
            public int research_c_strategic_randef { get; set; }
            public int research_c_strategic_cavdef { get; set; }
            public int research_c_strategic_troop_health { get; set; }
            public int research_c_strategic_troop_defense { get; set; }
            public int research_c_trap_attack2 { get; set; }
            public int research_c_trap_defense2 { get; set; }
            public int research_c_troop_attack2 { get; set; }
            public int research_c_troop_defense2 { get; set; }
        }
    }
}
