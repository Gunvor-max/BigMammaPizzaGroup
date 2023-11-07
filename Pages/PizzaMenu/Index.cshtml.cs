using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;

namespace BigMammaPizzaGroup.Pages.Menukort
{
    public class PizzaMenuModel : PageModel
    {
        //instance field of Pizzarepository 
        private IMenucard _repo;

        //Dependency constructor 
        public PizzaMenuModel(IMenucard repo)
        {
            _repo = repo;
        }
        //property til viewet
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilf�jet { get; set; }
        public List<Items> AllItems{ get; set; }
        //public string NyDescription { get; set; }

        public void OnGet()
        {
            //AllItems = _repo.GetAllPizzas();
            //_repo.AddNumbers();
            Sort = 1;
                AllItems = _repo.GetAllItems();
        }

        public IActionResult OnPostPris()
        {   
            if (Sort == 1||Sort == 3)
            {
                AllItems = _repo.SortItemsPrice();
                Sort = 2;
            }
            else if (Sort ==2)
            {
                AllItems = _repo.SortItemsPrice();
                AllItems.Reverse();
                Sort = 3;
            }
           
            return Page();
        }
        public IActionResult OnPostNummer()
        {
            Sort = 1;
            AllItems = _repo.GetAllItems();
            return Page();
        }
        public IActionResult OnPostTilf�j(int nummer)
        {
            Items item = _repo.SearchItem(nummer);
            switch (Sort)
            {
                case 1: AllItems = _repo.GetAllItems(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            Tilf�jet = item;

            return Page();
        }

    }
}
