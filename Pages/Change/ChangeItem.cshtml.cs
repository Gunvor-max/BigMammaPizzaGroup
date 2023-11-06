using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BigMammaPizzaGroup.Pages.ChangeItem
{
    //[Authorize()]
    public class ChangeItemModel : PageModel
    {
        public Menucard _repo;
        public int _nytpizzanummer;

        public ChangeItemModel(Menucard repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public int NytPizzaNummer { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NytPizzaNavn { get; set; }

        [BindProperty]
        public double NyPris { get; set; }

        [BindProperty]
        public string NyDescription { get; set; }
        public List<string> NyToppingList = new List<string>();
        public void OnGet(int nummer)
        {
            Items item = _repo.SearchItem(nummer);


            NytPizzaNummer = item.Number;
            NytPizzaNavn = item.Name;
            NyPris = item.Price;
            if (item is Pizza)
            {
                Pizza p = item as Pizza;
                NyDescription = p.GetToppings();
            }
            else if (item is Burger)
            {
                Burger b = item as Burger;
                NyDescription = b.GetToppings();
            }
            else if (item is Drink) 
            {
                Drink d = item as Drink;
            }

        }
        public IActionResult OnPostChange()
        {
            if (true)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Items item = _repo.SearchItem(NytPizzaNummer);

                NyToppingList.Add(NyDescription);

                item.Name = NytPizzaNavn;
                item.Price = NyPris;
                if (item is Pizza)
                {
                    Pizza p = item as Pizza;
                    p.Toppings = NyToppingList;
                }
                //else if (item is Burger)
                //{
                //    Burger b = item as Burger;
                //    NyDescription = b.GetToppings();
                //}
                //else if (item is Drinks)b
                //{
                //    Drinks d = item as Drinks;
                //}

                return RedirectToPage("/PizzaMenu/Index");
            }
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/PizzaMenu/Index");
        }
    }
}
