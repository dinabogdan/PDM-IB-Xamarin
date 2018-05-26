using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InternetBanking.Data;
using InternetBanking.Droid.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]

namespace InternetBanking.Droid.Data
{
    class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "InternetBanking.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}