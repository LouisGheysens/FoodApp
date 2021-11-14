using FoodDev.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FoodDev.Services
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetFoodItemsAsync();
        Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID);
        Task<ObservableCollection<FoodItem>> GetFoodItemsByQueryAsync(string searchText);
        Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync();


    }
}