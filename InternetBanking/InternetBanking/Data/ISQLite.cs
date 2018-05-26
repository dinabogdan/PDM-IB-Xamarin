using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Data
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
