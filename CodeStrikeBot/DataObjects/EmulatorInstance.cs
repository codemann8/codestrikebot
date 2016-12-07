using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot
{
    [Table(Name = "emulators")]
    public class EmulatorInstance : DataObject
    {
        [Column(Name = "type")]
        public EmulatorType Type { get; set; }
        [Column(Name = "windowsName")]
        public string WindowName { get; set; }
        [Column(Name = "command")]
        public string Command { get; set; }
        [Column(Name = "lastKnownAccount")]
        public Account LastKnownAccount { get; set; }

        public EmulatorInstance(int id, EmulatorType type, string windowName, string command, Account lastKnownAccount)
        {
            this.Id = id;
            this.Type = type;
            this.WindowName = windowName;
            this.Command = command;
            this.LastKnownAccount = lastKnownAccount;
        }

        public EmulatorInstance(int id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return String.Format("{0}[{1}]", WindowName, LastKnownAccount.Name);
        }

        public EmulatorInstance Save()
        {
            return (EmulatorInstance)BotDatabase.SaveObject(this);
        }

        public static List<EmulatorInstance> GetEmulators(List<Account> accounts)
        {
            List<DataObject> objects = BotDatabase.GetObjects<EmulatorInstance>();
            List<EmulatorInstance> emulators = new List<EmulatorInstance>();

            foreach (DataObject o in objects)
            {
                EmulatorInstance emulator = (EmulatorInstance)o;

                foreach (Account a in accounts)
                {
                    if (a.Id == emulator.LastKnownAccount.Id)
                    {
                        emulator.LastKnownAccount = a;
                    }
                }
                emulators.Add(emulator);
            }

            return emulators;
        }
    }

    public enum EmulatorType : int
    {
        Droid4X = 0,
        Nox = 1,
        Leapdroid = 2
    }
}
