using Android.App;
using Android.Content.PM;
using App1.Droid.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        public SQLiteConnection _conn;
        public Registration regmodel;
        public AddItem()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _conn = DependencyService.Get<ISQLite>().GetConnection();
            _conn.CreateTable<AddItems>();
        }

        private async void AddButton_clicked(object sender, EventArgs e)
        {

        }
    }
}