using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using BigMammaPizzaGroup.Pages.BurgerMenu;
using System.Text.Json;

namespace BigMammaPizzaGroup.Pages.Menukort
{
    public class PizzaMenuModel : PageModel
    {
        //instance field of Pizzarepository 
        private IMenucard _repo;
        private Order _order;

        //Dependency constructor 
        public PizzaMenuModel(IMenucard repo, Order order)
        {
            _repo = repo;
            _order = order;
        }
        //property til viewet
        public static string Mad {  get; set; }
        public string Mad2 {  get; set; }
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Items> AllItems{ get; set; }
        public static List<Items> PizzasS {  get; set; } = new List<Items>();
        public List<Items> PizzasN { get; set; }
        public List<Burger> Burgers { get; set; }
        public List<Drink> Drinks { get; set; }
        //public string NyDescription { get; set; }

        public void OnGet()
        {
            //AllItems = _repo.GetAllPizzas();
            //_repo.AddNumbers();
            Sort = 1;
            AllItems = _repo.SortItemsNumber();
            PizzasN = PizzasS;
            

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
            PizzasN = PizzasS;
            return Page();
        }
        
        public IActionResult OnPostNummer()
        {
            Sort = 1;
            AllItems = _repo.SortItemsNumber();
            Mad2 = Mad;
            PizzasN = PizzasS;
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
          
            Customer customer = new Customer();
                
           
            PizzasS.Add(item);
            _order.Pizzas.Add(item);
            Mad = item.Name;
            Mad2 = Mad;
            PizzasN = PizzasS;

            static List<Items> Ordre()
            {
                var items = new List<Items>();
                items = PizzasS;
                return items;
            }

            Order order = new Order(customer, PizzasS, Burgers, Drinks);
            return Page();
        }
        public IActionResult OnPostDeleteOne(int nummer)
        {
            
            PizzasS.Remove(_repo.SearchItem(nummer));
            PizzasN = PizzasS;
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            return Page();
        }
        public IActionResult OnPostDelete()
        {
            Mad = "";
            PizzasS.Clear();
            PizzasN = PizzasS;
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            return Page();
        }
        public IActionResult OnPostCheckout()
        { return RedirectToPage("/Ordre/CheckOut"); }

    }


}
