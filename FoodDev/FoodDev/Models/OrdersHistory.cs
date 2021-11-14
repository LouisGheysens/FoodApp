using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDev.Models
{
    public class OrdersHistory: List<OrderDetails>
    {
        public string OrderId { get; set; }

        public string Username { get; set; }

        public string ReceipId { get; set; }
    }
}
