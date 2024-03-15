namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {

                var p = new Pizza();
                DateTime Start = DateTime.Now;

                PizzaExtensions.AddPineApple(PizzaExtensions.AddCheese(PizzaExtensions.AddSauce(PizzaExtensions.AddToppings(PizzaExtensions.AddDough(p, "GG"), 4m), 4m), true), true);

                DateTime End = DateTime.Now;

                var Regular = End - Start;

                Start = DateTime.Now;

                p.AddDough("GG").
                    AddToppings(4m).
                    AddSauce(4m).
                    AddCheese(true).
                    AddPineApple(true);

                End = DateTime.Now;

                var Modern = End - Start;
                Console.WriteLine("Regular:" + Regular);
                Console.WriteLine("Modern:" + Modern);
                if (Regular > Modern) Console.WriteLine("Modern Wins");
                else Console.WriteLine("Regular wins");
            }
         }
    }
    public class Pizza
    {
        public string Content { get; set; }
        public decimal TotalPrice { get; set; }

        
    }

    public static class PizzaExtensions
    {
        public static Pizza AddDough(this Pizza value , string Type)
        {
            value.TotalPrice += 4m;
            value.Content += $"{Type} Dough";
            return value;
        }
        public static Pizza AddToppings(this Pizza value , decimal Price)
        {
            value.Content += ", Toppings";
            value.TotalPrice += Price;
            return value;
        }

        public static Pizza AddSauce(this Pizza value, decimal Price)
        {
            value.Content += ", Sauce";
            value.TotalPrice += 2m;
            return value;
        }

        public static Pizza AddCheese(this Pizza value, bool Extra)
        {
            value.Content += (Extra ? "Extra" : "Normal") + "Cheese"; 
            value.TotalPrice += Extra ? 6m : 4m;
            return value;
        }
        public static Pizza AddPineApple(this Pizza value, bool Extra)
        {
            value.Content += (Extra ? "Extra" : "Normal") + "PineApple";
            value.TotalPrice += Extra ? 6m : 4m;
            return value;
        }

    }
}
