using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace BigMammaPizzaGroup.Pages.AddNewPizza
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private IMenucard _repo;

        //Dependency injection
        public IndexModel(IMenucard repo)
        {
            _repo = repo;
            
        }

        [BindProperty]
        public int NytPizzaNummer { get; set; }
        [BindProperty]
        public bool ButtonClicked { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NytPizzaNavn { get; set; }

        [BindProperty]
        public double NyPris { get; set; }

        [BindProperty]
        public string NyDescription { get; set; }
        public static List<string> NyToppingList = new List<string>();
        public static string NyToppingString = "";

        public string ListToString()
        {
            foreach(string top in  NyToppingList)
            {
                NyToppingString += top + ", ";
            }
            return NyToppingString;
        }
        public void OnGet()
        {
            NytPizzaNummer = _repo.NextNumber();
        }


        public IActionResult OnPostOpret()
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Pizza newpizza = new Pizza(NytPizzaNavn, NyPris, NyToppingList);
            newpizza.Number = _repo.NextNumber();
            _repo.AddItem(newpizza);
            NyToppingString = "";
            return RedirectToPage("/PizzaMenu/Index");
        }
        public IActionResult OnPostTilføj()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NyToppingList.Add(NyDescription);
            return Page();
        }
    }

}
