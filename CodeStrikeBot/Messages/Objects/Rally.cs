using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;

namespace CodeStrikeBot.Messages.Objects
{
    public class Rally : IComparable
    {
        public string RallyKey { get; set; }
        public int AllianceId { get; set; }
        public int RallyId { get; set; }
        public int Type { get; set; }
        public int Role { get; set; }
        public int State { get; set; }
        public int DefeatEmoji { get; set; }
        public int TimerLength { get; set; }
        public int Timer { get; set; }
        public DateTime TimerStart { get; set; }
        public DateTime TimerEnd { get; set; }
        public int TroopCount { get; set; }
        public HeroComposite HeroCompositeId { get; set; }
        public int TroopMax { get; set; }
        public int RalliedTroopCount { get; set; }
        public int TrapMax { get; set; }
        public int TrapCount { get; set; }
        public int MonsterCount { get; set; }
        public bool VIPQueueEnabled { get; set; }
        public Attacker AttackerInfo { get; set; }
        public Defender DefenderInfo { get; set; }
        public List<RallySlot> Slots { get; set; }
        public SharedCounts AllianceCounts { get; set; }

        public DateTime LastUpdate { get; set; }
        public List<WarRallyMessage> Messages { get; set; }

        public Rally(WarRallyMessage message)
        {
            this.Slots = message.slots;
            this.AllianceCounts = message.shared_counts;

            this.Messages = new List<WarRallyMessage>();

            this.Update(message);
        }

        public void Update(WarRallyMessage message)
        {
            if (message.Timestamp > this.LastUpdate)
            {
                this.RallyKey = message.war_key;
                this.AllianceId = message.alliance_id;
                this.RallyId = message.war_id;
                this.Type = message.war_type;
                this.Role = message.role;
                this.State = message.state;
                this.DefeatEmoji = message.defeat_emoji;
                this.TimerLength = message.timer_length;
                this.Timer = message.timer;
                this.TimerStart = message.timer_start;
                this.TimerEnd = message.timer_end;
                this.TroopCount = message.troop_count;
                this.HeroCompositeId = message.hero_composite_id;
                this.TroopMax = message.troop_max;
                this.RalliedTroopCount = message.rallied_troop_count;
                this.TrapMax = message.trap_max;
                this.TrapCount = message.trap_count;
                this.MonsterCount = message.monster_count;
                this.VIPQueueEnabled = message.copy_leader_ratio_enabled;
                this.AttackerInfo = message.attacker;
                this.DefenderInfo = message.defender;

                this.LastUpdate = message.Timestamp;
            }

            this.Messages.Add(message);
        }

        public int CompareTo(object o)
        {
            if (o is Rally)
            {
                Rally r = (Rally)o;

                int diff = this.TimerEnd.CompareTo(r.TimerEnd);

                if (diff == 0)
                {
                    diff = this.RallyId.CompareTo(r.RallyId);
                }

                return diff;
            }
            else
            {
                return 1;
            }
        }

        public class HeroComposite
        {
            public int user_id { get; set; }
            public int city_id { get; set; }
        }

        public class Attacker
        {
            public string AllianceFullName { get; set; }
            public string AllianceTag { get; set; }
            public string UserName { get; set; }
            public int HomeProvinceId { get; set; }
            public string CityName { get; set; }
            public int CityId { get; set; }
            public Point3D Tile { get; set; }
            public int TileRank { get; set; }
            public int TileOverlay { get; set; }
            public int Rank { get; set; }
            public int VIPLevel { get; set; }
            public int UserId { get; set; }
            public int EmpireId { get; set; }
            public int ArmyId { get; set; }
        }

        public class Defender
        {
            public string AllianceFullName { get; set; }
            public string AllianceTag { get; set; }
            public int Rank { get; set; }
            public int VIPLevel { get; set; }
            public string UserName { get; set; }
            public int UserId { get; set; }
            public int EmpireId { get; set; }
            public string CityName { get; set; }
            public int CityId { get; set; }
            public Point3D Tile { get; set; }
            public int TileRank { get; set; }
            public int TileOverlay { get; set; }
            public int TileControlPointId { get; set; }
            public int ControlPointId { get; set; }
            public int ControlPointAllianceId { get; set; }
        }

        public class RallySlot
        {
            public string RallyKey { get; set; }
            public int AllianceId { get; set; }
            public int RallyId { get; set; }
            public int SlotId { get; set; }
            public SlotStatus Status { get; set; }
            public string UserName { get; set; }
            public int UserId { get; set; }
            public int EmpireId { get; set; }
            public int CityId { get; set; }
            public int ArmyId { get; set; }
            public int Rank { get; set; }
            public int VIPLevel { get; set; }
            public string AllianceTag { get; set; }
            public int TimerLength { get; set; }
            public int Timer { get; set; }
            public DateTime TimerStart { get; set; }
            public DateTime TimerEnd { get; set; }
            public int TroopCount { get; set; }
            public List<KeyValuePair<string, int>> Troops { get; set; }
            public List<KeyValuePair<string, int>> TroopUnits { get; set; }
            public int TotalTroopCount { get; set; }
            public int TotalTroopMax { get; set; }
            public int TrapCount { get; set; }
            public int TotalTrapCount { get; set; }
            public int TotalTrapMax { get; set; }

            public enum SlotStatus : int
            {
                Free = 0,
                Filled = 2
            }
        }

        public class SharedCounts
        {
            public int AllianceIncomingInvites { get; set; }
            public int AllianceWarAttacks { get; set; }
            public int AllianceWarDefenses { get; set; }
            public int AllianceACWarAttacks { get; set; }
            public int AllianceACWarDefenses { get; set; }
            public int AllianceGroupWarAttacks { get; set; }
            public int AllianceGroupWarDefenses { get; set; }
        }
    }
}
