using BigMammaPizzaGroup.Model;
using System.Text;

namespace BigMammaPizzaGroup.Services
{
    public interface IMenucard
    {
        public Dictionary<int, Items> Menu { get; set; }

        Items AddItem(Items item);
        void AddNumbers();
        Items DeleteItem(int item);
        List<Items> GetAllBurgers();
        List<Items> GetAllDrinks();
        List<Items> GetAllItems();
        List<Items> GetAllPizzas();
        Items FindLowestPrice(List<Items> menu);
        List<Items> SortItemsPrice();
        Items FindLowestNumber(List<Items> menu);
        List<Items> SortItemsNumber();
        string GetFood2(List<Items> food);
        int NextNumber();
        //void PopulateBurgerRepository();
        //void PopulatePizzaRepository();
        Items SearchItem(int item);
    }
}