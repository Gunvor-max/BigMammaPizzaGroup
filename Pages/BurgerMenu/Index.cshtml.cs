using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;

namespace BigMammaPizzaGroup.Pages.BurgerMenu
{
    public class BurgerMenuModel : PageModel
    {
        public BurgerRepository _burgerMenuKort;

        public List<Burger> BurgerMenukort { get; set; }

        //Dependency constructor 
        public BurgerMenuModel(BurgerRepository repob)
        {
            _burgerMenuKort = repob;
        }


        //property til viewet
        public static string Mad { get; set; }
        public string Mad2 { get; set; }
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Burger> AllItemsb { get; set; }
        public static List<Items> PizzasS { get; set; } = new List<Items>();
        public static List<Burger> BurgersS { get; set; } = new List<Burger>();
        public static List<Drink> Drinks { get; set; } = new List<Drink>();
        public List<Items> Pizzas { get; set; } = new List<Items>();
        public List<Burger> BurgersN { get; set; }

        public void OnGet()
        {
            Sort = 1;
            BurgerRepository repo = new BurgerRepository();
            AllItemsb = repo.SortItemsNumberB();
            repo.AddNumbersB();
            BurgersN = BurgersS;
        }

        public IActionResult OnPostPris()
        {
            if (Sort == 1 || Sort == 3)
            {
                AllItemsb = _burgerMenuKort.SortItemsPriceB();
                Sort = 2;
            }
            else if (Sort == 2)
            {
                AllItemsb = _burgerMenuKort.SortItemsPriceB();
                AllItemsb.Reverse();
                Sort = 3;
            }
            Mad2 = Mad;
            BurgersN = BurgersS;
            return Page();
        }

        public IActionResult OnPostNummer()
        {
            Sort = 1;
            AllItemsb = _burgerMenuKort.SortItemsNumberB();
            Mad2 = Mad;
            BurgersN = BurgersS;
            return Page();
        }
        public IActionResult OnPostTilføj(int nummer)
        {
            Burger item = _burgerMenuKort.SearchItemB(nummer);
            switch (Sort)
            {
                case 1: AllItemsb = _burgerMenuKort.SortItemsNumberB(); break;
                case 2: AllItemsb = _burgerMenuKort.SortItemsPriceB(); break;
                case 3: AllItemsb = _burgerMenuKort.SortItemsPriceB(); AllItemsb.Reverse(); break;
            }

           
            Customer customer = new Customer();
            
            
           
            
            BurgersS.Add(item);
            Mad = item.Name;
            Mad2 = Mad;
            BurgersN = BurgersS;
            Order order = new Order(customer, PizzasS, BurgersS, Drinks);
            order.Burgers = BurgersN;
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            Mad = "";
            BurgersS.Clear();
            BurgersN = BurgersS;
            switch (Sort)
            {
                case 1: AllItemsb = _burgerMenuKort.SortItemsNumberB(); break;
                case 2: AllItemsb = _burgerMenuKort.SortItemsPriceB(); break;
                case 3: AllItemsb = _burgerMenuKort.SortItemsPriceB(); AllItemsb.Reverse(); break;
            }
            return Page();
        }

    }
}
