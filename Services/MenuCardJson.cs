using BigMammaPizzaGroup.Model;
using System.Text.Json;
using System.Text;

namespace BigMammaPizzaGroup.Services
{
    public class MenuCardJson : IMenucard
    {
        //instance field 
        public Dictionary<int, Items> _menu;

        //property
        public Dictionary<int, Items> Menu
        { get { return _menu; }
        set { _menu = value; }
        }

        // konstruktør
        public MenuCardJson()
        {
            _menu = ReadFromJson(); 
        }
        public Items AddItem(Items item)
        {
            _menu.Add(item.Number, item);
            WriteToJson();
            return item;
        }


        public Items DeleteItem(int item)
        {
            if (Menu.ContainsKey(item))
            {
                Items slettetpizza = Menu[item];
                Menu.Remove(item);
                WriteToJson();
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
            return _menu.Values.ToList();
        }

        public List<Items> GetAllPizzas()
        {
            List<Items> menu = new List<Items>();
            for (int i = 1; i <= _menu.Count; i++)
            {
                if (_menu.ContainsKey(i))
                {
                    if (_menu[i] is Pizza)
                    {
                        menu.Add(_menu[i]);
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
        public Items FindLowest(List<Items> menu)
        {
            Items Lowest = menu[0];
            for (int i = 0; i + 1 < menu.Count; i++)
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
            foreach (Items item in GetAllItems())
            {
                list.Add(FindLowest(menu));
                menu.Remove(FindLowest(menu));
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

        //public void CheckMenu()
        //{
        //    for(int i = 1; i <= Menu.Count;)
        //    {
        //        if (!Menu.ContainsKey(i))
        //        {
        //             Menu.Add(i, Menu[i + 1]);
        //        }
        //        else
        //        {
        //            i++;
        //        }
        //    }
        //}
        public override string ToString()
        {
            string Output = string.Join(", ", _menu.Values);
            return $"{{{nameof(Menu)}={Output}}}";
        }

      //Helping methods for writing and reading to json file

        private const string FILENAME = "MenuCard.json";

        private Dictionary<int, Items> ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader reader = File.OpenText(FILENAME);
                Dictionary<int, Items> katalog = JsonSerializer.Deserialize<Dictionary<int, Items>>(reader.ReadToEnd());
                reader.Close();
                return katalog;
            }
            else
            {
                return new Dictionary<int, Items>();
            }

        }

        private void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _menu);
            fs.Close();
        }

    }
}
