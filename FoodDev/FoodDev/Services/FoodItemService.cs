using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using FoodDev.Models;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using FoodDev.Helpers;

namespace FoodDev.Services
{
    public class FoodItemService : IFoodItemService
    {
        FirebaseClient client;

        public FoodItemService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(f => new FoodItem
                {
                    ProductId = f.Object.ProductId,
                    CategoryId = f.Object.CategoryId,
                    Name = f.Object.Name,
                    Description = f.Object.Description,
                    Weight = f.Object.Weight,
                    ImageUrl = f.Object.ImageUrl
                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryId == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;

        }


        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductId).Take(3);
            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByQueryAsync(string searchText)
        {
            var foodItemsByQuery = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(
                p => p.Name.Contains(searchText)).ToList();
            foreach (var item in items)
            {
                foodItemsByQuery.Add(item);
            }
            return foodItemsByQuery;
        }
    }
}
