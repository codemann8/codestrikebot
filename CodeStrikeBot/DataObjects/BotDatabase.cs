using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlServerCe;
using System.Data;

namespace CodeStrikeBot
{
    public class BotDatabase
    {
        public SqlCeConnection Connection { get; private set; }

        public int[] ActiveEmulators;
        public string ScreenshotDir, MapDir;

        public BotDatabase()
        {
            if (!File.Exists("data.sdf"))
            {
                SqlCeEngine en = new SqlCeEngine("DataSource=\"data.sdf\";Password='codestrikebot';Max Database Size=2048");
                en.CreateDatabase();
            }

            Connection = GetNewConnection();
            Connection.Open();

            this.ActiveEmulators = new int[4];

            this.UpdateDatabase();

            this.LoadSettings();
        }

        private static SqlCeConnection GetNewConnection()
        {
            return new SqlCeConnection("DataSource=\"data.sdf\";Password='codestrikebot';Max Database Size=2048");
        }

        private void UpdateDatabase()
        {
            SqlCeCommand command = new SqlCeCommand("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'settings'", Connection);
            SqlCeDataReader reader = command.ExecuteReader();

            if (!reader.Read()) //database is not built
            {
                command = new SqlCeCommand("CREATE TABLE settings (version INT NOT NULL, emulatorId1 INT, emulatorId2 INT, emulatorId3 INT, emulatorId4 INT, screenshotDir NVARCHAR(255), mapDir NVARCHAR(255))", Connection);
                command.ExecuteNonQuery();
                command = new SqlCeCommand("INSERT INTO settings (version) VALUES (0)", Connection);
                command.ExecuteNonQuery();
            }

            int version = 0;

            while (version != 1)
            {
                command = new SqlCeCommand("SELECT version FROM settings", Connection);
                reader = command.ExecuteReader();

                reader.Read();

                switch ((int)reader["version"])
                {
                    case 0:
                        command = new SqlCeCommand("CREATE TABLE accounts (id INTEGER PRIMARY KEY IDENTITY, name NVARCHAR(20) NOT NULL, username NVARCHAR(30) NOT NULL, email NVARCHAR(60) NOT NULL, password NVARCHAR(30) NOT NULL, priority INT DEFAULT 0, foodNegativeAmt INT DEFAULT 0, lastLogin DATETIME DEFAULT 0, lastLogout DATETIME DEFAULT 0)", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("CREATE TABLE log (id INTEGER PRIMARY KEY IDENTITY, type INT NOT NULL, description NVARCHAR(100), detail NVARCHAR(255), data IMAGE, timestamp DATETIME DEFAULT GETDATE() NOT NULL)", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("CREATE TABLE schedules (id INTEGER PRIMARY KEY IDENTITY, accountId INT NOT NULL, type INT NOT NULL, interval INT NOT NULL, amount INT NOT NULL, count INT DEFAULT 1, x INT, y INT, lastAction DATETIME DEFAULT 0)", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("CREATE UNIQUE INDEX NameIdx ON accounts (name)", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("CREATE TABLE emulators (id INTEGER PRIMARY KEY IDENTITY, type INT NOT NULL, command NVARCHAR(100), windowName NVARCHAR(60), lastKnownAccountId INT NOT NULL)", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("UPDATE settings SET version = 1, emulatorId1 = 0, emulatorId2 = 0, emulatorId3 = 0, emulatorId4 = 0, screenshotDir = 'output\\ss', mapDir = 'output\\map'", Connection);
                        command.ExecuteNonQuery();
                        break;
                    case 1:
                        command = new SqlCeCommand("ALTER TABLE schedules ADD backupX INTEGER DEFAULT 0, backupY INTEGER DEFAULT 0", Connection);
                        command.ExecuteNonQuery();
                        command = new SqlCeCommand("UPDATE settings SET version = 2", Connection);
                        command.ExecuteNonQuery();
                        break;
                }

                command.Dispose();
                reader.Dispose();

                version++;
            }
        }

        private void LoadSettings()
        {
            SqlCeCommand command = new SqlCeCommand("SELECT emulatorId1, emulatorId2, emulatorId3, emulatorId4, screenshotDir, mapDir FROM settings", Connection);
            SqlCeDataReader reader = command.ExecuteReader();
            reader.Read();
            this.ActiveEmulators[0] = reader.GetInt32(0);
            this.ActiveEmulators[1] = reader.GetInt32(1);
            this.ActiveEmulators[2] = reader.GetInt32(2);
            this.ActiveEmulators[3] = reader.GetInt32(3);
            this.ScreenshotDir = reader.GetString(4);
            this.MapDir = reader.GetString(5);
            command.Dispose();
            reader.Dispose();
        }

        public void UpdateSettings(EmulatorInstance[] emulators, string ssPath, string mapPath)
        {
            if (emulators[0] != null)
            {
                this.ActiveEmulators[0] = emulators[0].Id;
            }
            else
            {
                this.ActiveEmulators[0] = 0;
            }
            if (emulators[1] != null)
            {
                this.ActiveEmulators[1] = emulators[1].Id;
            }
            else
            {
                this.ActiveEmulators[1] = 0;
            }
            if (emulators[2] != null)
            {
                this.ActiveEmulators[2] = emulators[2].Id;
            }
            else
            {
                this.ActiveEmulators[2] = 0;
            }
            if (emulators[3] != null)
            {
                this.ActiveEmulators[3] = emulators[3].Id;
            }
            else
            {
                this.ActiveEmulators[3] = 0;
            }
            this.ScreenshotDir = ssPath;
            this.MapDir = mapPath;

            SqlCeCommand command = new SqlCeCommand(String.Format("UPDATE settings SET emulatorId1 = {0}, emulatorId2 = {1}, emulatorId3 = {2}, emulatorId4 = {3}, screenshotDir = '{4}', mapDir = '{5}'", ActiveEmulators[0], ActiveEmulators[1], ActiveEmulators[2], ActiveEmulators[3], ScreenshotDir, MapDir), Connection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public static DataObject SaveObject(DataObject obj)
        {
            SqlCeConnection con = GetNewConnection();
            con.Open();

            SqlCeCommand command = null;

            try
            {
                if (obj is Account)
                {
                    Account account = (Account)obj;

                    if (account.Id == 0)
                    {
                        command = new SqlCeCommand("INSERT INTO accounts (name, username, email, password, priority, foodNegativeAmt, lastLogin, lastLogout) VALUES (@name, @username, @email, @password, @priority, @foodNegAmt, @lastLogin, @lastLogout)", con);
                        command.Parameters.AddWithValue("@lastLogin", new DateTime());
                        command.Parameters.AddWithValue("@lastLogout", new DateTime());
                    }
                    else
                    {
                        command = new SqlCeCommand("UPDATE accounts SET name = @name, username = @username, email = @email, password = @password, priority = @priority, foodNegativeAmt = @foodNegAmt, lastLogin = @lastLogin, lastLogout = @lastLogout WHERE id = @id", con);
                        command.Parameters.AddWithValue("@lastLogin", account.LastLogin);
                        command.Parameters.AddWithValue("@lastLogout", account.LastLogout);
                        command.Parameters.AddWithValue("@id", account.Id);
                    }

                    command.Parameters.AddWithValue("@name", account.Name);
                    command.Parameters.AddWithValue("@username", account.UserName);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Parameters.AddWithValue("@priority", (int)account.Priority);
                    command.Parameters.AddWithValue("@foodNegAmt", account.FoodNegativeAmount);
                    command.ExecuteNonQuery();

                    if (account.Id == 0)
                    {
                        command = new SqlCeCommand("SELECT last_insert_rowid()", con);
                        account.Id = Convert.ToInt32(command.ExecuteScalar());
                    }

                    obj = account;
                }
                else if (obj is ScheduleTask)
                {
                    ScheduleTask task = (ScheduleTask)obj;

                    if (task.Id == 0)
                    {
                        command = new SqlCeCommand("INSERT INTO schedules (accountId, type, interval, amount, count, x, y, backupX, backupY, lastAction) VALUES (@accountId, @type, @interval, @amt, @count, @x, @y, @altX, @altY, @lastAction)", con);
                        command.Parameters.AddWithValue("@lastAction", new DateTime());
                    }
                    else
                    {
                        command = new SqlCeCommand("UPDATE schedules SET accountId = @accountId, type = @type, interval = @interval, amount = @amt, count = @count, x = @x, y = @y, backupX = @altX, backupY = @altY, lastAction = @lastAction WHERE id = @id", con);
                        command.Parameters.AddWithValue("@lastAction", task.LastAction);
                        command.Parameters.AddWithValue("@id", task.Id);
                    }

                    command.Parameters.AddWithValue("@accountId", task.Account.Id);
                    command.Parameters.AddWithValue("@type", (int)task.Type);
                    command.Parameters.AddWithValue("@interval", task.Interval);
                    command.Parameters.AddWithValue("@amt", task.Amount);
                    command.Parameters.AddWithValue("@count", task.Count);
                    command.Parameters.AddWithValue("@x", task.X);
                    command.Parameters.AddWithValue("@y", task.Y);
                    command.Parameters.AddWithValue("@altX", task.BackupX);
                    command.Parameters.AddWithValue("@altY", task.BackupY);
                    command.ExecuteNonQuery();

                    if (task.Id == 0)
                    {
                        command = new SqlCeCommand("SELECT last_insert_rowid()", con);
                        task.Id = Convert.ToInt32(command.ExecuteScalar());
                    }

                    obj = task;
                }
                else if (obj is EmulatorInstance)
                {
                    EmulatorInstance emulator = (EmulatorInstance)obj;

                    if (emulator == null)
                    {
                        emulator = emulator;
                    }

                    if (emulator.Id == 0)
                    {
                        command = new SqlCeCommand("INSERT INTO emulators (type, windowName, command, lastKnownAccountId) VALUES (@type, @windowName, @command, @accountId)", con);
                    }
                    else
                    {
                        command = new SqlCeCommand("UPDATE emulators SET type = @type, windowName = @windowName, command = @command, lastKnownAccountId = @accountId WHERE id = @id", con);
                        command.Parameters.AddWithValue("@id", emulator.Id);
                    }

                    command.Parameters.AddWithValue("@type", (int)emulator.Type);
                    command.Parameters.AddWithValue("@windowName", emulator.WindowName);
                    command.Parameters.AddWithValue("@command", emulator.Command);
                    command.Parameters.AddWithValue("@accountId", emulator.LastKnownAccount == null ? 0 : emulator.LastKnownAccount.Id);
                    command.ExecuteNonQuery();

                    if (emulator.Id == 0)
                    {
                        command = new SqlCeCommand("SELECT last_insert_rowid()", con);
                        emulator.Id = Convert.ToInt32(command.ExecuteScalar());
                    }

                    obj = emulator;
                }
            }
            catch (SqlCeException e)
            {
                /*if (e.ErrorCode == SQLiteErrorCode.Constraint_Check)
                {
                    //name already in use
                }*/
            }
            finally
            {
                command.Dispose();
            }

            con.Close();

            return obj;
        }

        public static void DeleteObject(DataObject obj)
        {
            if (obj.Id > 0)
            {
                SqlCeConnection con = GetNewConnection();
                con.Open();

                SqlCeCommand command = null;

                try
                {
                    if (obj is Account)
                    {
                        Account account = (Account)obj;

                        command = new SqlCeCommand("DELETE FROM accounts WHERE id = @id", con);
                        command.Parameters.AddWithValue("@id", account.Id);
                        command.ExecuteNonQuery();
                    }
                    else if (obj is ScheduleTask)
                    {
                        ScheduleTask task = (ScheduleTask)obj;

                        command = new SqlCeCommand("DELETE FROM schedules WHERE id = @id", con);
                        command.Parameters.AddWithValue("@id", task.Id);
                        command.ExecuteNonQuery();
                    }
                    else if (obj is EmulatorInstance)
                    {
                        EmulatorInstance emulator = (EmulatorInstance)obj;

                        command = new SqlCeCommand("DELETE FROM emulators WHERE id = @id", con);
                        command.Parameters.AddWithValue("@id", emulator.Id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException e)
                {

                }

                command.Dispose();
                con.Close();
            }
        }

        public static void InsertLog(int type, string desc, string detail, byte[] data)
        {
            SqlCeConnection con = GetNewConnection();
            con.Open();

            using (SqlCeCommand command = new SqlCeCommand("INSERT INTO log (type, desc, detail, data) VALUES (@type, @desc, @detail, @data)", con))
            {
                try
                {
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@detail", detail);
                    command.Parameters.AddWithValue("@data", data);
                    command.ExecuteNonQuery();
                }
                catch (SqlCeException e)
                {
                    e = e;
                }
            }

            con.Close();
        }

        public static List<DataObject> GetObjects<T>()
        {
            List<DataObject> list = new List<DataObject>();

            SqlCeConnection con = GetNewConnection();
            con.Open();

            SqlCeCommand command = null;
            SqlCeDataReader reader = null;

            try
            {
                if (typeof(T) == typeof(ScheduleTask))
                {
                    command = new SqlCeCommand("SELECT id, accountId, type, interval, amount, count, x, y, backupX, backupY, lastAction FROM schedules", con);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ScheduleTask task = new ScheduleTask(reader.GetInt32(0), new Account(reader.GetInt32(1)), (ScheduleType)reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetDateTime(10));
                        list.Add(task);
                    }
                }
                else if (typeof(T) == typeof(Account))
                {
                    command = new SqlCeCommand("SELECT id, name, username, email, password, priority, foodNegativeAmt, lastLogin, lastLogout FROM accounts", con);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Account account = new Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), (AccountPriority)reader.GetInt32(5), reader.GetInt32(6), reader.GetDateTime(7), reader.GetDateTime(8));
                        list.Add(account);
                    }
                }
                else if (typeof(T) == typeof(EmulatorInstance))
                {
                    command = new SqlCeCommand("SELECT id, type, windowName, command, lastKnownAccountId FROM emulators", con);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EmulatorInstance emulator = new EmulatorInstance(reader.GetInt32(0), (EmulatorType)reader.GetInt32(1), reader.GetString(2), reader.GetString(3), new Account(reader.GetInt32(4)));
                        list.Add(emulator);
                    }
                }
            }
            catch (SqlCeException e)
            {
                /*if (e.ErrorCode == Constraint_Check)
                {
                    //name already in use
                }*/
            }
            catch (Exception e)
            {
                e = e;
            }
            finally
            {
                command.Dispose();

                if (reader != null)
                {
                    reader.Dispose();
                }
            }

            con.Close();

            return list;
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            SqlCeCommand command = new SqlCeCommand("SELECT id, name, username, email, password, priority, foodNegativeAmt, lastLogin, lastLogout FROM accounts", Connection);
            SqlCeDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(new Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), (AccountPriority)reader.GetInt32(5), reader.GetInt32(6), reader.GetDateTime(7), reader.GetDateTime(8)));
            }

            return accounts;
        }
    }
}
