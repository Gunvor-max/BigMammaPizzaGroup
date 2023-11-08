using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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
        public static string Mad {  get; set; }
        public string Mad2 {  get; set; }
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Items> AllItems{ get; set; }
        public static List<Items> Food {  get; set; } = new List<Items>();
        public List<Items> Food2 { get; set; }
        //public string NyDescription { get; set; }

        public void OnGet()
        {
            //AllItems = _repo.GetAllPizzas();
            //_repo.AddNumbers();
            Sort = 1;
            AllItems = _repo.SortItemsNumber();
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
            Mad2 = Mad;
            return Page();
        }
        
        public IActionResult OnPostNummer()
        {
            Sort = 1;
            AllItems = _repo.SortItemsNumber();
            Mad2 = Mad;
            return Page();
        }
        public IActionResult OnPostTilføj(int nummer)
        {
            Items item = _repo.SearchItem(nummer);
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            
            if (Food.Count==0)
            {
                Customer customer = new Customer();
                Order order = new Order(customer,Food);
            }
            Food.Add(item);
            Mad = _repo.GetFood2(Food);
            Mad2 = Mad;
            

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            Mad2 = "";
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            return Page();
        }
    }
}
