using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_LTW_17.Models
{
    public class Food : IComparable<Food>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }

        public Food() { }
        public Food(string name, string description, int price, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
        }
        public Food(int id, string name, string description, int price, string image, string category) : this(name, description, price, image)
        {
            Id = id;
            Category = category;
        }

        public int CompareTo(Food other)
        {
            return Category.CompareTo(other.Category);
        }

        public override int GetHashCode()
        {
            return Category.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj is Food)
            {
                Food u = (Food)obj;
                return u.Id == Id;
            }
            return false;
        }
        public override string ToString()
        {
            return Id + ";" + Name + ";" + Description;
        }
    }
}