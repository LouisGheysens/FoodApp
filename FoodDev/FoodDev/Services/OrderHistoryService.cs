 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using FoodDev.Models;
using Xamarin.Essentials;
using System.Linq;
using FoodDev.Helpers;

namespace FoodDev.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        FirebaseClient client;
        List<OrdersHistory> UserOrders;

        public OrderHistoryService()
        {
            client = new FirebaseClient(Constants.URL);
            UserOrders = new List<OrdersHistory>();
        }

        public async Task<List<OrdersHistory>> GetOrderDetailsAsync()
        {
            var uname = Preferences.Get("Username", "Guest");

            var orders = (await client.Child("Orders")
                .OnceAsync<Order>())
                .Where(o => o.Object.Username.Equals(uname))
                .Select(o => new Order()
                {
                    OrderId = o.Object.OrderId,
                    ReceipId = o.Object.ReceipId

                }).ToList();

            foreach (var order in orders)
            {
                OrdersHistory oh = new OrdersHistory();
                oh.OrderId = order.OrderId;
                oh.ReceipId = order.ReceipId;

                var orderDetails = (await client.Child("OrderDetails")
                    .OnceAsync<OrderDetails>())
                    .Where(o => o.Object.OrderId.Equals(order.OrderId))
                    .Select(o => new OrderDetails()
                    {
                        OrderId = o.Object.OrderId,
                        OrderDetailId = o.Object.OrderDetailId,
                        ProductId = o.Object.ProductId,
                        ProductName = o.Object.ProductName
                    }).ToList();

                oh.AddRange(orderDetails);

                UserOrders.Add(oh);
            }
            return UserOrders;

        }
    }
}
