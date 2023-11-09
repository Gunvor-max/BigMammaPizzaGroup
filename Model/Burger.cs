namespace BigMammaPizzaGroup.Model
{
    public class Burger
    {
        //properties
        public string Name { get; set; }
        public double Price { get; set; }
        public BunType Bun { get; set; }
        public List <string> Description = new List <string> ();
            

        //default constructor
        public Burger()
            { 
                Bun = BunType.Fuldkorn;
            }

        //Constructor
        public Burger(string name, double price, BunType type, List<string> description)
        {
            Name = name;
            Price = price;
            Bun = type;
            Description = description; 

        }
        public string AddTopping(string topping)
        {
            Description.Add(topping);
            Price += 10;
            return topping;
        }
        public string GetToppings()
        {
            string topping = "";
            foreach (string top in Description)
            {
                topping += top == Description[Description.Count-1] ? top : top + ", ";
            }
            return topping;
        }
        //Tostring
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Bun)}={Bun.ToString()}}}";
        }

    }
        public enum BunType { Fuldkorn, Portobello, Ciabatta, Brioche }
    }
