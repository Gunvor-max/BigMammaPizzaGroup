using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.DashBoard
{
    public class ControlPanelModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostAddNewPizza()
        {
            return RedirectToPage("/AddNewPizza/Index");
        }

        public IActionResult OnPostChangePizza()
        {
            return RedirectToPage("/Change/ChangeItem");
        }

        public IActionResult OnPostDeletePizza()
        {
            return RedirectToPage("");
        }

    }
}
