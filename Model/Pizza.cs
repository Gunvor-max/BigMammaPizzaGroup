using BigMammaPizzaGroup.Services;

namespace BigMammaPizzaGroup.Model
{
    public class Pizza:Items
    {
        //Properties

        public List<string> Toppings = new List<string>();
        int Standard;


        public Pizza()
        {
        }
        //Constructor
        public Pizza(string name, double price, List<string>topping):base(name, price)
        {
            Toppings = topping;
            Standard = topping.Count;
        }
        public string AddTopping(string topping)
        {
            Toppings.Add(topping);
            Price += 10;
            return topping;
        }

        public string GetToppings()
        {
            string topping = "";
            foreach (string top in Toppings)
            {
                topping += top==Toppings[Toppings.Count-1] ? top : top + ", ";
            }
            return topping;
        }

        public override string ToString()
        {
            return $"{{{nameof(Number)}={Number.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(GetToppings)}={GetToppings().ToString()}}}";
        }


        //public override string ToString()
        //{

        //    return $"[{Number}, {Price}kr. {Name}, {GetToppings()}]";
        //}


        /*
        Pizza pizza1 = new Pizza(1, 69, "Margherita", ["tomato", "cheese"]);
        Pizza pizza2 = new Pizza(2, 75, "Vesuvio", ["tomato", "cheese", "ham"]);
        Pizza pizza3 = new Pizza(3, 80, "Capricciosa", ["tomato", "cheese", "ham", "mushrooms"]);
        Pizza pizza4 = new Pizza(4, 80, "Calzone", ["baked pizza with tomat", "cheese", "ham", "mushrooms"]);
        Pizza pizza5 = new Pizza(5, 85, "Quattro Stagioni", ["tomato", "cheese", "ham", "mushrooms", "shrimp", "peppers"]);
        Pizza pizza6 = new Pizza(6, 85, "Marinara", ["tomato", "cheese", "shrimp", "mussels", "garlic"]);
        Pizza pizza7 = new Pizza(7, 80, "Vegetatian", ["tomato", "cheese", "vegetables"]);
        Pizza pizza8 = new Pizza(8, 75, "Italiana", ["tomato", "cheese", "onion", "meat sauce"]);
        Pizza pizza9 = new Pizza(9, 85, "Gorgonzola", ["tomato", "gorgonzola", "onion", "mushroom"]);
        Pizza pizza10 = new Pizza(10, 75, "Contadina", ["tomato", "cheese", "mushrooms", "olives"]);
        Pizza pizza11 = new Pizza(11, 79, "Naples", ["tomato", "cheese", "anchovies", "olives"]);
        Pizza pizza12 = new Pizza(12, 80, "Vichinga", ["tomato", "cheese", "ham", "mushrooms", "peppers", "garlic", "chili"]);
        Pizza pizza13 = new Pizza(13, 80, "Calzone Special", ["tomato", "cheese", "shrimp", "ham", "meat sauce"]);
        Pizza pizza14 = new Pizza(14, 80, "Esotica", ["tomato", "cheese", "ham", "shrimp", "pinapple"]);
        Pizza pizza15 = new Pizza(15, 85, "Tonno", ["tomato", "cheese", "tuna", "shrimp"]);
        Pizza pizza16 = new Pizza(16, 80, "Sardegna", ["tomato", "cheese", "cocktail sausages", "bacon", "onions", "eggs"]);
        Pizza pizza17 = new Pizza(17, 78, "Romana", ["tomato", "cheese", "ham", "bacon", "onion"]);
        Pizza pizza18 = new Pizza(18, 78, "Sole", ["tomato", "cheese", "ham", "bacon", "eggs"]);
        Pizza pizza19 = new Pizza(19, 90, "Big Mamma", ["tomato", "gorgonzola", "shrimp", "asparagus", "parma ham"]);


        Console.WriteLine(pizza8);
        Console.WriteLine(pizza8.CalculateTotalPrice());
        pizza8.AddTopping("Bacon");
        pizza8.AddTopping("Onion");
        Console.WriteLine(pizza8);
        Console.WriteLine(pizza8.CalculateTotalPrice());
*/
    }
}
