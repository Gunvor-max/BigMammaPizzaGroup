using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.Xml.Linq;

namespace BigMammaPizzaGroup.Services
{
    public class Order
    {
        private Customer Customer {  get; set; }
        private List<Items> Food = new List<Items>();
        public bool TakeAway {  get; set; }
        public Order()
        {
            
        }
        public Order(Customer customer, List<Items> food)
        {
            Customer = customer;
            Food = food;
        }

        public double GetPrice()
        {
            double price = 0;
            foreach (Items menuitem in Food)
            {
                price += menuitem.Price*1.25;
            }
            return TakeAway ? price + 40: price;
        }
        public string GetFood()
        {
            string food = "";
                foreach(Items item in Food)
            {
                food += item == Food[Food.Count-1] ? item : item + ", ";
            }
            return food;
        }
        
        public override string ToString()
        {
            return $"{Customer}, {GetFood()}";
         
        }
    }
}
