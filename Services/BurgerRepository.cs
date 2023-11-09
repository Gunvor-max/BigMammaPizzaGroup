using BigMammaPizzaGroup.Model;
namespace mini_big_mammas_pizzaria.Services
{
    public class BurgerRepository
    {
        Dictionary<int, Burger> MenukortBurger = new Dictionary<int, Burger>();

        public BurgerRepository()
        {
            PopulateBurgerRepository();
        }
        public void PopulateBurgerRepository()
        {
            MenukortBurger.Clear();
            MenukortBurger.Add(1, new Burger("Big Mac", 40, BunType.Ciabatta, ["tomato", "beef"]));
            MenukortBurger.Add(2, new Burger("Tasty Cheese", 25, BunType.Ciabatta, ["cheese"]));
            MenukortBurger.Add(3, new Burger("Hamburger", 25, BunType.Ciabatta, ["ham"]));
        }

        public Burger DeleteItem(int burger)
        {
            if (MenukortBurger.ContainsKey(burger))
            {
                Burger slettetKunde = MenukortBurger[burger];
                MenukortBurger.Remove(burger);
                return slettetKunde;
            }
            else
            {
                return null;
            }
        }

        public Burger AddItem(int number, string name, BunType type, double price, List<string> description)
        {

            MenukortBurger.Add(number, new Burger(name, price, type, description));
            return MenukortBurger[number];
        }

        public List<Burger> GetAllBurgers()
        {
            return MenukortBurger.Values.ToList();
        }

        public override string ToString()
        {
            return $"{{}}";
        }
    }
}
