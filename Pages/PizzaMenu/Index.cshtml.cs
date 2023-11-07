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
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Items> AllItems{ get; set; }
        //public string NyDescription { get; set; }

        public void OnGet()
        {
            //AllItems = _repo.GetAllPizzas();
            //_repo.AddNumbers();
                AllItems = _repo.GetAllItems();
        }

        public IActionResult OnPostPris()
        {   
            AllItems = _repo.SortItemsPrice();
            return Page();
        }
        public IActionResult OnPostNummer()
        {
            AllItems = _repo.GetAllItems();
            return Page();
        }
        public IActionResult OnPostTilføj(int nummer)
        {
            Items item = _repo.SearchItem(nummer);
            AllItems = _repo.GetAllItems();
            Tilføjet = item;

            return Page();
        }

    }
}
