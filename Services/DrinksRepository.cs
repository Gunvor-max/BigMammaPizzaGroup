using System.ComponentModel.DataAnnotations.Schema;
using BigMammaPizzaGroup.Model;
namespace BigMammaPizzaGroup.Services;


public class DrinksRepository
{
    //Property
    public Dictionary<int, Drink> MenukortDrink = new Dictionary<int, Drink>();

    //Constructor
    public DrinksRepository()
    {
        PopulateDrinksRepository();
    }

    private void PopulateDrinksRepository()
    {
        MenukortDrink.Clear();
        MenukortDrink.Add(1, new Drink(1, "Coca Cola", 15, "33 cl"));
        MenukortDrink.Add(2, new Drink(2, "Coca Cola", 20, "50 cl"));
        MenukortDrink.Add(3, new Drink(3, "Coca Cola", 30, "1,5L"));
        MenukortDrink.Add(4, new Drink(4, "Faxe Kondi", 15, "33 cl"));
        MenukortDrink.Add(5, new Drink(5, "Faxe Kondi", 20, "50 cl"));
        MenukortDrink.Add(6, new Drink(6, "Faxe Kondi", 30, "1,5L"));
        MenukortDrink.Add(7, new Drink(7, "Pepsi Max", 15, "33 cl"));
        MenukortDrink.Add(8, new Drink(8, "Pepsi Max", 20, "50 cl"));
        MenukortDrink.Add(9, new Drink(9, "Pepsi Max", 30, "1,5L"));
        MenukortDrink.Add(10, new Drink(10, "Appelsin Vand", 10, "33 cl"));
        MenukortDrink.Add(11, new Drink(11, "Appelsin Vand", 15, "50 cl"));
        MenukortDrink.Add(12, new Drink(12, "Ayran", 10, "250 Ml"));
        MenukortDrink.Add(13, new Drink(13, "Gazoz", 10, "33 cl"));

    }

    public Drink DeleteItem(int drink)
    {
        if (MenukortDrink.ContainsKey(drink))
        {
            Drink slettetKunde = MenukortDrink[drink];
            MenukortDrink.Remove(drink);
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

    public Drink AddItemD(Drink item)
    {
        MenukortDrink.Add(item.Number, item);
        return item;
    }

    public List<Drink> GetAllDrinks()
    {
        return MenukortDrink.Values.ToList();
    }

    public List<Drink> SortItemsPriceD()
    {
        List<Drink> menu = GetAllDrinks();
        List<Drink> list = new List<Drink>();
        foreach (Drink item in GetAllDrinks())
        {
            list.Add(FindLowestPriceD(menu));
            menu.Remove(FindLowestPriceD(menu));
        }
        return list;
    }

    public Drink SearchItemD(int item)
    {
        Drink resItem = null;
        foreach (Drink m in MenukortDrink.Values)
        {
            if (m.Number == item)
                return m;
        }
        return resItem;
    }

    public Drink FindLowestPriceD(List<Drink> menu)
    {
        Drink Lowest = menu[0];
        for (int i = 0; i + 1 < menu.Count; i++)
        {
            if (Lowest.Price > menu[i + 1].Price)
            {
                Lowest = menu[i + 1];
            }
        }
        return Lowest;
    }

    public Drink FindLowestNumberD(List<Drink> menu)
    {
        Drink Lowest = menu[0];
        for (int i = 0; i + 1 < menu.Count; i++)
        {
            if (Lowest.Number > menu[i + 1].Number)
            {
                Lowest = menu[i + 1];
            }
        }
        return Lowest;
    }
    public List<Drink> SortItemsNumberD()
    {
        List<Drink> menu = GetAllDrinks();
        List<Drink> list = new List<Drink>();
        foreach (Drink item in GetAllDrinks())
        {
            list.Add(FindLowestNumberD(menu));
            menu.Remove(FindLowestNumberD(menu));
        }
        return list;
    }

    public string GetFood2D(List<Drink> food)
    {
        string Food = "";
        foreach (Drink item in food)
        {
            Food += item.Name + ", ";
        }
        return Food;
    }
    public void AddNumbersD()
    {
        for (int i = 1; i <= MenukortDrink.Count; i++)
        {
            if (MenukortDrink.ContainsKey(i))
            {
                MenukortDrink[i].Number = i;
            }

        }
    }

    public int NextNumberD()
    {
        for (int i = 1; i < MenukortDrink.Count; i++)
        {
            if (!MenukortDrink.ContainsKey(i))
            {
                return i;
            }
        }
        return MenukortDrink.Count + 1;

    }

    public void CheckMenuD()
    {
        for (int i = 1; i <= MenukortDrink.Count;)
        {
            if (!MenukortDrink.ContainsKey(i))
            {
                MenukortDrink.Add(i, MenukortDrink[i + 1]);
                MenukortDrink.Remove(i + 1);
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
        string Output = string.Join(", ", MenukortDrink.Values);
        return $"{{{nameof(MenukortDrink)}={Output}}}";
    }
}

