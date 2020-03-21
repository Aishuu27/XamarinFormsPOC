using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App1.Droid.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using App1;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class Display : ContentPage
    {
        public SQLiteConnection _conn;
        public Registration regmodel;
        public Display()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _conn = DependencyService.Get<ISQLite>().GetConnection();
            _conn.CreateTable<Registration>();
            DisplayDetails();
        }
        public void DisplayDetails()
        {

            var details = (from x in _conn.Table<Registration>() select x).ToList();
            myListView.ItemsSource = details;
        }
    }
}