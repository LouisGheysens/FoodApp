using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodDev.Models;
using Xamarin.Essentials;
using System.Linq;
using Firebase.Database;

namespace FoodDev.Services
{
    public class PersonService 
    {
        FirebaseClient client;
        public PersonService()
        {
            client = new FirebaseClient("https://fooddevtwo-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        //public async Task<string> PersonDataAsc()
        //{

        //}


        //public async Task<Person> GetPerson(int personId)
        //{
        //    var allPersons = await GetAllPersons();
        //    await FileBase
        //      .Child("Persons")
        //      .OnceAsync<Person>();
        //    return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        //}


    }
}
