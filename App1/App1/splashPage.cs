using App1;
using App1.Droid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Data;

public class SplashPage:ContentPage
{	
	Image splash_logo;
	SQLiteConnection database;

	public SplashPage()
	{

		var sub = new AbsoluteLayout();
		splash_logo = new Image {
			Source = "splash_logo",
			HeightRequest = 100,
			WidthRequest = 100
		};
		AbsoluteLayout.SetLayoutFlags(splash_logo, AbsoluteLayoutFlags.PositionProportional);
		AbsoluteLayout.SetLayoutBounds(splash_logo, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

		sub.Children.Add(splash_logo);
		this.BackgroundColor = Color.FromHex("#FFFFFF");
		this.Content = sub;

		database = DependencyService.Get<ISQLite>().GetConnection();
		database.CreateTable<Registration>();
	}
	
	protected async override void OnAppearing() {
		base.OnAppearing();
		await splash_logo.ScaleTo(1,5000);

		if(database.Table<Registration>().Count() == 0) {

			Application.Current.MainPage = new NavigationPage(new MainPage());
		}
		else
		{
			Application.Current.MainPage = new NavigationPage(new MenuPage());

		}
		

	}

	
}
