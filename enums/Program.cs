using System;


namespace enums
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine((int) Planets.Earth);
            Console.WriteLine(Planets.Earth + "Number is #" + (int)Planets.Earth);
            Console.WriteLine("The Radius of " + PlanetsRadius.Earth + "Is : " + Compute(PlanetsRadius.Earth) + "Km");
        }
        public static double Compute(PlanetsRadius radius )
        {
            double Volume = (4.0 / 3.0) * Math.PI * Math.Pow(((int)radius), 3);
            return Volume;
        }
    }
    //enum is a special class........
    //(int) to convert it to a number
    //enum.element.ToString() to convert it to a string
    //we can set a special number to every element and it will something like a dictionary in python with keys is a string and values are integers
    enum Planets
    {
        Earth = 3 ,
        Pluto = 1,
        Mercury = 4,
    }

    enum PlanetsRadius
    {
        Earth = 64234,
        Pluto = 12443,
        Mercury = 124932,
    }

}