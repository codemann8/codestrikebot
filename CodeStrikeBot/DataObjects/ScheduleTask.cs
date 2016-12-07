using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot
{
    [Table(Name = "schedules")]
    public class ScheduleTask : DataObject, IComparable<ScheduleTask>
    {
        //[Column(Name = "name")]
        public Account Account { get; set; }
        [Column(Name = "accountId")]
        public Account AccountId { get; set; }
        [Column(Name = "type")]
        public ScheduleType Type { get; set; }
        [Column(Name = "interval")]
        public int Interval { get; set; }
        [Column(Name = "amount")]
        public int Amount { get; set; }
        [Column(Name = "count")]
        public int Count { get; set; }
        [Column(Name = "x")]
        public int X { get; set; }
        [Column(Name = "y")]
        public int Y { get; set; }
        //[Column(Name = "name")]
        public int BackupX { get; set; }
        //[Column(Name = "name")]
        public int BackupY { get; set; }
        [Column(Name = "lastAction")]
        public DateTime LastAction { get; set; }

        public ScheduleTask(int id, Account account, ScheduleType type, int interval, int amount, int count, int x, int y, DateTime lastAction)
        {
            Id = id;
            Account = account;
            Type = type;
            Interval = interval;
            Amount = amount;
            Count = count;
            X = x;
            Y = y;
            LastAction = lastAction;
        }

        public DateTime NextAction
        {
            get { return LastAction.AddMinutes(Interval); }
        }

        public ScheduleTask Save()
        {
            return (ScheduleTask)BotDatabase.SaveObject(this);
        }

        public static List<ScheduleTask> GetTasks(List<Account> accounts)
        {
            List<DataObject> objects = BotDatabase.GetObjects<ScheduleTask>();
            List<ScheduleTask> tasks = new List<ScheduleTask>();

            foreach (DataObject o in objects)
            {
                ScheduleTask task = (ScheduleTask)o;

                if (task.NextAction <= DateTime.Now)
                {
                    foreach (Account a in accounts)
                    {
                        if (a.Id == task.Account.Id)
                        {
                            task.Account = a;
                        }
                    }
                    tasks.Add(task);
                }
            }

            tasks.Sort();

            return tasks;
        }

        public int CompareTo(ScheduleTask task)
        {
            return DateTime.Compare(this.NextAction, task.NextAction);
        }
    }

    public enum ScheduleType : int
    {
        StoneTransfer = 0,
        OilTransfer = 1,
        IronTransfer = 2,
        FoodTransfer = 3,
        CoinTransfer = 4,
        Login = 5,
        Shield = 6,
        AntiScout = 7,
        GhostRally = 8,
        ActivateVIP = 9
    }
}
