using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace BigMammaPizzaGroup.Pages.ChangeItem
{
    //[Authorize()]
    public class ChangeItemModel : PageModel
    {
        public IMenucard _repo;
        public int _nytpizzanummer;

        public ChangeItemModel(IMenucard repo)
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
        public static int Sort {  get; set; }

        [BindProperty]
        public string NyDescription { get; set; }
        public List<string> NyToppingList = new List<string>();
        public static string NyToppingString = "";

        public List<Items> AllItems { get; set; }
        public string ListToString()
        {
            NyToppingString = "";
            foreach (string top in NyToppingList)
            {
                NyToppingString += top == NyToppingList.First() ? top : ", " + top;
            }
            return NyToppingString;
        }
        public void OnGet()
        {
            NytPizzaNummer = _repo.NextNumber();
            AllItems = _repo.GetAllItems();
        }

        public void OnPostChangeItem(int? nummer)
        {
            //if (nummer == null)
            //{
            //    AllItems = _repo.GetAllItems();
            //}
            //else
            {
                AllItems = _repo.GetAllItems();
                Items item = _repo.SearchItem((int)nummer);


                //NytPizzaNummer = item.Number;
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

                AllItems = _repo.GetAllItems();
            }
            }

            public IActionResult OnPostChange()
        {
            if (true)
            {
                AllItems = _repo.GetAllItems();
                //if (!ModelState.IsValid)
                //{
                //    return Page();
                //}
                
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
        public IActionResult OnPostPris()
        {
            AllItems = _repo.SortItemsPrice();
            return Page();
        }
        public IActionResult OnPostNummer()
        {
            AllItems = _repo.GetAllItems();
            return Page();
        }

        //Marco laver lort i koden kl 22
        public IActionResult OnPostOpret()
        {
            AllItems = _repo.GetAllItems();
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            Pizza newpizza = new Pizza(NytPizzaNavn, NyPris, NyToppingList);
            newpizza.Number = _repo.NextNumber();
            _repo.AddItem(newpizza);
            NyToppingString = "";
            
            return Page();
        }
        public IActionResult OnPostTilføj()
        {
            switch (Sort)
            {
                case 1: AllItems = _repo.GetAllItems(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
            }
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            NyToppingList.Add(NyDescription);
            
            return Page();
        }
    }
}
