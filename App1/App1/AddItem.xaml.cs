
using App1.Droid.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        public SQLiteConnection _conn;
        //public AddIte regmodel;
        public AddItem()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _conn = DependencyService.Get<ISQLite>().GetConnection();
           _conn.CreateTable<AddItems>();

        }

        private void AddButton_clicked(object sender, EventArgs e)
        {
            AddItems add = new AddItems
            {
                productname = Productname.Text,
                productdescription= Productdescription.Text
            };
            int x = 0;
            x = _conn.Insert(add);
            if (x == 1)
            {
                 DisplayAlert("Submitted", "Successflly added an item", "Ok");
                Application.Current.MainPage = new NavigationPage(new MenuPage());
            }
            else
            {
                DisplayAlert("R!!!", "Please try again", "ERROR");
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new NavigationPage(new MenuPage());
            return true;
        }
    }
}