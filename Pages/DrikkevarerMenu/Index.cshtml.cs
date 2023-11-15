using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BigMammaPizzaGroup.Pages.DrikkevarerMenu
{
    public class DrinksMenuModel : PageModel
    {
        public DrinksRepository _drinkMenuKort;

        public List<Drink> DrinkMenukort { get; set; }

        //Dependency constructor 
        public DrinksMenuModel(DrinksRepository repob)
        {
            _drinkMenuKort = repob;
        }


        //property til viewet
        public static string Mad { get; set; }
        public string Mad2 { get; set; }
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Drink> AllItemsD { get; set; }
        public static List<Items> PizzasS { get; set; } = new List<Items>();
        public static List<Burger> BurgersS { get; set; } = new List<Burger>();
        public static List<Drink> DrinksS { get; set; } = new List<Drink>();
        public List<Items> PizzasN { get; set; }
        public List<Burger> BurgersN { get; set; }
        public List<Drink> DrinksN { get; set; }
        [Display(Name = "")]
        public string? ASizes { get; set; } = string.Empty;

        public static IEnumerable<SelectListItem>? AvailableSizes()
        {
            return new[]
            {
                new SelectListItem { Text = "33 cl", Value = "33"},
                new SelectListItem { Text = "50 cl", Value = "50"},
                new SelectListItem { Text = "1.5 L", Value = "1.5"}
            };
        }

        public void OnGet()
        {
            Sort = 1;
            DrinksRepository repo = new DrinksRepository();
            AllItemsD = repo.SortItemsNumberD();
            repo.AddNumbersD();

            DrinksN = DrinksS;

            //DrinksRepository drinksize = new DrinksRepository();
            //var drinkoption = drinksize.GetAllDrinks();

            //var model = new Drink();
            //model.Size = new List<Drink>();

            //drinksize. = new List<Drink>();
        }

        public IActionResult OnPostPris()
        {
            if (Sort == 1 || Sort == 3)
            {
                AllItemsD = _drinkMenuKort.SortItemsPriceD();
                Sort = 2;
            }
            else if (Sort == 2)
            {
                AllItemsD = _drinkMenuKort.SortItemsNumberD();
                AllItemsD.Reverse();
                Sort = 3;
            }
            Mad2 = Mad;
            DrinksN = DrinksS;
            return Page();
        }

        public IActionResult OnPostNummer()
        {
            Sort = 1;
            AllItemsD = _drinkMenuKort.SortItemsNumberD();
            Mad2 = Mad;
            DrinksN = DrinksS;
            return Page();
        }
        public IActionResult OnPostTilføj(int nummer)
        {
            Drink item = _drinkMenuKort.SearchItemD(nummer);
            switch (Sort)
            {
                case 1: AllItemsD = _drinkMenuKort.SortItemsNumberD(); break;
                case 2: AllItemsD = _drinkMenuKort.SortItemsNumberD(); break;
                case 3: AllItemsD = _drinkMenuKort.SortItemsPriceD(); AllItemsD.Reverse(); break;
            }

            if (PizzasS.Count == 0)
            {
                Customer customer = new Customer();
                Order order = new Order(customer, PizzasS, BurgersS, DrinksS);
            }
            DrinksS.Add(item);
            Mad = item.Name;
            Mad2 = Mad;
            DrinksN = DrinksS;


            return Page();
        }

        public IActionResult OnPostDelete()
        {
            Mad = "";
            DrinksS.Clear();
            DrinksN = DrinksS;
            switch (Sort)
            {
                case 1: AllItemsD = _drinkMenuKort.SortItemsNumberD(); break;
                case 2: AllItemsD = _drinkMenuKort.SortItemsPriceD(); break;
                case 3: AllItemsD = _drinkMenuKort.SortItemsNumberD(); AllItemsD.Reverse(); break;
            }
            return Page();
        }

        public IActionResult OnPostDeleteOne(int nummer)
        {

            DrinksS.Remove(_drinkMenuKort.SearchItemD(nummer));
            DrinksN = DrinksS;
            switch (Sort)
            {
                case 1: AllItemsD = _drinkMenuKort.SortItemsNumberD(); break;
                case 2: AllItemsD = _drinkMenuKort.SortItemsPriceD(); break;
                case 3: AllItemsD = _drinkMenuKort.SortItemsPriceD(); AllItemsD.Reverse(); break;
            }
            return Page();
        }

        public IActionResult OnPostCheckout()
        {
            //DrinksN = DrinksS;
            //if (DrinksN.Count == 0)
            //{
            //    return Page();
            //}
            {
                return RedirectToPage("/Checkout/Checkout");
            }
        }

    }
}