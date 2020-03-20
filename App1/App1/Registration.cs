using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace App1.Droid.Model
{
    public class Registration
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string residance { get; set; }
        public string dob{ get; set; }
        public string email { get; set; }
        public Registration()
        {

        }
    }
}
