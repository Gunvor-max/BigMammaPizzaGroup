namespace BigMammaPizzaGroup.Model
{
    public class Drink:Items
    {
        //properties
        
        public string Size { get; set; }

        
        //constructor
        public Drink()
        {
            Size = "";
        }
        public Drink(string name, double price, string size):base(name, price)
        {
            Size = size;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Size)}={Size}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}



