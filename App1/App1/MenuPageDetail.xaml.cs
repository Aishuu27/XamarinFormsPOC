using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using App1.Droid.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageDetail : ContentPage
    {
        public SQLiteConnection _conn;
        

        public MenuPageDetail()
        {
           InitializeComponent();
            _conn = DependencyService.Get<ISQLite>().GetConnection();
            _conn.CreateTable<AddItems>();
            Displayaddeditems();

            
        }
        public void Displayaddeditems()
        {
            if (_conn.Table<AddItems>().Count() == 0)
            {

                message.Text = "No Items Added";
            
            }
            else {
                message.Text = "Items Added";
                var data = (from x in _conn.Table<AddItems>() select x).ToList();
                myListView.ItemsSource = data;
            }
                
        }
    }
}