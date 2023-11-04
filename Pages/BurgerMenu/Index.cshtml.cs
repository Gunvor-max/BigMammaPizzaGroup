using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;

namespace BigMammaPizzaGroup.Pages.BurgerMenu
{
    public class BurgerMenuModel : PageModel
    {

        public List<Items> BurgerMenukort { get; set; }

        public void OnGet()
        {
            Menucard repo = new Menucard();
            BurgerMenukort = repo.GetAllBurgers();
            repo.AddNumbers();
        }
    }
}
