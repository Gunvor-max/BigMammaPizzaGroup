using BigMammaPizzaGroup.Model;
using System.Text.Json;
using System.Text;

namespace BigMammaPizzaGroup.Services
{
    public class MenuCardJson : IMenucard
    {
        //instance field 
        public Dictionary<int, Items> _menu;
        public List<Items> _items;

        //property
        public Dictionary<int, Items> Menu
        { get { return _menu; }
        set { _menu = value; }
        }
        public List<Items> Items
        { get { return _items; } }

        // konstruktør
        public MenuCardJson()
        {
            _menu = ReadFromJsonDIC(); 
        }
        
        //peters kode
        List<Items> data = new List<Items>();

        public Items AddItem(Items item)
        {
            _menu.Add(item.Number, item);
            WriteToJson(data);
            return item;
        }


        public Items DeleteItem(int item)
        {
            if (Menu.ContainsKey(item))
            {
                Items slettetpizza = Menu[item];
                Menu.Remove(item);
                WriteToJson(data);
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
            return _menu.Count + 1;
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

        //indsætter ny jsonfile fra peter

        private Dictionary<int, Items> ReadFromJsonDIC()
        {
            Dictionary<int, Items> menu = new Dictionary<int, Items>();
            for (int i = 0; i < ReadFromJsonLIST().Count;) 
            {
                menu.Add(i+1, ReadFromJsonLIST()[i]);
            }
            return menu;
        }


        //Helping methods for writing and reading to json file

        private const string FILENAME = "MenuCard.json";
        private const string FILENAMEITEMS = "Items.json";
        private const string FILENAMEPIZZA = "Pizza.json";
        private const string FILENAMEBURGER = "Burger.json";
        private const string FILENAMEDRINK = "Drink.json";

        private List<Items> ReadFromJsonLIST()
        {
            //ITEMS
            List<Items> data = new List<Items>();

            using (var reader = File.OpenText(FILENAMEITEMS))
            {
                string json = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<List<Items>>(json);
            }

            //PIZZA
            using (var reader = File.OpenText(FILENAMEPIZZA))
            {
                List<Pizza> datasub;
                string json = reader.ReadToEnd();
                datasub = JsonSerializer.Deserialize<List<Pizza>>(json);

                data.AddRange(datasub);
            }

            //BURGER
            using (var reader = File.OpenText(FILENAMEBURGER))
            {
                List<Burger> dataend;
                string json = reader.ReadToEnd();
                dataend = JsonSerializer.Deserialize<List<Burger>>(json);

                data.AddRange(dataend);
            }

            //DRIKKEVARER
            using (var reader = File.OpenText(FILENAMEDRINK))
            {
                List<Drink> dataend;
                string json = reader.ReadToEnd();
                dataend = JsonSerializer.Deserialize<List<Drink>>(json);

                data.AddRange(dataend);
            }



            return data;

        }

        public void WriteData(List<Items> data) 
        {
            List<Items> list1 = new List<Items>();
            List<Pizza> list2 = new List<Pizza>();
            List<Burger> list3 = new List<Burger>();
            List<Drink> list4 = new List<Drink>();

            foreach (var item in data) 
            {
                if (item is Pizza) 
                {
                    list2.Add((Pizza)item);
                }
                else if (item is Burger)
                {
                    list3.Add((Burger)item);
                }
                else if (item is Drink) 
                {
                    list4.Add((Drink)item);
                } 
                else
                {
                    list1.Add(item);
                }


            }

            using (FileStream fs = new FileStream(FILENAMEITEMS, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                JsonSerializer.Serialize(writer, list1);
            }
            using (FileStream fs = new FileStream(FILENAMEPIZZA, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                JsonSerializer.Serialize(writer, list2);
            }
            using (FileStream fs = new FileStream(FILENAMEBURGER, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                JsonSerializer.Serialize(writer, list3);
            }
            using (FileStream fs = new FileStream(FILENAMEDRINK, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                JsonSerializer.Serialize(writer, list4);
            }

        }

        public void WriteToJson(List<Items> data)
        {
            using (FileStream fs = new FileStream(FILENAME, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(json);
                sw.Close();
            }
        }

        public List<Pizza> ReadDataAllPizza()
        {
            List<Pizza> data = new List<Pizza>();

            using (var reader = File.OpenText(FILENAME))
            {
                string json = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<List<Pizza>>(json);
            }
            return data;
        }

        public List<Burger> ReadDataAllBurger()
        {
            List<Burger> data = new List<Burger>();

            using (var reader = File.OpenText(FILENAME))
            {
                string json = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<List<Burger>>(json);
            }
            return data;
        }

        public List<Drink> ReadDataAllDrinks()
        {
            List<Drink> data = new List<Drink>();

            using (var reader = File.OpenText(FILENAME))
            {
                string json = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<List<Drink>>(json);
            }
            return data;
        }

        //    private Dictionary<int, Items> ReadFromJson()
        //{

        //    if (File.Exists(FILENAME))
        //    {
        //        StreamReader reader = File.OpenText(FILENAME);
        //        Dictionary<int, Items> katalog = JsonSerializer.Deserialize<Dictionary<int, Items>>(reader.ReadToEnd());
        //        reader.Close();
        //        return katalog;
        //    }
        //    else
        //    {
        //        return new Dictionary<int, Items>();
        //    }

        //}

        //private void WriteToJson()
        //{
        //    FileStream fs = new FileStream(FILENAME, FileMode.Create);
        //    Utf8JsonWriter writer = new Utf8JsonWriter(fs);
        //    JsonSerializer.Serialize(writer, _menu);
        //    fs.Close();
        //}

    }
}
