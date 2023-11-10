namespace BigMammaPizzaGroup.Model
{
    public class Drink
    {
        //properties
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }

        
        //constructor
        public Drink()
        {
            Size = "";
        }
        public Drink(int number, string name, double price, string size)
        {
            Size = size;
        }

        //tostring 
        public override string ToString()
        {
            return $"{{{nameof(Number)}={Number.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Size)}={Size}}}";
        }
    }
}



