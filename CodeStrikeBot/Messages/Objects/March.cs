using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace CodeStrikeBot.Messages.Objects
{
    public class March : IComparable
    {
        public string MarchId { get; private set; }
        public MarchType Type { get; private set; }
        public MarchState State { get; set; }

        public int UserId { get; private set; }
        public int EmpireId { get; private set; }
        public int Id { get; private set; }
        public int CityId { get; private set; }
        public int ArmyId { get; private set; }
        public int HomeId { get; private set; }
        public int AllianceId { get; private set; }

        public Point3D FromCoordinate { get; private set; }
        public string FromName { get; private set; }

        public Point3D DestCoordinate { get; private set; }
        public string DestName { get; private set; }
        public bool DestNameNeedLocalize { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; set; }
        public DateTime LastUpdate { get; set; }
        
        public MarchEmoji Emoji { get; set; }
        public DateTime EmojiStartTime { get; set; }
        public string TypeData { get; set; }
        public int AnimAttrib { get; set; }
        public int TruceType { get; set; }
        public int Color { get; set; }
        public bool King { get; set; }

        public string HeroGender { get; private set; }
        public string HeroName { get; private set; }

        public Watchtower Watchtower { get; set; }

        public List<MarchMessage> Messages;

        public March(MarchMessage message)
        {
            this.MarchId = message.march_id;
            this.Type = message.type;
            this.UserId = message.user_id;
            this.EmpireId = message.empire_id;
            this.Id = message.id;
            this.CityId = message.city_id;
            this.ArmyId = message.army_id;
            this.HomeId = message.home_id;
            this.AllianceId = message.alliance_id;
            this.FromCoordinate = Utilities.ProvinceChunkTile2Point3D(message.from_province_id, message.from_chunk_id, message.from_tile_id);
            this.FromName = message.from_name;
            this.DestCoordinate = Utilities.ProvinceChunkTile2Point3D(message.dest_province_id, message.dest_chunk_id, message.dest_tile_id);
            this.DestName = message.dest_name;
            this.DestNameNeedLocalize = message.dest_name_need_localize;
            this.StartTime = message.start_time;
            this.HeroGender = message.hero_gender;
            this.HeroName = message.hero_name;

            this.Messages = new List<MarchMessage>();

            this.Update(message);
        }

        public void Update(MarchMessage message)
        {
            if (message.update_ts > this.LastUpdate)
            {
                this.State = message.state;
                this.LastUpdate = message.update_ts;
                this.EndTime = message.dest_time;
                this.Emoji = message.emoji;
                this.EmojiStartTime = message.emoji_starttime;
                this.TypeData = message.type_data;
                this.AnimAttrib = message.anim_attrib;
                this.TruceType = message.truce_type;
                this.Color = message.color;
                this.King = message.king;

                if (message.update_ts == message.dest_time)
                {
                    this.State = MarchState.Ended;
                }
            }

            this.Messages.Add(message);
        }

        public void Update(Watchtower watch)
        {
            if (this.Watchtower == null || this.Watchtower.timestamp < watch.timestamp)
            {
                this.Watchtower = watch;
            }
        }

        public override string ToString()
        {
            if (this.Watchtower != null)
            {
                return String.Format("{6} {0}: {1}:{2}:{3} {4}->{5}", Enum.GetName(typeof(MarchType), this.Type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.DestCoordinate.Z, this.DestCoordinate.X, this.DestCoordinate.Y, this.FromName, this.DestName, this.Watchtower.ActualTotalUnits);
            }
            else
            {
                return String.Format("{0}: {1}:{2}:{3} {4}->{5}", Enum.GetName(typeof(MarchType), this.Type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.DestCoordinate.Z, this.DestCoordinate.X, this.DestCoordinate.Y, this.FromName, this.DestName);
            }
        }

        public int CompareTo(object o)
        {
            if (o is March)
            {
                March m = (March)o;

                int diff = this.EndTime.CompareTo(m.EndTime);

                if (diff == 0)
                {
                    diff = this.MarchId.CompareTo(m.MarchId);
                }

                return diff;
            }
            else
            {
                return 1;
            }
        }

        public enum MarchState
        {
            Advancing,
            Returning,
            Busy,
            Ended,
            Unknown
        }

        public enum MarchType
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
            Unknown
        }

        public enum MarchEmoji
        {
            Default,
            Unknown
        }
    }

    public enum TargetType
    {
        City,
        Encampment,
        GameUnknown,
        Unknown
    }
}
