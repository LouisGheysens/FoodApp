using FoodDev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDev.Services
{
    public interface IOrderHistoryService
    {
        Task<List<OrdersHistory>> GetOrderDetailsAsync();
    }
}