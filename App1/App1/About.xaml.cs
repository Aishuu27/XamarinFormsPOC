﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new NavigationPage(new MenuPage());
            return true;
        }
    }
}