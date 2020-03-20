using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLitePCL;
using System.IO;
using Xamarin.Forms;
using App1.Droid;

[assembly: Dependency(typeof(SQliteDroid))]
namespace App1.Droid
{
    public class SQliteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "USerData.db3";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}
