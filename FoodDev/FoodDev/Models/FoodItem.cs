using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDev.Models
{
    public class FoodItem
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public string ImageUrl { get; set; }


    }
}
