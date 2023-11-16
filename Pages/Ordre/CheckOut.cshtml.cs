using BigMammaPizzaGroup.Model;
using BigMammaPizzaGroup.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaPizzaGroup.Pages.Ordre
{
    public class CheckOutModel : PageModel
    {
        private Order _order;

        public List<Items> Order { get; set; }
        public List<Burger> Order2 { get; set; }
        public List<Drink> Order3 { get; set; }

        public CheckOutModel(Order order)
        {
            _order = order;
        }

        public void OnGet()
        {
            Order = _order.Pizzas;
            Order2 = _order.Burgers;
            Order3 = _order.Drinks;


        }


    }
}
