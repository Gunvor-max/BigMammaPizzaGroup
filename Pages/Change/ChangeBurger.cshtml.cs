using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Change
{
    public class ChangeBurgerModel : PageModel
    {
        public static int Sort { get; set; } = 1;
        public bool Button { get; set; }
        public string NytBurgerNavn { get; set; }
        public string NyDescription { get; set; }
        public int NytBurgerNummer { get; set; }
        public string NyPris { get; set; }
        public void OnGet()
        {
        }
    }
}
