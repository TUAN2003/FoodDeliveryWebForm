using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_LTW_17.Models
{
    public class Bill
    {
        public int IdRestaurant { get; set; }
        public List<FoodOrder> FoodOrders { get; set; }
        public string PhoneCustomer { get; set; }
        public string AddressCustomer { get; set; }
        public int TotalPrice { get; set; }
        public string Note { get; set; }
        public string Method { get; set; }

        public Bill() { }
        public Bill(int idRestaurant, List<FoodOrder> foodOrders, string phoneCustomer, string addressCustomer, int totalPrice, string note, string method)
        {
            IdRestaurant = idRestaurant;
            FoodOrders = foodOrders;
            PhoneCustomer = phoneCustomer;
            AddressCustomer = addressCustomer;
            TotalPrice = totalPrice;
            Note = note;
            Method = method;
        }
    }
}