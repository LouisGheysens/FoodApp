using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDev.Models
{
    public class UserCartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }

        public Person Client { get; set; }
    }
}
