using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodDev.Models;
using System.Linq;
using FoodDev.Helpers;
using Xamarin.Forms;
using FoodDev.Services;

[assembly:Dependency(typeof(UserService))]
namespace FoodDev.Services
{
    public class UserService : IUserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                    Password = passwd
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname).Where(u => u.Object.Password == passwd).FirstOrDefault();
            return (user != null);
        }
    }
}
