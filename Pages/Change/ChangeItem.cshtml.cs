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
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NytPizzaNavn { get; set; }

        [BindProperty]
        public double NyPris { get; set; }
        public static int Sort { get; set; } = 1;

        [BindProperty]
        public string NyDescription { get; set; }
        public List<string> NyToppingList = new List<string>();
        public static string NyToppingString = "";
        public string NyString = NyToppingString;
        public List<Items> AllItems { get; set; }
        public Dictionary<int, Items> Menu {  get; set; }
        public bool Button { get; set; }
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
            AllItems = _repo.SortItemsNumber();
        }

        public void OnPostChangeItem(int? nummer)
        {
                
                Items item = _repo.SearchItem((int)nummer);

                
                NytPizzaNummer = item.Number;
                NytPizzaNavn = item.Name;
                NyPris = item.Price;
                NyDescription = item.Description;
            //if (item is Pizza)
            //{
            //    Pizza p = item as Pizza;
            //    NyDescription = p.GetToppings();
            //}

            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                default: AllItems = _repo.SortItemsNumber(); break;
            }
            Button = true;
        }

        public IActionResult OnPost�ndre()
        {
            
                
            if (!ModelState.IsValid)
            {
                switch (Sort)
                {
                    case 1: AllItems = _repo.SortItemsNumber(); break;
                    case 2: AllItems = _repo.SortItemsPrice(); break;
                    case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                    default: AllItems = _repo.SortItemsNumber(); break;
                }
                return Page();
            }

            Items item = _repo.SearchItem(NytPizzaNummer);

            NyToppingList.Add(NyDescription);

            item.Name = NytPizzaNavn;
            item.Price = NyPris;
            item.Description = ListToString();
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                default: AllItems = _repo.SortItemsNumber(); break;
            }
            Button = false;
                return Page();
            
        }

        public IActionResult OnPostCancel()
        {
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                default: AllItems = _repo.SortItemsNumber(); break;
            }
            NytPizzaNummer = _repo.NextNumber();
            return Page();
        }
        public void OnPostPris()
        {
            if(Sort == 1 || Sort == 3 && !(_repo.SortItemsNumber == _repo.SortItemsPrice))
            {
                AllItems = _repo.SortItemsPrice();
                Sort = 2;
            }
            else if(Sort == 2 || _repo.SortItemsNumber == _repo.SortItemsPrice)
            {
                AllItems = _repo.SortItemsPrice(); AllItems.Reverse();
                Sort = 3;
            }
            NytPizzaNummer = _repo.NextNumber();
            
        }
        public void OnPostNummer()
        {
            AllItems = _repo.SortItemsNumber();
            Sort = 1;
            NytPizzaNummer = _repo.NextNumber();
        }

        
        public IActionResult OnPostOpret()
        {
            
            if (!ModelState.IsValid)
            {
                switch (Sort)
                {
                    case 1: AllItems = _repo.SortItemsNumber(); break;
                    case 2: AllItems = _repo.SortItemsPrice(); break;
                    case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                    default: AllItems = _repo.SortItemsNumber(); break;
                }
                NytPizzaNummer = _repo.NextNumber();
                return Page();
            }
            NyToppingList.Add(NyDescription);
            Pizza newpizza = new Pizza(NytPizzaNavn, NyPris, NyToppingList);
            newpizza.Number = _repo.NextNumber();
            _repo.AddItem(newpizza);
            NyToppingString = newpizza.GetToppings();
            newpizza.Description = NyToppingString;
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                default: AllItems = _repo.SortItemsNumber(); break;
            }
            NytPizzaNummer = _repo.NextNumber();
            return Page();
        }
       

        public IActionResult OnPostDeleteItem(int item) 
        {
            _repo.DeleteItem(item);
            switch (Sort)
            {
                case 1: AllItems = _repo.SortItemsNumber(); break;
                case 2: AllItems = _repo.SortItemsPrice(); break;
                case 3: AllItems = _repo.SortItemsPrice(); AllItems.Reverse(); break;
                default: AllItems = _repo.SortItemsNumber(); break;
            }
            NytPizzaNummer = _repo.NextNumber();
            return Page();
        }
    }
}
