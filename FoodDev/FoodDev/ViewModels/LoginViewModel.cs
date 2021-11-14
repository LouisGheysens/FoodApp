using FoodDev.Views;
using FoodDev.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using FoodDev.Services;
using Xamarin.Essentials;
using FoodDev.Helpers;

namespace FoodDev.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }


        private bool _Disable;
        public bool Disable
        {
            set
            {
                this._Disable = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Disable;
            }
        }

        public Command LoginCommand { get; set; }

        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            Disable = false;
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await AnalysticsHelper.TrackEventAsync($"Registreer commando voor {Username}");
                //var userService = new UserService();
                var userService = DependencyService.Get<IUserService>();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "Gebruikers is geregistreerd!", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Gebruiker bestaat al!", "OK");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                var properties = new Dictionary<string, string>
                {
                    {"username", Username }
                };
                await CrashesHelper.TrackError(e, properties);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await AnalysticsHelper.TrackEventAsync($"Login commando voor {Username}");
                //var userService = new UserService();
                var userService = DependencyService.Get<IUserService>();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Verkeerde inloggegevens", "OK");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                var properties = new Dictionary<string, string>
                {
                    {"username", Username }
                };
                await CrashesHelper.TrackError(e, properties);
            }
            finally
            {
                IsBusy = false;
            
            
            }
            }
    }
}
