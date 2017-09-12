using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace CodeStrikeBot.Messages.Objects
{
    public class Tile
    {
        public Point3D Coordinate { get; private set; }

        public int Overlay { get; private set; }
        public int ObjectId { get; private set; }

        public DateTime LastUpdate { get; set; }

        public int Health { get; private set; }
        public int HealthTotal { get; private set; }
        public int CreatureId { get; private set; }
        public int State { get; private set; }
        public int EventId { get; private set; }
        public int CreatureType { get; private set; }
        public DateTime DeathTime { get; set; }

        public TileCity City { get; set; }
        public TileArmy Army { get; set; }

        public int RLevel { get; set; }
        public int RAmount { get; set; }
        public DateTime RCustomExpireTime { get; set; }
        public DateTime RGatherStartTime { get; set; }
        public int RGatherDuration { get; set; }
        public DateTime RTruceExpireTime { get; set; }
        public double RTickDuration { get; set; }

        public List<TileUpdatedMessage> Messages;

        public Tile(TileUpdatedMessage.Tile tile, Point3D coord, TileUpdatedMessage message)
        {
            this.Coordinate = coord;

            this.Overlay = tile.overlay;
            this.ObjectId = tile.object_id;
            this.LastUpdate = tile.last_updated;
            this.Health = tile.health;
            this.HealthTotal = tile.max_health;
            this.CreatureId = tile.creature_id;
            this.State = tile.state;
            this.EventId = tile.event_id;
            this.CreatureType = tile.creature_type;
            this.DeathTime = tile.death_time;

            this.City = new TileCity(tile.city);
            this.Army = new TileArmy(tile.army);

            this.RLevel = tile.r_level;
            this.RAmount = tile.r_amount;
            this.RCustomExpireTime = tile.r_custom_expire_ts;
            this.RGatherStartTime = tile.r_gather_start_time;
            this.RGatherDuration = tile.r_gather_duration;
            this.RTruceExpireTime = tile.r_truce_expire_ts;
            this.RTickDuration = tile.r_tick_duration;

            this.Messages = new List<TileUpdatedMessage>();

            this.Messages.Add(message);
        }

        public void Update(TileUpdatedMessage message)
        {
            foreach (TileUpdatedMessage.Chunk c in message.chunks)
            {
                foreach (TileUpdatedMessage.Tile t in c.tiles)
                {
                    if (t.last_updated > this.LastUpdate)
                    {
                        Point3D messageCoord = Utilities.ProvinceChunkTile2Point3D(c.p_id, c.c_id, t.tile_id);
                        if (messageCoord.Z == this.Coordinate.Z && messageCoord.X == this.Coordinate.X && messageCoord.Y == this.Coordinate.Y)
                        {
                            this.Overlay = t.overlay;
                            this.ObjectId = t.object_id;
                            this.LastUpdate = t.last_updated;
                            this.Health = t.health;
                            this.HealthTotal = t.max_health;
                            this.CreatureId = t.creature_id;
                            this.State = t.state;
                            this.EventId = t.event_id;
                            this.CreatureType = t.creature_type;
                            this.DeathTime = t.death_time;

                            this.City = new TileCity(t.city);
                            this.Army = new TileArmy(t.army);

                            this.RLevel = t.r_level;
                            this.RAmount = t.r_amount;
                            this.RCustomExpireTime = t.r_custom_expire_ts;
                            this.RGatherStartTime = t.r_gather_start_time;
                            this.RGatherDuration = t.r_gather_duration;
                            this.RTruceExpireTime = t.r_truce_expire_ts;
                            this.RTickDuration = t.r_tick_duration;
                        }
                    }
                }
            }

            this.Messages.Add(message);
        }

        public void Update(Watchtower watch)
        {
            /*if (this.Watchtower == null || this.Watchtower.timestamp < watch.timestamp)
            {
                this.Watchtower = watch;
            }*/
        }

        public override string ToString()
        {
            /*if (this.Watchtower != null)
            {
                return String.Format("{6} {0}: {1}:{2}:{3} {4}->{5}", Enum.GetName(typeof(MarchType), this.Type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.DestCoordinate.Z, this.DestCoordinate.X, this.DestCoordinate.Y, this.FromName, this.DestName, this.Watchtower.ActualTotalUnits);
            }
            else
            {
                return String.Format("{0}: {1}:{2}:{3} {4}->{5}", Enum.GetName(typeof(MarchType), this.Type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.DestCoordinate.Z, this.DestCoordinate.X, this.DestCoordinate.Y, this.FromName, this.DestName);
            }*/
            return "";
        }

        public enum TileState
        {
            Advancing,
            Returning,
            Busy,
            Ended,
            Unknown
        }

        /*public enum CreatureType
        {
            Attack,
            Rally,
            Scout,
            Reinforcement,
            War,
            Trade,
            Tile,
            RebelAttack,
            HeroEscape,
            Digging,
            Unknown
        }*/

        public class TileCity
        {
            public int UserId { get; set; }
            public int EmpireId { get; set; }
            public int CityId { get; set; }
            public int ScoutCost { get; set; }
            public string CityName { get; set; }
            public int LastState { get; set; }
            public bool IsLastStateACWar { get; set; }
            public DateTime StateTimestamp { get; set; }
            public int DefeatedVanityId { get; set; }
            public int CityLevel { get; set; }

            public TileCity(Messages.TileUpdatedMessage.City c)
            {
                this.UserId = c.user_id;
                this.EmpireId = c.empire_id;
                this.CityId = c.city_id;
                this.ScoutCost = c.scout_cost;
                this.CityName = c.city_name;
                this.LastState = c.last_state;
                this.IsLastStateACWar = c.is_last_state_ac_war;
                this.StateTimestamp = c.state_timestamp;
                this.DefeatedVanityId = c.defeated_vanity_id;
                this.CityLevel = c.city_level;
            }
        }

        public class TileArmy
        {
            public int UserId { get; set; }
            public int EmpireId { get; set; }
            public int CityId { get; set; }
            public int ArmyId { get; set; }
            public int ScoutCost { get; set; }
            public int ArmyLoad { get; set; }

            public TileArmy(Messages.TileUpdatedMessage.Army a)
            {
                this.UserId = a.user_id;
                this.EmpireId = a.empire_id;
                this.CityId = a.city_id;
                this.ArmyId = a.army_id;
                this.ScoutCost = a.scout_cost;
                this.ArmyLoad = a.army_load;
            }
        }
    }
}
