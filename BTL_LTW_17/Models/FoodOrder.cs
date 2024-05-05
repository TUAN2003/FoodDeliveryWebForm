using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_LTW_17.Models
{
    public class FoodOrder
    {
        public Food Item { get; set; }
        public int Quantity { get; set; }

        public FoodOrder()
        {

        }

        public FoodOrder(Food item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}