//using mini_big_mammas_pizzaria.Model;
//using System.Text;

//namespace mini_big_mammas_pizzaria.Services
//{
//    public class PizzaRepository
//    {

//        //property
//        public Dictionary<int, Pizza> Menukort { get; set; }

//        //constructor
//        public PizzaRepository()
//        {
//            Menukort = new Dictionary<int, Pizza>();
//            PopulatePizzaRepository();
//        }

//        //Methods
//        public void PopulatePizzaRepository()
//        {
//            Menukort.Clear();
//            Menukort.Add(1, new Pizza(1, "Margherita", 69, ["tomato", "cheese"]));
//            Menukort.Add(2, new Pizza(2, "Vesuvio", 75, ["tomato", "cheese", "ham"]));
//            Menukort.Add(3, new Pizza(3, "Capricciosa", 80, ["tomato", "cheese", "ham", "mushrooms"]));
//            Menukort.Add(4, new Pizza(4, "Calzone", 80, ["baked pizza with tomat", "cheese", "ham", "mushrooms"]));
//            Menukort.Add(5, new Pizza(5, "Quattro Stagioni", 85, ["tomato", "cheese", "ham", "mushrooms", "shrimp", "peppers"]));
//            Menukort.Add(6, new Pizza(6, "Marinara", 85, ["tomato", "cheese", "shrimp", "mussels", "garlic"]));
//            Menukort.Add(7, new Pizza(7, "Vegetatian", 80, ["tomato", "cheese", "vegetables"]));
//            Menukort.Add(8, new Pizza(8, "Italiana", 75, ["tomato", "cheese", "onion", "meat sauce"]));
//            Menukort.Add(9, new Pizza(9, "Gorgonzola", 85, ["tomato", "gorgonzola", "onion", "mushroom"]));
//            Menukort.Add(10, new Pizza(10, "Contadina", 75, ["tomato", "cheese", "mushrooms", "olives"]));
//            Menukort.Add(11, new Pizza(11, "Naples", 79, ["tomato", "cheese", "anchovies", "olives"]));
//            Menukort.Add(12, new Pizza(12, "Vichinga", 80, ["tomato", "cheese", "ham", "mushrooms", "peppers", "garlic", "chili"]));
//            Menukort.Add(13, new Pizza(13, "Calzone Special", 80, ["tomato", "cheese", "shrimp", "ham", "meat sauce"]));
//            Menukort.Add(14, new Pizza(14, "Esotica", 80, ["tomato", "cheese", "ham", "shrimp", "pinapple"]));
//            Menukort.Add(15, new Pizza(15, "Tonno", 85, ["tomato", "cheese", "tuna", "shrimp"]));
//            Menukort.Add(16, new Pizza(16, "Sardegna", 80, ["tomato", "cheese", "cocktail sausages", "bacon", "onions", "eggs"]));
//            Menukort.Add(17, new Pizza(17, "Romana", 78, ["tomato", "cheese", "ham", "bacon", "onion"]));
//            Menukort.Add(18, new Pizza(18, "Sole", 78, ["tomato", "cheese", "ham", "bacon", "eggs"]));
//            Menukort.Add(19, new Pizza(19, "Big Mamma", 90, ["tomato", "gorgonzola", "shrimp", "asparagus", "parma ham"]));
//            Menukort.Add(20, new Pizza(20, "Dej i pose", 69, ["Pizzadej"]));
//        }

//        public Pizza DeleteItem(int pizza)
//        {
//            if (Menukort.ContainsKey(pizza))
//            {
//                Pizza slettetpizza = Menukort[pizza];
//                Menukort.Remove(pizza);
//                return slettetpizza;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public Pizza AddItem(Pizza pizza /*int number, string name, double price, List<string> topping*/)
//        {
//            Menukort.Add(pizza.Number, pizza/*number, new Pizza(number, name, price, topping*/);
//            return pizza /*Menukort[number]*/;
//        }

//        public List<Pizza> GetAllItems()
//        {
//            return Menukort.Values.ToList();
//        }

//        public override string ToString()
//        {
//            String Output = String.Join(", ", Menukort.Values);

//            return $"{{{nameof(Menukort)}={Output}}}";
//        }

//        //Tostring


//    }
//}

