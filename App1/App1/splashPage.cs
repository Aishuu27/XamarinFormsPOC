using App1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

public class SplashPage:ContentPage
{	
	Image splash_logo;
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
	}
	protected async override void OnAppearing() {
		base.OnAppearing();
		await splash_logo.ScaleTo(1,5000);
		Application.Current.MainPage = new NavigationPage(new MainPage());

	}

	
}
