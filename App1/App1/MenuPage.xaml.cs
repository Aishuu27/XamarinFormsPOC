using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
       // MenuPageMaster masterPage;
        public MenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //masterPage = new MenuPageMaster();
            // Master = masterPage;
            // Detail = new NavigationPage(new About());
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageMasterMenuItem;
            if (item != null)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                Console.WriteLine("Page: " + page);
               Detail = new NavigationPage(page);
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }   

            //
            //
 
        }
    }
}