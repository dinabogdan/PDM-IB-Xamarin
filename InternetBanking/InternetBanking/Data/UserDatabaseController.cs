using InternetBanking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InternetBanking.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public UserDatabaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public User GetUser() {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }
            }
        }

        public User GetUserByUsernameAndPassword(User user)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().Where
                        (u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();

                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);

            }
        }

        public int DeleteAllFromDatabase()
        {
            lock (locker)
            {
                return database.DeleteAll<User>();
            }
        }

        public User GetUserById(int id)
        {
            lock (locker)
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Find<User>(id);
                }
        }
    }
}
