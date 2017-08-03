using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot.DataObjects
{
    [Table(Name = "apps")]
    public class App : DataObject
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "shortName")]
        public string ShortName { get; set; }

        public App(int id, string name, string shortName)
        {
            this.Id = id;
            this.Name = name;
            this.ShortName = shortName;
        }

        public App(int id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return Name;
        }

        public App Save()
        {
            return (App)BotDatabase.SaveObject(this);
        }

        public static List<App> GetApps()
        {
            List<DataObject> objects = BotDatabase.GetObjects<App>();
            List<App> apps = new List<App>();

            foreach (DataObject o in objects)
            {
                apps.Add((App)o);
            }

            return apps;
        }
    }
}
