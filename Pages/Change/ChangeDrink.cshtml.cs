using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Change
{
    public class ChangeDrinkModel : PageModel
    {
        DrinksRepository Repo { get; set; }
        public List<Drink> AllItems { get; set; }
        public ChangeDrinkModel(DrinksRepository repo)
        {
            Repo = repo;

        }
        public static int Sort { get; set; } = 1;
        public bool Button { get; set; }
        public string NytDrinkNavn { get; set; }
        public string NyDescription { get; set; }
        public int NytDrinkNummer { get; set; }
        public double NyPris { get; set; }
        public void OnGet()
        {
            AllItems = Repo.SortItemsNumberD();
        }
        public IActionResult OnPostChangeItem(int nummer)
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberD(); break;
                case 2: AllItems = Repo.SortItemsPriceD(); break;
                case 3: AllItems = Repo.SortItemsPriceD(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberD(); break;
            }
            Drink drink = Repo.SearchItemD(nummer);
            NytDrinkNavn = drink.Name;
            NyPris = drink.Price;
            Button = true;
            
            
            return Page();
        }
        public IActionResult OnPostDeleteItem(int item)
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberD(); break;
                case 2: AllItems = Repo.SortItemsPriceD(); break;
                case 3: AllItems = Repo.SortItemsPriceD(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberD(); break;
            }
            return Page();
        }
        public void OnPostNummer()
        {
            AllItems = Repo.SortItemsNumberD();
            Sort = 1;
        }
        public void OnPostPris()
        {
            if (Sort == 1 || Sort == 3 && !(Repo.SortItemsNumberD() == Repo.SortItemsPriceD()))
            {
                AllItems = Repo.SortItemsPriceD();
                Sort = 2;
            }
            else if (Sort == 2 || Repo.SortItemsNumberD() == Repo.SortItemsPriceD())
            {
                AllItems = Repo.SortItemsPriceD(); AllItems.Reverse();
                Sort = 3;
            }
            NytDrinkNummer = Repo.NextNumberD();
        }
        public IActionResult OnPost∆ndre()
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberD(); break;
                case 2: AllItems = Repo.SortItemsPriceD(); break;
                case 3: AllItems = Repo.SortItemsPriceD(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberD(); break;
            }
            Button = false;
            return Page();
        }
        public IActionResult OnPostOpret()
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberD(); break;
                case 2: AllItems = Repo.SortItemsPriceD(); break;
                case 3: AllItems = Repo.SortItemsPriceD(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberD(); break;
            }
            Drink drink = new Drink(Repo.NextNumberD(), NytDrinkNavn, NyPris, NyDescription);
            Repo.AddItemD(drink);
            return Page();
        }
        public IActionResult OnPostCancel()
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberD(); break;
                case 2: AllItems = Repo.SortItemsPriceD(); break;
                case 3: AllItems = Repo.SortItemsPriceD(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberD(); break;
            }
            Button = false;
            return Page();
        }
    }
}
