using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot
{
    [Table(Name = "settings")]
    public class Settings : DataObject
    {
        [Column(Name = "version")]
        public int Version { get; set; }
        [Column(Name = "emulatorId1")]
        public int Emulator1 { get; set; }
        [Column(Name = "emulatorId2")]
        public int Emulator2 { get; set; }
        [Column(Name = "emulatorId3")]
        public int Emulator3 { get; set; }
        [Column(Name = "emulatorId4")]
        public int Emulator4 { get; set; }
        [Column(Name = "mapDir")]
        public string MapDir { get; set; }
        [Column(Name = "screenshotDir")]
        public string ScreenshotDir { get; set; }
        [Column(Name = "slackURL")]
        public string SlackURL { get; set; }
        [Column(Name = "pushoverAPIKey")]
        public string PushoverAPIKey { get; set; }
        [Column(Name = "pushoverUserKey")]
        public string PushoverUserKey { get; set; }

        public int[] ActiveEmulators { get { return new int[4] { Emulator1, Emulator2, Emulator3, Emulator4 }; } }

        public Settings(int version, int emulator1, int emulator2, int emulator3, int emulator4, string mapDir, string ssDir, string slackURL, string pushoverAPIKey, string pushoverUserKey)
        {
            this.Version = version;

            this.Emulator1 = emulator1;
            this.Emulator2 = emulator2;
            this.Emulator3 = emulator3;
            this.Emulator4 = emulator4;

            this.MapDir = mapDir;
            this.ScreenshotDir = ssDir;

            this.SlackURL = slackURL;
            this.PushoverAPIKey = pushoverAPIKey;
            this.PushoverUserKey = pushoverUserKey;
        }

        public Settings Save()
        {
            return (Settings)BotDatabase.SaveObject(this);
        }

        public static Settings GetSettings()
        {
            List<DataObject> objects = BotDatabase.GetObjects<Settings>();

            return (Settings)(objects[0]);
        }
    }
}
