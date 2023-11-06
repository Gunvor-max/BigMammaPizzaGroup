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
        public List<Items> AllItems{ get; set; }
        //public string NyDescription { get; set; }


        public void OnGet()
        {
            //AllItems = _repo.GetAllPizzas();
            //_repo.AddNumbers();
            AllItems = _repo.GetAllItems();
        }

        public void OnPost()
        {
        }

    }
}
