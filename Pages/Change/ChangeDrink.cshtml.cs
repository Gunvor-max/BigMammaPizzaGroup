using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Change
{
    public class ChangeDrinkModel : PageModel
    {
        public static int Sort { get; set; } = 1;
        public bool Button { get; set; }
        public void OnGet()
        {
        }
    }
}
