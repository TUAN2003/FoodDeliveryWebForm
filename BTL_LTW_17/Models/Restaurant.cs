using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace BTL_LTW_17.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public List<string> Categorys { get; set; }
        public List<Food> Menu { get; set; }
        public float Rate { get; set; }
        public string Promotion { get; set; }
        public int Time { get; set; }
        public float Distance { get; set; }

        public Restaurant() { }
        public Restaurant(int id, string name, string address, string image, string promotion)
        {
            Id = id;
            Name = name;
            Address = address;
            Image = image;
            Promotion = promotion;
        }
        public Restaurant(int id, string name, string address, string image, string promotion, List<string> categorys, List<Food> menu) : this(id, name, address, image, promotion)
        {
            Categorys = categorys;
            Menu = menu;
        }

        public Restaurant(int id, string name, string address, string image, string promotion, List<string> categorys, List<Food> menu, float rate, int time, float distance) : this(id, name, address, image, promotion, categorys, menu)
        {
            Rate = rate;
            Time = time;
            Distance = distance;
        }
    }
}