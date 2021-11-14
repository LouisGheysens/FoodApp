using FoodDev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDev.Services
{
    public interface ICategoryDataService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}