using BigMammaPizzaGroup.Services;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BigMammaPizzaGroup.Model
{
    public class Items
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }

        public Items()
        {
            Name = "";
            Price = 0;
        }
        public Items(string name, double price)
        {
            Price = price;
            Name = name;
        }

        //tostring 
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Number)}={Number.ToString()}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
