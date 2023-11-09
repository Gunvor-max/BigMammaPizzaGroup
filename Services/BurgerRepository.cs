using BigMammaPizzaGroup.Model;
namespace BigMammaPizzaGroup.Services
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
            MenukortBurger.Add(1, new Burger(1,"Big Mac", 40, BunType.Ciabatta, ["tomato", "beef"]));
            MenukortBurger.Add(2, new Burger(2,"Tasty Cheese", 25, BunType.Ciabatta, ["cheese"]));
            MenukortBurger.Add(3, new Burger(3,"Hamburger", 25, BunType.Ciabatta, ["ham"]));
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

        //public Burger AddItem(int number, string name, BunType type, double price, List<string> description)
        //{

        //    MenukortBurger.Add(number, new Burger(name, price, type, description));
        //    return MenukortBurger[number];
        //}

        public Burger AddItemB(Burger item)
        {
            MenukortBurger.Add(item.Number, item);
            return item;
        }

        public List<Burger> GetAllBurgers()
        {
            return MenukortBurger.Values.ToList();
        }

        public List<Burger> SortItemsPriceB()
        {
            List<Burger> menu = GetAllBurgers();
            List<Burger> list = new List<Burger>();
            foreach (Burger item in GetAllBurgers())
            {
                list.Add(FindLowestPriceB(menu));
                menu.Remove(FindLowestPriceB(menu));
            }
            return list;
        }

        public Burger SearchItemB(int item)
        {
            Burger resItem = null;
            foreach (Burger m in MenukortBurger.Values)
            {
                if (m.Number == item)
                    return m;
            }
            return resItem;
        }

            public Burger FindLowestPriceB(List<Burger> menu)
        {
            Burger Lowest = menu[0];
            for (int i = 0; i + 1 < menu.Count; i++)
            {
                if (Lowest.Price > menu[i + 1].Price)
                {
                    Lowest = menu[i + 1];
                }
            }
            return Lowest;
        }

        public Burger FindLowestNumberB(List<Burger> menu)
        {
            Burger Lowest = menu[0];
            for (int i = 0; i + 1 < menu.Count; i++)
            {
                if (Lowest.Number > menu[i + 1].Number)
                {
                    Lowest = menu[i + 1];
                }
            }
            return Lowest;
        }
        public List<Burger> SortItemsNumberB()
        {
            List<Burger> menu = GetAllBurgers();
            List<Burger> list = new List<Burger>();
            foreach (Burger item in GetAllBurgers())
            {
                list.Add(FindLowestNumberB(menu));
                menu.Remove(FindLowestNumberB(menu));
            }
            return list;
        }

        public string GetFood2B(List<Burger> food)
        {
            string Food = "";
            foreach (Burger item in food)
            {
                Food += item.Name + ", ";
            }
            return Food;
        }
        public void AddNumbersB()
        {
            for (int i = 1; i <= MenukortBurger.Count; i++)
            {
                if (MenukortBurger.ContainsKey(i))
                {
                    MenukortBurger[i].Number = i;
                }

            }
        }

        public int NextNumberB()
        {
            for (int i = 1; i < MenukortBurger.Count; i++)
            {
                if (!MenukortBurger.ContainsKey(i))
                {
                    return i;
                }
            }
            return MenukortBurger.Count + 1;

        }

        public void CheckMenuB()
        {
            for (int i = 1; i <= MenukortBurger.Count;)
            {
                if (!MenukortBurger.ContainsKey(i))
                {
                    MenukortBurger.Add(i, MenukortBurger[i + 1]);
                    MenukortBurger.Remove(i + 1);
                }
                else
                {
                    i++;
                }
            }
        }

        //toostring
        public override string ToString()
        {
            string Output = string.Join(", ", MenukortBurger.Values);
            return $"{{{nameof(MenukortBurger)}={Output}}}";
        }
    }
    }
