using System.Threading.Tasks;

namespace FoodDev.Services
{
    public interface IOrderService
    {
        Task<string> PlaceOrderAsync();
    }
}