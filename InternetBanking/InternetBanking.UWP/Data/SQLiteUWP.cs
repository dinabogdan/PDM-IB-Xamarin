using InternetBanking.Data;
using InternetBanking.UWP.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteUWP))]

namespace InternetBanking.UWP.Data
{
    public class SQLiteUWP : ISQLite
    {
        public SQLiteUWP() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "InternetBanking.db3";
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
