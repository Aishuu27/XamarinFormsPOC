using App1.Droid;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SQLite;
using System.Text;
using System.IO;

[assembly: Dependency(typeof(AddSqliteDroid))]

namespace App1.Droid
{ 
    public class AddSqliteDroid :AddIsqlite
    {
        public AddSqliteDroid(){
            var dbase = "Additemdb.db3";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }

        public SQLiteConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }

}
