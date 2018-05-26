using InternetBanking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace InternetBanking.Data
{
    public class HistoryStateDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public HistoryStateDatabaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<HistoryState>();
        }

        public HistoryState GetHistoryState()
        {
            lock (locker)
            {
                if (database.Table<HistoryState>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<HistoryState>().First();
                }
            }
        }

       
        public int SaveHistoryState(HistoryState HistoryState)
        {
            lock (locker)
            {
                if (HistoryState.Id != 0)
                {
                    database.Update(HistoryState);
                    return HistoryState.Id;
                }
                else
                {
                    return database.Insert(HistoryState);
                }
            }
        }

        public int DeleteHistoryState(int id)
        {
            lock (locker)
            {
                return database.Delete<HistoryState>(id);

            }
        }

        public int DeleteAllFromDatabase()
        {
            lock (locker)
            {
                return database.DeleteAll<HistoryState>();
            }
        }

        public List<HistoryState> GetStatesByUserId(int id)
        {
            lock (locker)
            {
                if (database.Table<HistoryState>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<HistoryState>().Where(h => h.UserId == id).ToList();
                }
            }
        }
    }
}

