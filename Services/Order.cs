using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.Xml.Linq;

namespace BigMammaPizzaGroup.Services
{
    public class Order
    {
        public Customer Customer {  get; set; }
        public List<Items> Pizzas { get; set; } = new List<Items>();
        public List<Burger> Burgers { get; set; } = new List<Burger>();
        public List<Drink> Drinks { get; set; } = new List<Drink>();
        public bool TakeAway {  get; set; }
        public Order()
        {
            
        }
        public Order(Customer customer, List<Items> pizza, List<Burger> burger, List<Drink> drink)
        {
            Customer = customer;
            Pizzas = pizza;
            Burgers = burger;
            Drinks = drink;

        }

        public double GetPricePizza()
        {
            double price = 0;
            foreach (Items menuitem in Pizzas)
            {
                price += menuitem.Price*1.25;
            }
            return price;
        }
        public string GetPizzas()
        {
            string food = "";
                foreach(Items item in Pizzas)
            {
                food += item == Pizzas[Pizzas.Count-1] ? item : item + ", ";
            }
            return food;
        }
        
        public override string ToString()
        {
            return $"{Customer}";
         
        }
    }
}
