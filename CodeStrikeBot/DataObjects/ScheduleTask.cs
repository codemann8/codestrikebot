using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot.DataObjects
{
    [Table(Name = "schedules")]
    public class ScheduleTask : DataObject, IComparable<ScheduleTask>
    {
        //[Column(Name = "name")]
        public Account Account { get; set; }
        [Column(Name = "accountId")]
        public int AccountId { get; set; }
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
        [Column(Name = "backupX")]
        public int BackupX { get; set; }
        [Column(Name = "backupY")]
        public int BackupY { get; set; }
        [Column(Name = "lastAction")]
        public DateTime LastAction { get; set; }

        public App App { get; set; }

        public ScheduleTask(int id, Account account, ScheduleType type, int interval, int amount, int count, int x, int y, int backupX, int backupY, DateTime lastAction, App app)
        {
            Id = id;
            Account = account;
            Type = type;
            Interval = interval;
            Amount = amount;
            Count = count;
            X = x;
            Y = y;
            BackupX = backupX;
            BackupY = backupY;
            LastAction = lastAction;
            App = app;
        }

        public DateTime NextAction
        {
            get { return LastAction.AddMinutes(Interval); }
        }

        public ScheduleTask Save()
        {
            return (ScheduleTask)BotDatabase.SaveObject(this);
        }

        public static List<ScheduleTask> GetTasks(List<Account> accounts, List<App> apps)
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

                    foreach (App a in apps)
                    {
                        if (a.Id == task.App.Id)
                        {
                            task.App = a;
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
}

namespace CodeStrikeBot
{
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
        ActivateVIP = 9,
        UpkeepReduction = 10,
        Health = 11,
        Defense = 12,
        Milestone = 13,
        EliteRebelTarget = 14,
        FoodT2Transfer = 15,
        OilT2Transfer = 16,
        StoneT2Transfer = 17,
        IronT2Transfer = 18,
        CoinT2Transfer = 19
    }
}
