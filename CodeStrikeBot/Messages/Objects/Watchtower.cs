using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages.Objects
{
    public class Watchtower
    {
        public March.MarchType march_type { get; set; }
        public March.MarchState march_state { get; set; }
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
                    switch (w.Key)
                    {
                        case "march_type":
                            switch (w.Value.ToString())
                            {
                                case "attack": this.march_type = March.MarchType.Attack; break;
                                case "encamp": this.march_type = March.MarchType.Tile; break;
                                case "scout": this.march_type = March.MarchType.Scout; break;
                                case "trade": this.march_type = March.MarchType.Trade; break;
                                case "reinforce": this.march_type = March.MarchType.Reinforcement; break;
                                default:
                                    this.march_type = March.MarchType.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "march_state":
                            switch (w.Value.ToString())
                            {
                                case "advancing": this.march_state = March.MarchState.Advancing; break;
                                default:
                                    this.march_state = March.MarchState.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "id": this.march_id = w.Value.ToString(); break;
                        case "timestamp": this.timestamp = Int32.Parse(w.Value.ToString()).ToDateTime(); break;
                        case "target_province_id": this.target_coordinate.Z = (int)w.Value; break;
                        case "target_chunk_id":
                            this.target_coordinate.X += Utilities.ChunkId2XCoordinate((int)w.Value);
                            this.target_coordinate.Y += Utilities.ChunkId2YCoordinate((int)w.Value);
                            break;
                        case "target_tile_id":
                            this.target_coordinate.X += Utilities.TileId2XCoordinate((int)w.Value);
                            this.target_coordinate.Y += Utilities.TileId2YCoordinate((int)w.Value);
                            break;
                        case "target_level": this.target_level = (int)w.Value; break;
                        case "target_city": this.target_city = (int)w.Value; break;
                        case "target_name": this.target_name = w.Value.ToString(); break;
                        case "target_type":
                            switch (w.Value.ToString())
                            {
                                case "city": this.target_type = TargetType.City; break;
                                case "encampment": this.target_type = TargetType.Encampment; break;
                                case "UNKNOWN": this.target_type = TargetType.GameUnknown; break;
                                default:
                                    this.target_type = TargetType.Unknown;
                                    this.Error = true;
                                    break;
                            }
                            break;
                        case "player_name": this.player_name = w.Value.ToString(); break;
                        case "title": this.title = (int)w.Value; break;
                        case "province_id":  this.coordinate.Z = (int)w.Value; break;
                        case "chunk_id":
                            this.coordinate.X += Utilities.ChunkId2XCoordinate((int)w.Value);
                            this.coordinate.Y += Utilities.ChunkId2YCoordinate((int)w.Value);
                            break;
                        case "tile_id":
                            this.coordinate.X += Utilities.TileId2XCoordinate((int)w.Value);
                            this.coordinate.Y += Utilities.TileId2YCoordinate((int)w.Value);
                            break;
                        case "start_time": this.start_time = Int32.Parse(w.Value.ToString()).ToDateTime(); break;
                        case "dest_time": this.dest_time = Int32.Parse(w.Value.ToString()).ToDateTime(); break;
                        case "speedup_empire": this.speedup_empire = (bool)w.Value; break;
                        case "alliance_tag": this.alliance_tag = w.Value.ToString(); break;
                        case "alliance_name": this.alliance_name = w.Value.ToString(); break;
                        case "alliance_id": this.alliance_id = (int)w.Value; break;
                        case "hero_name": this.hero_name = w.Value.ToString(); break;
                        case "hero_level": this.hero_level = (int)w.Value; break;
                        case "approx_total_units": this.approx_total_units = w.Value.ToString(); break;
                        case "approx_total_trap_units": this.approx_total_trap_units = w.Value.ToString(); break;
                        case "valueless_unit_types":
                            if (w.Value is JObject)
                            {
                                this.valueless_unit_types = new Watchtower.ValuelessUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key)
                                    {
                                        case "TYPE0": this.valueless_unit_types.TYPE0 = (bool)t.Value; break;
                                        case "TYPE1": this.valueless_unit_types.TYPE1 = (bool)t.Value; break;
                                        case "TYPE2": this.valueless_unit_types.TYPE2 = (bool)t.Value; break;
                                        case "TYPE3": this.valueless_unit_types.TYPE3 = (bool)t.Value; break;
                                        default: this.Error = true; break;
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
                                    switch (t.Key)
                                    {
                                        case "TYPE4": this.valueless_trap_unit_types.TYPE4 = (bool)t.Value; break;
                                        default: this.Error = true; break;
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
                                    switch (t.Key)
                                    {
                                        //TROOPS
                                        //t1
                                        case "troop_battering_ram": this.approx_unit_types.troop_battering_ram = t.Value.ToString(); break;
                                        case "troop_outriders": this.approx_unit_types.troop_outriders = t.Value.ToString(); break;
                                        case "troop_slingers": this.approx_unit_types.troop_slingers = t.Value.ToString(); break;
                                        case "troop_swordsmen": this.approx_unit_types.troop_swordsmen = t.Value.ToString(); break;
                                        case "troop_trojanhorse": this.approx_unit_types.troop_trojanhorse = t.Value.ToString(); break;
                                        case "troop_chariots": this.approx_unit_types.troop_chariots = t.Value.ToString(); break;
                                        case "troop_hunters": this.approx_unit_types.troop_hunters = t.Value.ToString(); break;
                                        case "troop_spearman": this.approx_unit_types.troop_spearman = t.Value.ToString(); break;
                                        case "troop_ballistaravager": this.approx_unit_types.troop_ballistaravager = t.Value.ToString(); break;
                                        case "troop_raiders": this.approx_unit_types.troop_raiders = t.Value.ToString(); break;
                                        case "troop_archers": this.approx_unit_types.troop_archers = t.Value.ToString(); break;
                                        case "troop_barbarians": this.approx_unit_types.troop_barbarians = t.Value.ToString(); break;

                                        //t2
                                        case "troop_ballista": this.approx_unit_types.troop_ballista = t.Value.ToString(); break;
                                        case "troop_light_cavalry": this.approx_unit_types.troop_light_cavalry = t.Value.ToString(); break;
                                        case "troop_skirmish_archers": this.approx_unit_types.troop_skirmish_archers = t.Value.ToString(); break;
                                        case "troop_hoplites": this.approx_unit_types.troop_hoplites = t.Value.ToString(); break;
                                        case "troop_speartower": this.approx_unit_types.troop_speartower = t.Value.ToString(); break;
                                        case "troop_scythedchariots": this.approx_unit_types.troop_scythedchariots = t.Value.ToString(); break;
                                        case "troop_rangers": this.approx_unit_types.troop_rangers = t.Value.ToString(); break;
                                        case "troop_peltasts": this.approx_unit_types.troop_peltasts = t.Value.ToString(); break;
                                        case "troop_dragonfirecannon": this.approx_unit_types.troop_dragonfirecannon = t.Value.ToString(); break;
                                        case "troop_marauders": this.approx_unit_types.troop_marauders = t.Value.ToString(); break;
                                        case "troop_axethrowers": this.approx_unit_types.troop_axethrowers = t.Value.ToString(); break;
                                        case "troop_axeman": this.approx_unit_types.troop_axeman = t.Value.ToString(); break;

                                        //t3
                                        case "troop_siegetower": this.approx_unit_types.troop_siegetower = t.Value.ToString(); break;
                                        case "troop_companion_cavalry": this.approx_unit_types.troop_companion_cavalry = t.Value.ToString(); break;
                                        case "troop_guardians": this.approx_unit_types.troop_guardians = t.Value.ToString(); break;
                                        case "troop_armored_pikeman": this.approx_unit_types.troop_armored_pikeman = t.Value.ToString(); break;
                                        case "troop_flamingtrebuchet": this.approx_unit_types.troop_flamingtrebuchet = t.Value.ToString(); break;
                                        case "troop_lancers": this.approx_unit_types.troop_lancers = t.Value.ToString(); break;
                                        case "troop_stalkers": this.approx_unit_types.troop_stalkers = t.Value.ToString(); break;
                                        case "troop_phalangite": this.approx_unit_types.troop_phalangite = t.Value.ToString(); break;
                                        case "troop_warram": this.approx_unit_types.troop_warram = t.Value.ToString(); break;
                                        case "troop_amazons": this.approx_unit_types.troop_amazons = t.Value.ToString(); break;
                                        case "troop_reavers": this.approx_unit_types.troop_reavers = t.Value.ToString(); break;
                                        case "troop_berserkers": this.approx_unit_types.troop_berserkers = t.Value.ToString(); break;

                                        //t4
                                        case "troop_onager": this.approx_unit_types.troop_onager = t.Value.ToString(); break;
                                        case "troop_war_elephants": this.approx_unit_types.troop_war_elephants = t.Value.ToString(); break;
                                        case "troop_marksmen": this.approx_unit_types.troop_marksmen = t.Value.ToString(); break;
                                        case "troop_immortals": this.approx_unit_types.troop_immortals = t.Value.ToString(); break;
                                        case "troop_barricadedrill": this.approx_unit_types.troop_barricadedrill = t.Value.ToString(); break;
                                        case "troop_cataphracts": this.approx_unit_types.troop_cataphracts = t.Value.ToString(); break;
                                        case "troop_dianas": this.approx_unit_types.troop_dianas = t.Value.ToString(); break;
                                        case "troop_legionnaires": this.approx_unit_types.troop_legionnaires = t.Value.ToString(); break;
                                        case "troop_siegeelephant": this.approx_unit_types.troop_siegeelephant = t.Value.ToString(); break;
                                        case "troop_juggernauts": this.approx_unit_types.troop_juggernauts = t.Value.ToString(); break;
                                        case "troop_slayers": this.approx_unit_types.troop_slayers = t.Value.ToString(); break;
                                        case "troop_valkyries": this.approx_unit_types.troop_valkyries = t.Value.ToString(); break;

                                        //t5
                                        case "troop_t5_normal_siege": this.approx_unit_types.troop_t5_normal_siege = t.Value.ToString(); break;
                                        case "troop_t5_normal_cavalry": this.approx_unit_types.troop_t5_normal_cavalry = t.Value.ToString(); break;
                                        case "troop_t5_normal_ranged": this.approx_unit_types.troop_t5_normal_ranged = t.Value.ToString(); break;
                                        case "troop_t5_normal_infantry": this.approx_unit_types.troop_t5_normal_infantry = t.Value.ToString(); break;
                                        case "troop_t5_strategic_siege": this.approx_unit_types.troop_t5_strategic_siege = t.Value.ToString(); break;
                                        case "troop_t5_strategic_cavalry": this.approx_unit_types.troop_t5_strategic_cavalry = t.Value.ToString(); break;
                                        case "troop_t5_strategic_ranged": this.approx_unit_types.troop_t5_strategic_ranged = t.Value.ToString(); break;
                                        case "troop_t5_strategic_infantry": this.approx_unit_types.troop_t5_strategic_infantry = t.Value.ToString(); break;
                                        case "troop_t5_wild_siege": this.approx_unit_types.troop_t5_wild_siege = t.Value.ToString(); break;
                                        case "troop_t5_wild_cavalry": this.approx_unit_types.troop_t5_wild_cavalry = t.Value.ToString(); break;
                                        case "troop_t5_wild_ranged": this.approx_unit_types.troop_t5_wild_ranged = t.Value.ToString(); break;
                                        case "troop_t5_wild_infantry": this.approx_unit_types.troop_t5_wild_infantry = t.Value.ToString(); break;

                                        //t6
                                        case "troop_t6_normal_siege": this.approx_unit_types.troop_t6_normal_siege = t.Value.ToString(); break;
                                        case "troop_t6_normal_cavalry": this.approx_unit_types.troop_t6_normal_cavalry = t.Value.ToString(); break;
                                        case "troop_t6_normal_ranged": this.approx_unit_types.troop_t6_normal_ranged = t.Value.ToString(); break;
                                        case "troop_t6_normal_infantry": this.approx_unit_types.troop_t6_normal_infantry = t.Value.ToString(); break;
                                        case "troop_t6_strategic_siege": this.approx_unit_types.troop_t6_strategic_siege = t.Value.ToString(); break;
                                        case "troop_t6_strategic_cavalry": this.approx_unit_types.troop_t6_strategic_cavalry = t.Value.ToString(); break;
                                        case "troop_t6_strategic_ranged": this.approx_unit_types.troop_t6_strategic_ranged = t.Value.ToString(); break;
                                        case "troop_t6_strategic_infantry": this.approx_unit_types.troop_t6_strategic_infantry = t.Value.ToString(); break;
                                        case "troop_t6_wild_siege": this.approx_unit_types.troop_t6_wild_siege = t.Value.ToString(); break;
                                        case "troop_t6_wild_cavalry": this.approx_unit_types.troop_t6_wild_cavalry = t.Value.ToString(); break;
                                        case "troop_t6_wild_ranged": this.approx_unit_types.troop_t6_wild_ranged = t.Value.ToString(); break;
                                        case "troop_t6_wild_infantry": this.approx_unit_types.troop_t6_wild_infantry = t.Value.ToString(); break;

                                        //TRAPS
                                        //t0
                                        case "defense_c_brick": this.approx_unit_types.defense_c_brick = t.Value.ToString(); break;
                                        case "defense_c_iron_bricks": this.approx_unit_types.defense_c_iron_bricks = t.Value.ToString(); break;
                                        case "defense_c_bonebricks": this.approx_unit_types.defense_c_bonebricks = t.Value.ToString(); break;

                                        //t1
                                        case "defense_c_tarteam": this.approx_unit_types.defense_c_tarteam = t.Value.ToString(); break;
                                        case "defense_c_spikes": this.approx_unit_types.defense_c_spikes = t.Value.ToString(); break;
                                        case "defense_c_archertower": this.approx_unit_types.defense_c_archertower = t.Value.ToString(); break;
                                        case "defense_c_rolling_wall": this.approx_unit_types.defense_c_rolling_wall = t.Value.ToString(); break;
                                        case "defense_c_pitfall": this.approx_unit_types.defense_c_pitfall = t.Value.ToString(); break;
                                        case "defense_c_longbow_tower": this.approx_unit_types.defense_c_longbow_tower = t.Value.ToString(); break;
                                        case "defense_c_flamebowtower": this.approx_unit_types.defense_c_flamebowtower = t.Value.ToString(); break;
                                        case "defense_c_wilddogs": this.approx_unit_types.defense_c_wilddogs = t.Value.ToString(); break;
                                        case "defense_c_poisonedspikes": this.approx_unit_types.defense_c_poisonedspikes = t.Value.ToString(); break;

                                        //t2
                                        case "defense_c_cannon": this.approx_unit_types.defense_c_cannon = t.Value.ToString(); break;
                                        case "defense_c_traps": this.approx_unit_types.defense_c_traps = t.Value.ToString(); break;
                                        case "defense_c_turret": this.approx_unit_types.defense_c_turret = t.Value.ToString(); break;
                                        case "defense_c_arrow_wall": this.approx_unit_types.defense_c_arrow_wall = t.Value.ToString(); break;
                                        case "defense_c_flaming_carts": this.approx_unit_types.defense_c_flaming_carts = t.Value.ToString(); break;
                                        case "defense_c_sentry_tower": this.approx_unit_types.defense_c_sentry_tower = t.Value.ToString(); break;
                                        case "defense_c_arrowlauncher": this.approx_unit_types.defense_c_arrowlauncher = t.Value.ToString(); break;
                                        case "defense_c_snakedrop": this.approx_unit_types.defense_c_snakedrop = t.Value.ToString(); break;
                                        case "defense_c_tartrap": this.approx_unit_types.defense_c_tartrap = t.Value.ToString(); break;

                                        //t3
                                        case "defense_c_caltrops": this.approx_unit_types.defense_c_caltrops = t.Value.ToString(); break;
                                        case "defense_c_catapults": this.approx_unit_types.defense_c_catapults = t.Value.ToString(); break;
                                        case "defense_c_bolders": this.approx_unit_types.defense_c_bolders = t.Value.ToString(); break;
                                        case "defense_c_pendulum": this.approx_unit_types.defense_c_pendulum = t.Value.ToString(); break;
                                        case "defense_c_mobile_tower": this.approx_unit_types.defense_c_mobile_tower = t.Value.ToString(); break;
                                        case "defense_c_poison_swamp": this.approx_unit_types.defense_c_poison_swamp = t.Value.ToString(); break;
                                        case "defense_c_dragonspitter": this.approx_unit_types.defense_c_dragonspitter = t.Value.ToString(); break;
                                        case "defense_c_crocodilepit": this.approx_unit_types.defense_c_crocodilepit = t.Value.ToString(); break;
                                        case "defense_c_flaminglog": this.approx_unit_types.defense_c_flaminglog = t.Value.ToString(); break;

                                        //t4
                                        case "defense_c_greekfire": this.approx_unit_types.defense_c_greekfire = t.Value.ToString(); break;
                                        case "defense_c_barriers": this.approx_unit_types.defense_c_barriers = t.Value.ToString(); break;
                                        case "defense_c_trebuchet": this.approx_unit_types.defense_c_trebuchet = t.Value.ToString(); break;
                                        case "defense_c_warbarricade": this.approx_unit_types.defense_c_warbarricade = t.Value.ToString(); break;
                                        case "defense_c_smokebomb": this.approx_unit_types.defense_c_smokebomb = t.Value.ToString(); break;
                                        case "defense_c_ballistatower": this.approx_unit_types.defense_c_ballistatower = t.Value.ToString(); break;
                                        case "defense_c_fireartillery": this.approx_unit_types.defense_c_fireartillery = t.Value.ToString(); break;
                                        case "defense_c_titantree": this.approx_unit_types.defense_c_titantree = t.Value.ToString(); break;
                                        case "defense_c_spinningaxes": this.approx_unit_types.defense_c_spinningaxes = t.Value.ToString(); break;

                                        //t5
                                        case "defense_c_t5_anti_inf_normal_trap": this.approx_unit_types.defense_c_t5_anti_inf_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_cav_normal_trap": this.approx_unit_types.defense_c_t5_anti_cav_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_ran_normal_trap": this.approx_unit_types.defense_c_t5_anti_ran_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_inf_strategic_trap": this.approx_unit_types.defense_c_t5_anti_inf_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_cav_strategic_trap": this.approx_unit_types.defense_c_t5_anti_cav_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_ran_strategic_trap": this.approx_unit_types.defense_c_t5_anti_ran_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_inf_wild_trap": this.approx_unit_types.defense_c_t5_anti_inf_wild_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_cav_wild_trap": this.approx_unit_types.defense_c_t5_anti_cav_wild_trap = t.Value.ToString(); break;
                                        case "defense_c_t5_anti_ran_wild_trap": this.approx_unit_types.defense_c_t5_anti_ran_wild_trap = t.Value.ToString(); break;

                                        //t6
                                        case "defense_c_t6_anti_inf_normal_trap": this.approx_unit_types.defense_c_t6_anti_inf_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_cav_normal_trap": this.approx_unit_types.defense_c_t6_anti_cav_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_ran_normal_trap": this.approx_unit_types.defense_c_t6_anti_ran_normal_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_inf_strategic_trap": this.approx_unit_types.defense_c_t6_anti_inf_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_cav_strategic_trap": this.approx_unit_types.defense_c_t6_anti_cav_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_ran_strategic_trap": this.approx_unit_types.defense_c_t6_anti_ran_strategic_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_inf_wild_trap": this.approx_unit_types.defense_c_t6_anti_inf_wild_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_cav_wild_trap": this.approx_unit_types.defense_c_t6_anti_cav_wild_trap = t.Value.ToString(); break;
                                        case "defense_c_t6_anti_ran_wild_trap": this.approx_unit_types.defense_c_t6_anti_ran_wild_trap = t.Value.ToString(); break;
                                        default: this.Error = true; break;
                                    }
                                }
                            }
                            break;
                        case "specific_unit_types":
                            if (w.Value is JObject)
                            {
                                this.specific_unit_types = new Watchtower.SpecificUnitTypes();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    this.ActualTotalUnits += (int)t.Value;

                                    switch (t.Key)
                                    {
                                        //TROOPS
                                        //t1
                                        case "troop_battering_ram": this.specific_unit_types.troop_battering_ram = (int)t.Value; break;
                                        case "troop_outriders": this.specific_unit_types.troop_outriders = (int)t.Value; break;
                                        case "troop_slingers": this.specific_unit_types.troop_slingers = (int)t.Value; break;
                                        case "troop_swordsmen": this.specific_unit_types.troop_swordsmen = (int)t.Value; break;
                                        case "troop_trojanhorse": this.specific_unit_types.troop_trojanhorse = (int)t.Value; break;
                                        case "troop_chariots": this.specific_unit_types.troop_chariots = (int)t.Value; break;
                                        case "troop_hunters": this.specific_unit_types.troop_hunters = (int)t.Value; break;
                                        case "troop_spearman": this.specific_unit_types.troop_spearman = (int)t.Value; break;
                                        case "troop_ballistaravager": this.specific_unit_types.troop_ballistaravager = (int)t.Value; break;
                                        case "troop_raiders": this.specific_unit_types.troop_raiders = (int)t.Value; break;
                                        case "troop_archers": this.specific_unit_types.troop_archers = (int)t.Value; break;
                                        case "troop_barbarians": this.specific_unit_types.troop_barbarians = (int)t.Value; break;

                                        //t2
                                        case "troop_ballista": this.specific_unit_types.troop_ballista = (int)t.Value; break;
                                        case "troop_light_cavalry": this.specific_unit_types.troop_light_cavalry = (int)t.Value; break;
                                        case "troop_skirmish_archers": this.specific_unit_types.troop_skirmish_archers = (int)t.Value; break;
                                        case "troop_hoplites": this.specific_unit_types.troop_hoplites = (int)t.Value; break;
                                        case "troop_speartower": this.specific_unit_types.troop_speartower = (int)t.Value; break;
                                        case "troop_scythedchariots": this.specific_unit_types.troop_scythedchariots = (int)t.Value; break;
                                        case "troop_rangers": this.specific_unit_types.troop_rangers = (int)t.Value; break;
                                        case "troop_peltasts": this.specific_unit_types.troop_peltasts = (int)t.Value; break;
                                        case "troop_dragonfirecannon": this.specific_unit_types.troop_dragonfirecannon = (int)t.Value; break;
                                        case "troop_marauders": this.specific_unit_types.troop_marauders = (int)t.Value; break;
                                        case "troop_axethrowers": this.specific_unit_types.troop_axethrowers = (int)t.Value; break;
                                        case "troop_axeman": this.specific_unit_types.troop_axeman = (int)t.Value; break;

                                        //t3
                                        case "troop_siegetower": this.specific_unit_types.troop_siegetower = (int)t.Value; break;
                                        case "troop_companion_cavalry": this.specific_unit_types.troop_companion_cavalry = (int)t.Value; break;
                                        case "troop_guardians": this.specific_unit_types.troop_guardians = (int)t.Value; break;
                                        case "troop_armored_pikeman": this.specific_unit_types.troop_armored_pikeman = (int)t.Value; break;
                                        case "troop_flamingtrebuchet": this.specific_unit_types.troop_flamingtrebuchet = (int)t.Value; break;
                                        case "troop_lancers": this.specific_unit_types.troop_lancers = (int)t.Value; break;
                                        case "troop_stalkers": this.specific_unit_types.troop_stalkers = (int)t.Value; break;
                                        case "troop_phalangite": this.specific_unit_types.troop_phalangite = (int)t.Value; break;
                                        case "troop_warram": this.specific_unit_types.troop_warram = (int)t.Value; break;
                                        case "troop_amazons": this.specific_unit_types.troop_amazons = (int)t.Value; break;
                                        case "troop_reavers": this.specific_unit_types.troop_reavers = (int)t.Value; break;
                                        case "troop_berserkers": this.specific_unit_types.troop_berserkers = (int)t.Value; break;

                                        //t4
                                        case "troop_onager": this.specific_unit_types.troop_onager = (int)t.Value; break;
                                        case "troop_war_elephants": this.specific_unit_types.troop_war_elephants = (int)t.Value; break;
                                        case "troop_marksmen": this.specific_unit_types.troop_marksmen = (int)t.Value; break;
                                        case "troop_immortals": this.specific_unit_types.troop_immortals = (int)t.Value; break;
                                        case "troop_barricadedrill": this.specific_unit_types.troop_barricadedrill = (int)t.Value; break;
                                        case "troop_cataphracts": this.specific_unit_types.troop_cataphracts = (int)t.Value; break;
                                        case "troop_dianas": this.specific_unit_types.troop_dianas = (int)t.Value; break;
                                        case "troop_legionnaires": this.specific_unit_types.troop_legionnaires = (int)t.Value; break;
                                        case "troop_siegeelephant": this.specific_unit_types.troop_siegeelephant = (int)t.Value; break;
                                        case "troop_juggernauts": this.specific_unit_types.troop_juggernauts = (int)t.Value; break;
                                        case "troop_slayers": this.specific_unit_types.troop_slayers = (int)t.Value; break;
                                        case "troop_valkyries": this.specific_unit_types.troop_valkyries = (int)t.Value; break;

                                        //t5
                                        case "troop_t5_normal_siege": this.specific_unit_types.troop_t5_normal_siege = (int)t.Value; break;
                                        case "troop_t5_normal_cavalry": this.specific_unit_types.troop_t5_normal_cavalry = (int)t.Value; break;
                                        case "troop_t5_normal_ranged": this.specific_unit_types.troop_t5_normal_ranged = (int)t.Value; break;
                                        case "troop_t5_normal_infantry": this.specific_unit_types.troop_t5_normal_infantry = (int)t.Value; break;
                                        case "troop_t5_strategic_siege": this.specific_unit_types.troop_t5_strategic_siege = (int)t.Value; break;
                                        case "troop_t5_strategic_cavalry": this.specific_unit_types.troop_t5_strategic_cavalry = (int)t.Value; break;
                                        case "troop_t5_strategic_ranged": this.specific_unit_types.troop_t5_strategic_ranged = (int)t.Value; break;
                                        case "troop_t5_strategic_infantry": this.specific_unit_types.troop_t5_strategic_infantry = (int)t.Value; break;
                                        case "troop_t5_wild_siege": this.specific_unit_types.troop_t5_wild_siege = (int)t.Value; break;
                                        case "troop_t5_wild_cavalry": this.specific_unit_types.troop_t5_wild_cavalry = (int)t.Value; break;
                                        case "troop_t5_wild_ranged": this.specific_unit_types.troop_t5_wild_ranged = (int)t.Value; break;
                                        case "troop_t5_wild_infantry": this.specific_unit_types.troop_t5_wild_infantry = (int)t.Value; break;
                                        
                                        //t6
                                        case "troop_t6_normal_siege": this.specific_unit_types.troop_t6_normal_siege = (int)t.Value; break;
                                        case "troop_t6_normal_cavalry": this.specific_unit_types.troop_t6_normal_cavalry = (int)t.Value; break;
                                        case "troop_t6_normal_ranged": this.specific_unit_types.troop_t6_normal_ranged = (int)t.Value; break;
                                        case "troop_t6_normal_infantry": this.specific_unit_types.troop_t6_normal_infantry = (int)t.Value; break;
                                        case "troop_t6_strategic_siege": this.specific_unit_types.troop_t6_strategic_siege = (int)t.Value; break;
                                        case "troop_t6_strategic_cavalry": this.specific_unit_types.troop_t6_strategic_cavalry = (int)t.Value; break;
                                        case "troop_t6_strategic_ranged": this.specific_unit_types.troop_t6_strategic_ranged = (int)t.Value; break;
                                        case "troop_t6_strategic_infantry": this.specific_unit_types.troop_t6_strategic_infantry = (int)t.Value; break;
                                        case "troop_t6_wild_siege": this.specific_unit_types.troop_t6_wild_siege = (int)t.Value; break;
                                        case "troop_t6_wild_cavalry": this.specific_unit_types.troop_t6_wild_cavalry = (int)t.Value; break;
                                        case "troop_t6_wild_ranged": this.specific_unit_types.troop_t6_wild_ranged = (int)t.Value; break;
                                        case "troop_t6_wild_infantry": this.specific_unit_types.troop_t6_wild_infantry = (int)t.Value; break;

                                        //TRAPS
                                        //t0
                                        case "defense_c_brick": this.specific_unit_types.defense_c_brick = (int)t.Value; break;
                                        case "defense_c_iron_bricks": this.specific_unit_types.defense_c_iron_bricks = (int)t.Value; break;
                                        case "defense_c_bonebricks": this.specific_unit_types.defense_c_bonebricks = (int)t.Value; break;

                                        //t1
                                        case "defense_c_tarteam": this.specific_unit_types.defense_c_tarteam = (int)t.Value; break;
                                        case "defense_c_spikes": this.specific_unit_types.defense_c_spikes = (int)t.Value; break;
                                        case "defense_c_archertower": this.specific_unit_types.defense_c_archertower = (int)t.Value; break;
                                        case "defense_c_rolling_wall": this.specific_unit_types.defense_c_rolling_wall = (int)t.Value; break;
                                        case "defense_c_pitfall": this.specific_unit_types.defense_c_pitfall = (int)t.Value; break;
                                        case "defense_c_longbow_tower": this.specific_unit_types.defense_c_longbow_tower = (int)t.Value; break;
                                        case "defense_c_flamebowtower": this.specific_unit_types.defense_c_flamebowtower = (int)t.Value; break;
                                        case "defense_c_wilddogs": this.specific_unit_types.defense_c_wilddogs = (int)t.Value; break;
                                        case "defense_c_poisonedspikes": this.specific_unit_types.defense_c_poisonedspikes = (int)t.Value; break;

                                        //t2
                                        case "defense_c_cannon": this.specific_unit_types.defense_c_cannon = (int)t.Value; break;
                                        case "defense_c_traps": this.specific_unit_types.defense_c_traps = (int)t.Value; break;
                                        case "defense_c_turret": this.specific_unit_types.defense_c_turret = (int)t.Value; break;
                                        case "defense_c_arrow_wall": this.specific_unit_types.defense_c_arrow_wall = (int)t.Value; break;
                                        case "defense_c_flaming_carts": this.specific_unit_types.defense_c_flaming_carts = (int)t.Value; break;
                                        case "defense_c_sentry_tower": this.specific_unit_types.defense_c_sentry_tower = (int)t.Value; break;
                                        case "defense_c_arrowlauncher": this.specific_unit_types.defense_c_arrowlauncher = (int)t.Value; break;
                                        case "defense_c_snakedrop": this.specific_unit_types.defense_c_snakedrop = (int)t.Value; break;
                                        case "defense_c_tartrap": this.specific_unit_types.defense_c_tartrap = (int)t.Value; break;

                                        //t3
                                        case "defense_c_caltrops": this.specific_unit_types.defense_c_caltrops = (int)t.Value; break;
                                        case "defense_c_catapults": this.specific_unit_types.defense_c_catapults = (int)t.Value; break;
                                        case "defense_c_bolders": this.specific_unit_types.defense_c_bolders = (int)t.Value; break;
                                        case "defense_c_pendulum": this.specific_unit_types.defense_c_pendulum = (int)t.Value; break;
                                        case "defense_c_mobile_tower": this.specific_unit_types.defense_c_mobile_tower = (int)t.Value; break;
                                        case "defense_c_poison_swamp": this.specific_unit_types.defense_c_poison_swamp = (int)t.Value; break;
                                        case "defense_c_dragonspitter": this.specific_unit_types.defense_c_dragonspitter = (int)t.Value; break;
                                        case "defense_c_crocodilepit": this.specific_unit_types.defense_c_crocodilepit = (int)t.Value; break;
                                        case "defense_c_flaminglog": this.specific_unit_types.defense_c_flaminglog = (int)t.Value; break;

                                        //t4
                                        case "defense_c_greekfire": this.specific_unit_types.defense_c_greekfire = (int)t.Value; break;
                                        case "defense_c_barriers": this.specific_unit_types.defense_c_barriers = (int)t.Value; break;
                                        case "defense_c_trebuchet": this.specific_unit_types.defense_c_trebuchet = (int)t.Value; break;
                                        case "defense_c_warbarricade": this.specific_unit_types.defense_c_warbarricade = (int)t.Value; break;
                                        case "defense_c_smokebomb": this.specific_unit_types.defense_c_smokebomb = (int)t.Value; break;
                                        case "defense_c_ballistatower": this.specific_unit_types.defense_c_ballistatower = (int)t.Value; break;
                                        case "defense_c_fireartillery": this.specific_unit_types.defense_c_fireartillery = (int)t.Value; break;
                                        case "defense_c_titantree": this.specific_unit_types.defense_c_titantree = (int)t.Value; break;
                                        case "defense_c_spinningaxes": this.specific_unit_types.defense_c_spinningaxes = (int)t.Value; break;

                                        //t5
                                        case "defense_c_t5_anti_inf_normal_trap": this.specific_unit_types.defense_c_t5_anti_inf_normal_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_cav_normal_trap": this.specific_unit_types.defense_c_t5_anti_cav_normal_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_ran_normal_trap": this.specific_unit_types.defense_c_t5_anti_ran_normal_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_inf_strategic_trap": this.specific_unit_types.defense_c_t5_anti_inf_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_cav_strategic_trap": this.specific_unit_types.defense_c_t5_anti_cav_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_ran_strategic_trap": this.specific_unit_types.defense_c_t5_anti_ran_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_inf_wild_trap": this.specific_unit_types.defense_c_t5_anti_inf_wild_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_cav_wild_trap": this.specific_unit_types.defense_c_t5_anti_cav_wild_trap = (int)t.Value; break;
                                        case "defense_c_t5_anti_ran_wild_trap": this.specific_unit_types.defense_c_t5_anti_ran_wild_trap = (int)t.Value; break;

                                        //t6
                                        case "defense_c_t6_anti_inf_normal_trap": this.specific_unit_types.defense_c_t6_anti_inf_normal_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_cav_normal_trap": this.specific_unit_types.defense_c_t6_anti_cav_normal_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_ran_normal_trap": this.specific_unit_types.defense_c_t6_anti_ran_normal_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_inf_strategic_trap": this.specific_unit_types.defense_c_t6_anti_inf_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_cav_strategic_trap": this.specific_unit_types.defense_c_t6_anti_cav_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_ran_strategic_trap": this.specific_unit_types.defense_c_t6_anti_ran_strategic_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_inf_wild_trap": this.specific_unit_types.defense_c_t6_anti_inf_wild_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_cav_wild_trap": this.specific_unit_types.defense_c_t6_anti_cav_wild_trap = (int)t.Value; break;
                                        case "defense_c_t6_anti_ran_wild_trap": this.specific_unit_types.defense_c_t6_anti_ran_wild_trap = (int)t.Value; break;
                                    
                                        default: this.Error = true; break;
                                    }
                                }
                            }
                            break;
                        case "research":
                            if (w.Value is JObject)
                            {
                                this.research = new Watchtower.ResearchLevels();

                                foreach (KeyValuePair<string, JToken> t in (JObject)w.Value)
                                {
                                    switch (t.Key)
                                    {
                                        case "research_c_infatt": this.research.research_c_infatt = (int)t.Value; break;
                                        case "research_c_ranatt": this.research.research_c_ranatt = (int)t.Value; break;
                                        case "research_c_cavatt": this.research.research_c_cavatt = (int)t.Value; break;
                                        case "research_c_infdef": this.research.research_c_infdef = (int)t.Value; break;
                                        case "research_c_randef": this.research.research_c_randef = (int)t.Value; break;
                                        case "research_c_cavdef": this.research.research_c_cavdef = (int)t.Value; break;
                                        case "research_c_siege_attack": this.research.research_c_siege_attack = (int)t.Value; break;
                                        case "research_c_siege_defense": this.research.research_c_siege_defense = (int)t.Value; break;
                                        case "research_c_troop_health": this.research.research_c_troop_health = (int)t.Value; break;
                                        case "research_c_troop_defense": this.research.research_c_troop_defense = (int)t.Value; break;
                                        case "research_c_strategic_infatt": this.research.research_c_strategic_infatt = (int)t.Value; break;
                                        case "research_c_strategic_ranatt": this.research.research_c_strategic_ranatt = (int)t.Value; break;
                                        case "research_c_strategic_cavatt": this.research.research_c_strategic_cavatt = (int)t.Value; break;
                                        case "research_c_strategic_infdef": this.research.research_c_strategic_infdef = (int)t.Value; break;
                                        case "research_c_strategic_randef": this.research.research_c_strategic_randef = (int)t.Value; break;
                                        case "research_c_strategic_cavdef": this.research.research_c_strategic_cavdef = (int)t.Value; break;
                                        case "research_c_strategic_troop_health": this.research.research_c_strategic_troop_health = (int)t.Value; break;
                                        case "research_c_strategic_troop_defense": this.research.research_c_strategic_troop_defense = (int)t.Value; break;
                                        case "research_c_trap_attack2": this.research.research_c_trap_attack2 = (int)t.Value; break;
                                        case "research_c_trap_defense2": this.research.research_c_trap_defense2 = (int)t.Value; break;
                                        case "research_c_troop_attack2": this.research.research_c_troop_attack2 = (int)t.Value; break;
                                        case "research_c_troop_defense2": this.research.research_c_troop_defense2 = (int)t.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                            }
                            break;
                        default: this.Error = true; break;
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
            //TROOPS
            //t1
            public string troop_battering_ram { get; set; } //mortar reg t1 art
            public string troop_outriders { get; set; } //patrol vehicle reg t1 arm
            public string troop_slingers { get; set; } //scout reg t1 tact
            public string troop_swordsmen { get; set; } //soldier reg t1 inf
            public string troop_trojanhorse { get; set; } //heavy ordnance adv t1 art
            public string troop_chariots { get; set; } //assault chopper adv t1 arm
            public string troop_hunters { get; set; } //armed guard adv t1 tact
            public string troop_spearman { get; set; } //counter terrorist adv t1 inf
            public string troop_ballistaravager { get; set; } //field gun merc t1 art
            public string troop_raiders { get; set; } //sentinel merc t1 arm
            public string troop_archers { get; set; } //marksmen merc t1 tact
            public string troop_barbarians { get; set; } //militia merc t1 inf

            //t2
            public string troop_ballista { get; set; } //missile launcher reg t2 art
            public string troop_light_cavalry { get; set; } //armored vehicle reg t2 arm
            public string troop_skirmish_archers { get; set; } //commando reg t2 tact
            public string troop_hoplites { get; set; } //machine gunner reg t2 inf
            public string troop_speartower { get; set; } //heavy artillery adv t2 art
            public string troop_scythedchariots { get; set; } //cobras adv t2 arm
            public string troop_rangers { get; set; } //ghosts adv t2 tact
            public string troop_peltasts { get; set; } //grenadier adv t2 inf
            public string troop_dragonfirecannon { get; set; } //assault cannon merc t2 art
            public string troop_marauders { get; set; } //goliath tanks merc t2 arm
            public string troop_axethrowers { get; set; } //recon merc t2 tact
            public string troop_axeman { get; set; } //watcher merc t2 inf

            //t3
            public string troop_siegetower { get; set; } //howitzers reg t3 art
            public string troop_companion_cavalry { get; set; } //LAV reg t3 arm
            public string troop_guardians { get; set; } //rangers reg t3 tact
            public string troop_armored_pikeman { get; set; } //rocket infantry reg t3 inf
            public string troop_flamingtrebuchet { get; set; } //ballistic missile adv t3 art
            public string troop_lancers { get; set; } //raptor jet adv t3 arm
            public string troop_stalkers { get; set; } //spec ops adv t3 tact
            public string troop_phalangite { get; set; } //patroller adv t3 inf
            public string troop_warram { get; set; } //cruise missile merc t3 art
            public string troop_amazons { get; set; } //reaper drone merc t3 arm
            public string troop_reavers { get; set; } //specialist merc t3 tact
            public string troop_berserkers { get; set; } //spectre merc t3 inf

            //t4
            public string troop_onager { get; set; } //rocket artillery reg t4 art
            public string troop_war_elephants { get; set; } //tank reg t4 arm
            public string troop_marksmen { get; set; } //delta reg t4 tact
            public string troop_immortals { get; set; } //demos reg t4 inf
            public string troop_barricadedrill { get; set; } //missile system adv t4 art
            public string troop_cataphracts { get; set; } //bombers adv t4 arm
            public string troop_dianas { get; set; } //paratroopers adv t4 tact
            public string troop_legionnaires { get; set; } //guardians adv t4 inf
            public string troop_siegeelephant { get; set; } //rocket storm merc t4 art
            public string troop_juggernauts { get; set; } //gunship merc t4 arm
            public string troop_slayers { get; set; } //covert ops merc t4 tact
            public string troop_valkyries { get; set; } //enforcer merc t4 inf

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

            //TRAPS
            //t0
            public string defense_c_brick { get; set; } //sand bag reg t0
            public string defense_c_iron_bricks { get; set; } //barriers adv t0
            public string defense_c_bonebricks { get; set; } //barricade merc t0

            //t1
            public string defense_c_tarteam { get; set; } //barbed wire reg t1 inf
            public string defense_c_spikes { get; set; } //tank trap reg t1 arm
            public string defense_c_archertower { get; set; } //trip wire reg t1 tact
            public string defense_c_rolling_wall { get; set; } //laser fence adv t1 inf
            public string defense_c_pitfall { get; set; } //emp barrier adv t1 arm
            public string defense_c_longbow_tower { get; set; } //ied explosive adv t1 tact
            public string defense_c_flamebowtower { get; set; } //persuader merc t1 inf
            public string defense_c_wilddogs { get; set; } //blockade merc t1 arm
            public string defense_c_poisonedspikes { get; set; } //nuclear mine merc t1 tact

            //t2
            public string defense_c_cannon { get; set; } //landmine reg t2 inf
            public string defense_c_traps { get; set; } //anti tank mine reg t2 arm
            public string defense_c_turret { get; set; } //electric fence reg t2 tact
            public string defense_c_arrow_wall { get; set; } //mounted gun adv t2 inf
            public string defense_c_flaming_carts { get; set; } //missile turret adv t2 arm
            public string defense_c_sentry_tower { get; set; } //spider mine adv t2 tact
            public string defense_c_arrowlauncher { get; set; } //auto turret merc t2 inf
            public string defense_c_snakedrop { get; set; } //missile battery merc t2 arm
            public string defense_c_tartrap { get; set; } //tank turret merc t2 tact

            //t3
            public string defense_c_caltrops { get; set; } //bunker reg t3 inf
            public string defense_c_catapults { get; set; } //emp mine //reg t3 arm
            public string defense_c_bolders { get; set; } //claymore reg t3 tact
            public string defense_c_pendulum { get; set; } //ir gun turret adv t3 inf
            public string defense_c_mobile_tower { get; set; } //laser cannon adv t3 tact
            public string defense_c_poison_swamp { get; set; } //ir missile turret adv t3 arm
            public string defense_c_dragonspitter { get; set; } //heavy mortar merc t3 inf
            public string defense_c_crocodilepit { get; set; } //sam turret merc t3 arm
            public string defense_c_flaminglog { get; set; } //remote sniper merc t3 tact

            //t4
            public string defense_c_greekfire { get; set; } //hydra reg t4 inf
            public string defense_c_barriers { get; set; } //javelin reg t4 arm
            public string defense_c_trebuchet { get; set; } //sniper tower reg t4 tact
            public string defense_c_warbarricade { get; set; } //defense drone adv t4 inf
            public string defense_c_smokebomb { get; set; } //aa cannon adv t4 arm
            public string defense_c_ballistatower { get; set; } //satellite system adv t4 tact
            public string defense_c_fireartillery { get; set; } //gunship drone merc t4 inf
            public string defense_c_titantree { get; set; } //heavy howitzer merc t4 arm
            public string defense_c_spinningaxes { get; set; } //smart bomb merc t4 tact

            //t5
            public string defense_c_t5_anti_inf_normal_trap { get; set; }
            public string defense_c_t5_anti_cav_normal_trap { get; set; }
            public string defense_c_t5_anti_ran_normal_trap { get; set; }
            public string defense_c_t5_anti_inf_strategic_trap { get; set; }
            public string defense_c_t5_anti_cav_strategic_trap { get; set; }
            public string defense_c_t5_anti_ran_strategic_trap { get; set; }
            public string defense_c_t5_anti_inf_wild_trap { get; set; }
            public string defense_c_t5_anti_cav_wild_trap { get; set; }
            public string defense_c_t5_anti_ran_wild_trap { get; set; }

            //t6
            public string defense_c_t6_anti_inf_normal_trap { get; set; }
            public string defense_c_t6_anti_cav_normal_trap { get; set; }
            public string defense_c_t6_anti_ran_normal_trap { get; set; }
            public string defense_c_t6_anti_inf_strategic_trap { get; set; }
            public string defense_c_t6_anti_cav_strategic_trap { get; set; }
            public string defense_c_t6_anti_ran_strategic_trap { get; set; }
            public string defense_c_t6_anti_inf_wild_trap { get; set; }
            public string defense_c_t6_anti_cav_wild_trap { get; set; }
            public string defense_c_t6_anti_ran_wild_trap { get; set; }
        }

        public class SpecificUnitTypes
        {
            //TROOPS
            //t1
            public int troop_battering_ram { get; set; } //mortar reg t1 art
            public int troop_outriders { get; set; } //patrol vehicle reg t1 arm
            public int troop_slingers { get; set; } //scout reg t1 tact
            public int troop_swordsmen { get; set; } //soldier reg t1 inf
            public int troop_trojanhorse { get; set; } //heavy ordnance adv t1 art
            public int troop_chariots { get; set; } //assault chopper adv t1 arm
            public int troop_hunters { get; set; } //armed guard adv t1 tact
            public int troop_spearman { get; set; } //counter terrorist adv t1 inf
            public int troop_ballistaravager { get; set; } //field gun merc t1 art
            public int troop_raiders { get; set; } //sentinel merc t1 arm
            public int troop_archers { get; set; } //marksmen merc t1 tact
            public int troop_barbarians { get; set; } //militia merc t1 inf

            //t2
            public int troop_ballista { get; set; } //missile launcher reg t2 art
            public int troop_light_cavalry { get; set; } //armored vehicle reg t2 arm
            public int troop_skirmish_archers { get; set; } //commando reg t2 tact
            public int troop_hoplites { get; set; } //machine gunner reg t2 inf
            public int troop_speartower { get; set; } //heavy artillery adv t2 art
            public int troop_scythedchariots { get; set; } //cobras adv t2 arm
            public int troop_rangers { get; set; } //ghosts adv t2 tact
            public int troop_peltasts { get; set; } //grenadier adv t2 inf
            public int troop_dragonfirecannon { get; set; } //assault cannon merc t2 art
            public int troop_marauders { get; set; } //goliath tanks merc t2 arm
            public int troop_axethrowers { get; set; } //recon merc t2 tact
            public int troop_axeman { get; set; } //watcher merc t2 inf

            //t3
            public int troop_siegetower { get; set; } //howitzers reg t3 art
            public int troop_companion_cavalry { get; set; } //LAV reg t3 arm
            public int troop_guardians { get; set; } //rangers reg t3 tact
            public int troop_armored_pikeman { get; set; } //rocket infantry reg t3 inf
            public int troop_flamingtrebuchet { get; set; } //ballistic missile adv t3 art
            public int troop_lancers { get; set; } //raptor jet adv t3 arm
            public int troop_stalkers { get; set; } //spec ops adv t3 tact
            public int troop_phalangite { get; set; } //patroller adv t3 inf
            public int troop_warram { get; set; } //cruise missile merc t3 art
            public int troop_amazons { get; set; } //reaper drone merc t3 arm
            public int troop_reavers { get; set; } //specialist merc t3 tact
            public int troop_berserkers { get; set; } //spectre merc t3 inf

            //t4
            public int troop_onager { get; set; } //rocket artillery reg t4 art
            public int troop_war_elephants { get; set; } //tank reg t4 arm
            public int troop_marksmen { get; set; } //delta reg t4 tact
            public int troop_immortals { get; set; } //demos reg t4 inf
            public int troop_barricadedrill { get; set; } //missile system adv t4 art
            public int troop_cataphracts { get; set; } //bombers adv t4 arm
            public int troop_dianas { get; set; } //paratroopers adv t4 tact
            public int troop_legionnaires { get; set; } //guardians adv t4 inf
            public int troop_siegeelephant { get; set; } //rocket storm merc t4 art
            public int troop_juggernauts { get; set; } //gunship merc t4 arm
            public int troop_slayers { get; set; } //covert ops merc t4 tact
            public int troop_valkyries { get; set; } //enforcer merc t4 inf

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

            //TRAPS
            //t0
            public int defense_c_brick { get; set; } //sand bag reg t0
            public int defense_c_iron_bricks { get; set; } //barriers adv t0
            public int defense_c_bonebricks { get; set; } //barricade merc t0

            //t1
            public int defense_c_tarteam { get; set; } //barbed wire reg t1 inf
            public int defense_c_spikes { get; set; } //tank trap reg t1 arm
            public int defense_c_archertower { get; set; } //trip wire reg t1 tact
            public int defense_c_rolling_wall { get; set; } //laser fence adv t1 inf
            public int defense_c_pitfall { get; set; } //emp barrier adv t1 arm
            public int defense_c_longbow_tower { get; set; } //ied explosive adv t1 tact
            public int defense_c_flamebowtower { get; set; } //persuader merc t1 inf
            public int defense_c_wilddogs { get; set; } //blockade merc t1 arm
            public int defense_c_poisonedspikes { get; set; } //nuclear mine merc t1 tact

            //t2
            public int defense_c_cannon { get; set; } //landmine reg t2 inf
            public int defense_c_traps { get; set; } //anti tank mine reg t2 arm
            public int defense_c_turret { get; set; } //electric fence reg t2 tact
            public int defense_c_arrow_wall { get; set; } //mounted gun adv t2 inf
            public int defense_c_flaming_carts { get; set; } //missile turret adv t2 arm
            public int defense_c_sentry_tower { get; set; } //spider mine adv t2 tact
            public int defense_c_arrowlauncher { get; set; } //auto turret merc t2 inf
            public int defense_c_snakedrop { get; set; } //missile battery merc t2 arm
            public int defense_c_tartrap { get; set; } //tank turret merc t2 tact

            //t3
            public int defense_c_caltrops { get; set; } //bunker reg t3 inf
            public int defense_c_catapults { get; set; } //emp mine //reg t3 arm
            public int defense_c_bolders { get; set; } //claymore reg t3 tact
            public int defense_c_pendulum { get; set; } //ir gun turret adv t3 inf
            public int defense_c_mobile_tower { get; set; } //laser cannon adv t3 tact
            public int defense_c_poison_swamp { get; set; } //ir missile turret adv t3 arm
            public int defense_c_dragonspitter { get; set; } //heavy mortar merc t3 inf
            public int defense_c_crocodilepit { get; set; } //sam turret merc t3 arm
            public int defense_c_flaminglog { get; set; } //remote sniper merc t3 tact

            //t4
            public int defense_c_greekfire { get; set; } //hydra reg t4 inf
            public int defense_c_barriers { get; set; } //javelin reg t4 arm
            public int defense_c_trebuchet { get; set; } //sniper tower reg t4 tact
            public int defense_c_warbarricade { get; set; } //defense drone adv t4 inf
            public int defense_c_smokebomb { get; set; } //aa cannon adv t4 arm
            public int defense_c_ballistatower { get; set; } //satellite system adv t4 tact
            public int defense_c_fireartillery { get; set; } //gunship drone merc t4 inf
            public int defense_c_titantree { get; set; } //heavy howitzer merc t4 arm
            public int defense_c_spinningaxes { get; set; } //smart bomb merc t4 tact

            //t5
            public int defense_c_t5_anti_inf_normal_trap { get; set; }
            public int defense_c_t5_anti_cav_normal_trap { get; set; }
            public int defense_c_t5_anti_ran_normal_trap { get; set; }
            public int defense_c_t5_anti_inf_strategic_trap { get; set; }
            public int defense_c_t5_anti_cav_strategic_trap { get; set; }
            public int defense_c_t5_anti_ran_strategic_trap { get; set; }
            public int defense_c_t5_anti_inf_wild_trap { get; set; }
            public int defense_c_t5_anti_cav_wild_trap { get; set; }
            public int defense_c_t5_anti_ran_wild_trap { get; set; }

            //t6
            public int defense_c_t6_anti_inf_normal_trap { get; set; }
            public int defense_c_t6_anti_cav_normal_trap { get; set; }
            public int defense_c_t6_anti_ran_normal_trap { get; set; }
            public int defense_c_t6_anti_inf_strategic_trap { get; set; }
            public int defense_c_t6_anti_cav_strategic_trap { get; set; }
            public int defense_c_t6_anti_ran_strategic_trap { get; set; }
            public int defense_c_t6_anti_inf_wild_trap { get; set; }
            public int defense_c_t6_anti_cav_wild_trap { get; set; }
            public int defense_c_t6_anti_ran_wild_trap { get; set; }
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
