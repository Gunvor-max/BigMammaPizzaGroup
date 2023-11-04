using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;

namespace BigMammaPizzaGroup.Pages.DrikkevarerMenu
{
    public class DrinksMenuModel : PageModel
    {

        public List<Items> DrinksMenukort { get; set; }

        public void OnGet()
        {
            Menucard repo = new Menucard();
            DrinksMenukort = repo.GetAllDrinks();
            repo.AddNumbers();
        }
    }
}