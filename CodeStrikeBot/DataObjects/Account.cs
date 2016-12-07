using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace CodeStrikeBot
{
    [Table(Name="accounts")]
    public class Account : DataObject
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "userName")]
        public string UserName { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "password")]
        public string Password { get; set; }
        [Column(Name = "priority")]
        public AccountPriority Priority { get; set; }
        [Column(Name = "foodNegativeAmount")]
        public int FoodNegativeAmount { get; set; }
        [Column(Name = "lastLogin")]
        public DateTime LastLogin { get; set; }
        [Column(Name = "lastLogout")]
        public DateTime LastLogout { get; set; }

        public Account(int id, string Name, string UserName, string Email, string Password, AccountPriority Priority, int FoodNegativeAmount, DateTime lastLogin, DateTime lastLogout)
        {
            this.Id = id;
            this.Name = Name;
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.Priority = Priority;
            this.FoodNegativeAmount = FoodNegativeAmount;
            this.LastLogin = lastLogin;
            this.LastLogout = lastLogout;
        }

        public Account(int id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public Account Save()
        {
            return (Account)BotDatabase.SaveObject(this);
        }

        public static List<Account> GetAccounts()
        {
            List<DataObject> objects = BotDatabase.GetObjects<Account>();
            List<Account> accounts = new List<Account>();

            foreach (DataObject o in objects)
            {
                accounts.Add((Account)o);
            }

            return accounts;
        }
    }

    public enum AccountPriority : ushort
    {
        NoMonitor = 0,
        LowMonitor = 1,
        MediumMonitor = 2,
        AlwaysMonitor = 3
    }
}
