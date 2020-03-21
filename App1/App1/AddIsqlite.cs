using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    interface AddIsqlite
    {
        SQLiteConnection GetConnection();
    }
}
