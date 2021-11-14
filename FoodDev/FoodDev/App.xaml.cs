using FoodDev.Helpers;
using FoodDev.Models;
using FoodDev.Services;
using FoodDev.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodDev
{
    public partial class App : Application
    {

        public static bool isCartTableCreated = Preferences.Get("isCartItemTableCreated", false);

        public App()
        {
            Xamarin.Forms.Device.SetFlags(new string[]
            {
                "AppTheme_Experimental",
                "MediaElement_Experimental"
            });

            InitializeComponent();

            Crashes.SetEnabledAsync(true);
            Analytics.SetEnabledAsync(true);

            //MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());

            string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }
        }

        protected override async void OnStart()
        {
            AppCenter.Start($"android={Constants.androidAppCenterKey}" +
                $"ios={Constants.iOSAppCenterKey}", typeof(Crashes), typeof(Analytics));

            if (await Crashes.HasCrashedInLastSessionAsync())
            {

            }

            if(isCartTableCreated == false)
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                cn.CreateTable<CartItem>();
                cn.Close();
                Preferences.Set("isCartItemTableCreated", true);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
