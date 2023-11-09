using BigMammaPizzaGroup.Model;

namespace BigMammaPizzaGroup.Services
{
    public class Menucard : IMenucard
    {
        //instance field
        Dictionary<int, Items> _menu;

        //property
        public Dictionary<int, Items> Menu
        {  get { return _menu; }
            set { _menu = value; }
        }

        public Menucard()
        {
            _menu = new Dictionary<int, Items>();
            //Menu.Clear();
            //PopulatePizzaRepository();
            //PopulateBurgerRepository();
            //PopulateDrinksRepository();
        }


        private void PopulatePizzaRepository()
        {
            Menu.Add(1, new Pizza("Margherita", 69, ["tomato", "cheese"]));
            Menu.Add(2, new Pizza("Vesuvio", 75, ["tomato", "cheese", "ham"]));
            Menu.Add(3, new Pizza("Capricciosa", 80, ["tomato", "cheese", "ham", "mushrooms"]));
            Menu.Add(4, new Pizza("Calzone", 80, ["baked pizza with tomat", "cheese", "ham", "mushrooms"]));
            Menu.Add(5, new Pizza("Quattro Stagioni", 85, ["tomato", "cheese", "ham", "mushrooms", "shrimp", "peppers"]));
            Menu.Add(6, new Pizza("Marinara", 85, ["tomato", "cheese", "shrimp", "mussels", "garlic"]));
            Menu.Add(7, new Pizza("Vegetatian", 80, ["tomato", "cheese", "vegetables"]));
            Menu.Add(8, new Pizza("Italiana", 75, ["tomato", "cheese", "onion", "meat sauce"]));
            Menu.Add(9, new Pizza("Gorgonzola", 85, ["tomato", "gorgonzola", "onion", "mushroom"]));
            Menu.Add(10, new Pizza("Contadina", 75, ["tomato", "cheese", "mushrooms", "olives"]));
            Menu.Add(11, new Pizza("Naples", 79, ["tomato", "cheese", "anchovies", "olives"]));
            Menu.Add(12, new Pizza("Vichinga", 80, ["tomato", "cheese", "ham", "mushrooms", "peppers", "garlic", "chili"]));
            Menu.Add(13, new Pizza("Calzone Special", 80, ["tomato", "cheese", "shrimp", "ham", "meat sauce"]));
            Menu.Add(14, new Pizza("Esotica", 80, ["tomato", "cheese", "ham", "shrimp", "pinapple"]));
            Menu.Add(15, new Pizza("Tonno", 85, ["tomato", "cheese", "tuna", "shrimp"]));
            Menu.Add(16, new Pizza("Sardegna", 80, ["tomato", "cheese", "cocktail sausages", "bacon", "onions", "eggs"]));
            Menu.Add(17, new Pizza("Romana", 78, ["tomato", "cheese", "ham", "bacon", "onion"]));
            Menu.Add(18, new Pizza("Sole", 78, ["tomato", "cheese", "ham", "bacon", "eggs"]));
            Menu.Add(19, new Pizza("Big Mamma", 90, ["tomato", "gorgonzola", "shrimp", "asparagus", "parma ham"]));
        }
        //private void PopulateBurgerRepository()
        //{
        //    Menu.Add(20, new Burger("Big Mac", 40, BunType.Ciabatta, ["tomato", "beef"]));
        //    Menu.Add(21, new Burger("Tasty Cheese", 25, BunType.Ciabatta, ["cheese"]));
        //    Menu.Add(22, new Burger("Hamburger", 25, BunType.Ciabatta, ["ham"]));
        //}
        //private void PopulateDrinksRepository()
        //{
        //    Menu.Add(23, new Drink("Coca Cola", 15, "33 cl"));
        //    Menu.Add(24, new Drink("Coca Cola", 20, "50 cl"));
        //    Menu.Add(25, new Drink("Coca Cola", 30, "1,5L"));
        //    Menu.Add(26, new Drink("Faxe Kondi", 15, "33 cl"));
        //    Menu.Add(27, new Drink("Faxe Kondi", 20, "50 cl"));
        //    Menu.Add(28, new Drink("Faxe Kondi", 30, "1,5L"));
        //    Menu.Add(29, new Drink("Pepsi Max", 15, "33 cl"));
        //    Menu.Add(30, new Drink("Pepsi Max", 20, "50 cl"));
        //    Menu.Add(31, new Drink("Pepsi Max", 30, "1,5L"));
        //    Menu.Add(32, new Drink("Appelsin Vand", 10, "33 cl"));
        //    Menu.Add(33, new Drink("Appelsin Vand", 15, "50 cl"));
        //    Menu.Add(34, new Drink("Ayran", 10, "250 Ml"));
        //    Menu.Add(35, new Drink("Gazoz", 10, "33 cl"));

        //}

        public Items AddItem(Items item)
        {
            Menu.Add(item.Number, item);
            return item;
        }


        public Items DeleteItem(int item)
        {
            if (Menu.ContainsKey(item))
            {
                Items slettetpizza = Menu[item];
                Menu.Remove(item);
                return slettetpizza;
            }
            else
            {
                return null;
            }
        }

        public Items SearchItem(int item)
        {
            Items resItem = null;
            foreach (Items m in Menu.Values)
            {
                if (m.Number == item)
                    return m;
            }
            return resItem;
        }
        public List<Items> GetAllItems()
        {
            return Menu.Values.ToList();
        }

        public List<Items> GetAllPizzas()
        {
            List<Items> menu = new List<Items>();
            for (int i = 1; i <= Menu.Count; i++)
            {
                if (Menu.ContainsKey(i))
                {
                    if (Menu[i] is Pizza)
                    {
                        menu.Add(Menu[i]);
                    }
                }
            }
            return menu;
        }
        public List<Items> GetAllBurgers()
        {
            List<Items> menu = new List<Items>();
            for (int i = 1; i <= Menu.Count; i++)
            {
                if (Menu.ContainsKey(i))
                {
                    if (Menu[i] is Burger)
                    {
                        menu.Add(Menu[i]);
                    }
                }
            }
            return menu;
        }
        public List<Items> GetAllDrinks()
        {
            List<Items> menu = new List<Items>();
            for (int i = 1; i <= Menu.Count; i++)
            {
                if (Menu.ContainsKey(i))
                {
                    if (Menu[i] is Drink)
                    {
                        menu.Add(Menu[i]);
                    }
                }
            }
            return menu;
        }
        public Items FindLowestPrice(List<Items> menu)
        {
            Items Lowest = menu[0];
            for(int i = 0; i+1 < menu.Count; i++)
            {
                if (Lowest.Price > menu[i + 1].Price)
                {
                    Lowest = menu[i + 1];
                }
            }
            return Lowest;
        }

        public List<Items> SortItemsPrice()
        {
            List<Items> menu = GetAllItems();
            List<Items> list = new List<Items>();
            foreach(Items item in GetAllItems())
            {
                list.Add(FindLowestPrice(menu));
                menu.Remove(FindLowestPrice(menu));
            }
            return list;
        }

        public Items FindLowestNumber(List<Items> menu)
        {
            Items Lowest = menu[0];
            for (int i = 0; i + 1 < menu.Count; i++)
            {
                if (Lowest.Number > menu[i + 1].Number)
                {
                    Lowest = menu[i + 1];
                }
            }
            return Lowest;
        }
        public List<Items> SortItemsNumber()
        {
            List<Items> menu = GetAllItems();
            List<Items> list = new List<Items>();
            foreach (Items item in GetAllItems())
            {
                list.Add(FindLowestNumber(menu));
                menu.Remove(FindLowestNumber(menu));
            }
            return list;
        }

        public string GetFood2(List<Items> food)
        {
            string Food = "";
            foreach (Items item in food)
            {
                Food += item.Name + ", ";
            }
            return Food;
        }
        public void AddNumbers()
        {
            for (int i = 1; i <= Menu.Count; i++)
            {
                if (Menu.ContainsKey(i))
                {
                    Menu[i].Number = i;
                }

            }
        }

        public int NextNumber()
        {
            for (int i = 1; i < Menu.Count; i++)
            {
                if (!Menu.ContainsKey(i))
                {
                    return i;
                }
            }
            return Menu.Count + 1;

        }

        public void CheckMenu()
        {
            for (int i = 1; i <= Menu.Count;)
            {
                if (!Menu.ContainsKey(i))
                {
                    Menu.Add(i, Menu[i + 1]);
                    Menu.Remove(i+1);
                }
                else
                {
                    i++;
                }
            }
        }
        public override string ToString()
        {
            string Output = string.Join(", ", Menu.Values);
            return $"{{{nameof(Menu)}={Output}}}";
        }
    }
}
