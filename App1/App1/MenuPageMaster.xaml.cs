using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView;

        public MenuPageMaster()
        {
            InitializeComponent();

            BindingContext = new MenuPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuPageMasterViewModel : INotifyPropertyChanged
        {
            private const string V = "Add Item";
            

            public ObservableCollection<MenuPageMasterMenuItem> MenuItems { get; set; }

            public MenuPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuPageMasterMenuItem>(new[]
                {
                    new MenuPageMasterMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainPage)},
                    new MenuPageMasterMenuItem { Id = 1, Title = "Profile", TargetType=typeof(MyProfile)},
                    new MenuPageMasterMenuItem { Id = 2, Title = "Add item" ,TargetType=typeof(AddItem) },
                    new MenuPageMasterMenuItem { Id = 3, Title = "About Us",TargetType=typeof(About)},
                    
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}