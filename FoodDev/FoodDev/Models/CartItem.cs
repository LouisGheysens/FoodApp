using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodDev.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }
        public Person Client { get; set; }
    }
}
