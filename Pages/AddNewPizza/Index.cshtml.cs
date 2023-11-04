using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace BigMammaPizzaGroup.Pages.AddNewPizza
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public Menucard _repo;

        public IndexModel(Menucard repo)
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
        public List<string> NyToppingList = new List<string>();
        public string NyToppingString = "";

        public void OnGet()
        {
            NytPizzaNummer = _repo.NextNumber();
        }

        
        public IActionResult OnPost()
        {
            if (Request.Form["action"] == "TilføjTopping")
            {
                NyToppingList.Add(NyDescription);
            }

            if (Request.Form["action"]=="OpretNyPizza")
            { 
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                //Menucard nypizza = new Menucard();
                //Pizza pizza = new Pizza();
                NyToppingList.Add(NyDescription);
                Pizza newpizza = new Pizza(NytPizzaNavn, NyPris, NyToppingList);
                newpizza.Number = _repo.NextNumber();
                _repo.AddItem(newpizza);



                return RedirectToPage("/PizzaMenu/Index");
            }
            
            return Page();
        }
    }
}
