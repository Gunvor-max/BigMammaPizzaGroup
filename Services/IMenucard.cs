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
        int NextNumber();
        //void PopulateBurgerRepository();
        //void PopulatePizzaRepository();
        Items SearchItem(int item);
    }
}