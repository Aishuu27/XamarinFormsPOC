using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SQLite;

using App1.Droid;
using App1.Droid.Model;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public SQLiteConnection _conn;
        public Registration regmodel;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _conn = DependencyService.Get<ISQLite>().GetConnection();
            _conn.CreateTable<Registration>();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
           
            Registration reg = new Registration
            {
                name = Name.Text,
                phone = Phone.Text,
                residance = Residance.Text,
                dob = DOB.Date.ToString(),
                email = Email.Text
              
            };
            
            int x = 0;
            try
            {
                if (reg.name!= null && reg.phone != null && reg.residance != null && reg.dob != null && reg.email != null) {
                 
                    x = _conn.Insert(reg);
                }
                else
                {
                    DisplayAlert("ERROR", "Please Enter The Details", "Cancel");
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (x == 1)
            {
                DisplayAlert("Registration", "Thanks for Registration", "Ok");
                Application.Current.MainPage = new NavigationPage(new MenuPage());

            }
            else
            {
                DisplayAlert("Registration Failled!!!", "Please try again", "ERROR");
            }

        }

        
    }
}
