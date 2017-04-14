using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStrikeBot.Messages.Data
{
    public class March
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

        public int FromProvinceId { get; private set; }
        public int FromChunkId { get; private set; }
        public int FromTileId { get; private set; }
        public string FromName { get; private set; }

        public int DestProvinceId { get; private set; }
        public int DestChunkId { get; private set; }
        public int DestTileId { get; private set; }
        public string DestName { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; set; }
        public DateTime LastUpdate { get; set; }
        
        public MarchEmoji Emoji { get; set; }
        public DateTime EmojiStartTime { get; set; }
        public string TypeData { get; set; }
        public int AnimAttrib { get; set; }
        public int Color { get; private set; }
        public bool King { get; set; }

        public March(MarchMessage message)
        {
            this.MarchId = message.march_id;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1} {2}->{3}", Enum.GetName(typeof(MarchType), this.Type).Replace("CodeStrikeBot.Messages.Data.MarchType", ""), this.march_id, this.from_name, this.dest_name);
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
        Encampment,
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
