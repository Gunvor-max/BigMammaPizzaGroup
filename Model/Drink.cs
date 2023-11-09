namespace BigMammaPizzaGroup.Model
{
    public class Drink
    {
        //properties
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }

        
        //constructor
        public Drink()
        {
            Size = "";
        }
        public Drink(string name, double price, string size)
        {
            Size = size;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Size)}={Size}}}";
        }
        //tostring 

    }
}



