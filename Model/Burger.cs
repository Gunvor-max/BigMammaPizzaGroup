namespace BigMammaPizzaGroup.Model
{
    public class Burger
    {
        //properties
        public string Name { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public BunType Bun { get; set; }
        public List <string> DescriptionList = new List <string> ();
        public string Description { get; set; } = "";
            

        //default constructor
        public Burger()
            { 
                Bun = BunType.Fuldkorn;
            }

        //Constructor
        public Burger(int number, string name, double price, BunType type, List<string> description)
        {
            Number = number;
            Name = name;
            Price = price;
            Bun = type;
            DescriptionList = description; 

        }
        public string AddTopping(string topping)
        {
            DescriptionList.Add(topping);
            Price += 10;
            return topping;
        }
        public string GetToppings()
        {
            string topping = "";
            foreach (string top in DescriptionList)
            {
                topping += top == DescriptionList[DescriptionList.Count-1] ? top : top + ", ";
            }
            return topping;
        }

        //Tostring
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Number)}={Number.ToString()}, {nameof(Bun)}={Bun.ToString()}}}";
        }

    }
        public enum BunType { Fuldkorn, Portobello, Ciabatta, Brioche }
    }
