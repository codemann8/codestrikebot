using System;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot.DataObjects
{
    public abstract class DataObject
    {
        [Column(IsPrimaryKey = true, Name = "id")]
        public int Id { get; set; }

        public DataObject()
        {
            Id = 0;
        }

        public void Delete()
        {
            BotDatabase.DeleteObject(this);
        }
    }
}
