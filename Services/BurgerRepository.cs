//using mini_big_mammas_pizzaria.Model;
//namespace mini_big_mammas_pizzaria.Services
//{
//    public class BurgerRepository
//    {
//        Dictionary<int, Burger> Menukort = new Dictionary<int, Burger>();

//        public BurgerRepository()
//        {
//            PopulateBurgerRepository();
//        }
//        public void PopulateBurgerRepository()
//        {
//            Menukort.Clear();
//            Menukort.Add(1, new Burger(1, "Big Mac", 40, BunType.Ciabatta, ["tomato", "beef"]));
//            Menukort.Add(2, new Burger(2, "Tasty Cheese", 25, BunType.Ciabatta, ["cheese"]));
//            Menukort.Add(3, new Burger(3, "Hamburger", 25, BunType.Ciabatta, ["ham"]));
//        }

//        public Burger DeleteItem(int burger)
//        {
//            if(Menukort.ContainsKey(burger))
//            {
//                Burger slettetKunde = Menukort[burger];
//                Menukort.Remove(burger);
//                return slettetKunde;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public Burger AddItem(int number, string name, BunType type, double price, List<string> description)
//        {

//            Menukort.Add(number, new Burger(number, name, price, type, description));
//            return Menukort[number];
//        }

//        public List<Burger> GetAllItems()
//        {
//            return Menukort.Values.ToList();
//        }

//        public override string ToString()
//        {
//            return $"{{}}";
//        }
//    }
//}
