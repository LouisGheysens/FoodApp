using Firebase.Database;
using Firebase.Database.Query;
using FoodDev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodDev.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://fooddev-fe397-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Fruit",
                    CategoryPoster = "MainBurger",
                    //Fruit foto?
                    ImageUrl = "Burger.png"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Choco",
                    CategoryPoster = "Choco producten",
                    //Choco foto?
                    ImageUrl = "Pizza.png"

                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Confituren",
                    CategoryPoster = "MainDessert.png",
                    //Confituur foto?
                    ImageUrl = "Dessert.png"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Siropen knijpfles",
                    CategoryPoster =  "MainDessert.png",
                    //Siropen foto?
                    ImageUrl = "Dessert.png"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Sauzen knijpfles",
                    CategoryPoster = "MainPizza.png",
                    ImageUrl = "Pizza.png"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Braadvetten",
                    CategoryPoster = "MainDessert.png",
                    //Braadvet foto?
                    ImageUrl = "Dessert.png"
                }
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }
    }
}
