using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using mini_big_mammas_pizzaria.Services;

namespace BigMammaPizzaGroup.Pages.BurgerMenu
{
    public class BurgerMenuModel : PageModel
    {

        public List<Burger> BurgerMenukort { get; set; }

        public void OnGet()
        {
            BurgerRepository repo = new BurgerRepository();
            BurgerMenukort = repo.GetAllBurgers();
        }
    }
}
