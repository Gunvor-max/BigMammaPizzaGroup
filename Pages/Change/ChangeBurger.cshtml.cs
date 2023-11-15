using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Change
{
    public class ChangeBurgerModel : PageModel
    {
        BurgerRepository Repo { get; set; }
        public List<Burger> AllItems { get; set; }
        public ChangeBurgerModel(BurgerRepository repo)
        {
            Repo = repo;

        }
        public static int Sort { get; set; } = 1;
        public bool Button { get; set; }
        public string NytBurgerNavn { get; set; }
        public string NyDescription { get; set; }
        public int NytBurgerNummer { get; set; }
        public List<string> NyToppingList { get; set; } = new List<string>();
        public string NyToppingString { get; set; }
        public double NyPris { get; set; }
        public void OnGet()
        {
            NytBurgerNummer = Repo.NextNumberB();
            AllItems = Repo.SortItemsNumberB();
            
        }
        public void OnPostChangeItem(int? nummer)
        {

            Burger item = Repo.SearchItemB((int)nummer);


            NytBurgerNummer = item.Number;
            NytBurgerNavn = item.Name;
            NyPris = item.Price;
            NyDescription = item.Description;

            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberB(); break;
                case 2: AllItems = Repo.SortItemsPriceB(); break;
                case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberB(); break;
            }
            Button = true;
        }

        public IActionResult OnPost∆ndre()
        {
            if (!ModelState.IsValid)
            {
                switch (Sort)
                {
                    case 1: AllItems = Repo.SortItemsNumberB(); break;
                    case 2: AllItems = Repo.SortItemsPriceB(); break;
                    case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                    default: AllItems = Repo.SortItemsNumberB(); break;
                }
                return Page();
            }

            Burger item = Repo.SearchItemB(NytBurgerNummer);

            //NyToppingList.Add(NyDescription);

            item.Name = NytBurgerNavn;
            item.Price = NyPris;
            //item.Description = ListToString();
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberB(); break;
                case 2: AllItems = Repo.SortItemsPriceB(); break;
                case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberB(); break;
            }
            Button = false;
            NytBurgerNummer = Repo.NextNumberB();
            return Page();

        }

        public IActionResult OnPostCancel()
        {
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberB(); break;
                case 2: AllItems = Repo.SortItemsPriceB(); break;
                case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberB(); break;
            }
            NytBurgerNummer = Repo.NextNumberB();
            return Page();
        }
        public void OnPostPris()
        {
            if (Sort == 1 || Sort == 3 && !(Repo.SortItemsNumberB == Repo.SortItemsPriceB))
            {
                AllItems = Repo.SortItemsPriceB();
                Sort = 2;
            }
            else if (Sort == 2 || Repo.SortItemsNumberB == Repo.SortItemsPriceB)
            {
                AllItems = Repo.SortItemsPriceB(); AllItems.Reverse();
                Sort = 3;
            }
            NytBurgerNummer = Repo.NextNumberB();

        }
        public void OnPostNummer()
        {
            AllItems = Repo.SortItemsNumberB();
            Sort = 1;
            NytBurgerNummer = Repo.NextNumberB();
        }


        public IActionResult OnPostOpret()
        {
                
            if (!ModelState.IsValid)
            {
                switch (Sort)
                {
                    case 1: AllItems = Repo.SortItemsNumberB(); break;
                    case 2: AllItems = Repo.SortItemsPriceB(); break;
                    case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                    default: AllItems = Repo.SortItemsNumberB(); break;
                }
                NytBurgerNummer = Repo.NextNumberB();
                return Page();
            }
            
            NyToppingList.Add(NyDescription);
            Burger newburger = new Burger(NytBurgerNummer, NytBurgerNavn, NyPris, BunType.Fuldkorn ,NyToppingList);
            newburger.Number = Repo.NextNumberB();
            Repo.AddItemB(newburger);
            NyToppingString = newburger.GetToppings();
            newburger.Description = NyToppingString;
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberB(); break;
                case 2: AllItems = Repo.SortItemsPriceB(); break;
                case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberB(); break;
            }
            NytBurgerNummer = Repo.NextNumberB();
            return Page();
        }


        public IActionResult OnPostDeleteItem(int item)
        {
            Repo.DeleteItem(item);
            switch (Sort)
            {
                case 1: AllItems = Repo.SortItemsNumberB(); break;
                case 2: AllItems = Repo.SortItemsPriceB(); break;
                case 3: AllItems = Repo.SortItemsPriceB(); AllItems.Reverse(); break;
                default: AllItems = Repo.SortItemsNumberB(); break;
            }
            NytBurgerNummer = Repo.NextNumberB();
            return Page();
        }
    }
}
    

