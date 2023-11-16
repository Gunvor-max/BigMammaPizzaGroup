using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.DashBoard
{
    [Authorize]
    public class ControlPanelModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostChangePizza()
        {
            return RedirectToPage("/Change/ChangeItem");
        }

        public IActionResult OnPostChangeBurger()
        {
            return RedirectToPage("/Change/ChangeBurger");
        }
        public IActionResult OnPostChangeDrink()
        {
            return RedirectToPage("/Change/ChangeDrink");
        }

    }
}
