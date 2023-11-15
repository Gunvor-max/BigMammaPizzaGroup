using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Ordre
{
    public class CheckOutModel : PageModel
    {
        public BurgerRepository _burgerMenuKort;
        private IMenucard _repo;

        public List<Burger> BurgerMenukort { get; set; }

        //Dependency constructor 
        public CheckOutModel(BurgerRepository repob)
        {
            _burgerMenuKort = repob;
        }

        //Dependency constructor 
        public CheckOutModel(IMenucard repo)
        {
            _repo = repo;
        }

        //property til viewet
        public static string Mad { get; set; }
        public string Mad2 { get; set; }
        public static int Sort { get; set; }
        public int NytPizzaNummer { get; set; }
        Items item { get; set; }
        public Items Tilføjet { get; set; }
        public List<Burger> AllItemsb { get; set; }
        public List<Items> AllItems { get; set; }
        public static List<Items> PizzasS { get; set; } = new List<Items>();
        public List<Items> PizzasN { get; set; }
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
            AllItems = _repo.SortItemsNumber();
            PizzasN = PizzasS;
        }


    }
}
