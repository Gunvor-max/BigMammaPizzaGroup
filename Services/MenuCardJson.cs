using BigMammaPizzaGroup.Model;
using System.Text.Json;
using System.Text;

namespace BigMammaPizzaGroup.Services
{
    public class MenuCardJson : IMenucard
    {
        public Dictionary<int, Items> Menu;

        // konstruktør
        public MenuCardJson()
        {
            Menu = ReadFromJson();
        }
        public Items AddItem(Items item)
        {
            Menu.Add(item.Number, item);
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
            string Output = string.Join(", ", Menu.Values);
            return $"{{{nameof(Menu)}={Output}}}";
        }

      //Helping methods for writing and reading to json file

        private const string FILENAME = "MenuCard.json";

        public Dictionary<int, Items> ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader reader = File.OpenText(FILENAME);
                Dictionary<int, Items> menukort = JsonSerializer.Deserialize<Dictionary<int, Items>>(reader.ReadToEnd());
                reader.Close();
                return menukort;
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
            JsonSerializer.Serialize(writer, Menu);
            fs.Close();
        }

    }
}
