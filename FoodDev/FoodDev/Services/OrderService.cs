using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodDev.Helpers;
using FoodDev.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodDev.Services
{
    public class OrderService : IOrderService
    {
        FirebaseClient client;

        public OrderService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();

            var orderId = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Guest");

            foreach (var item in data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderId = orderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                };
                await client.Child("OrderDetails").PostAsync(od);
            }
            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = orderId,
                    Username = uname
                });
            return orderId;
        }





    }
}
