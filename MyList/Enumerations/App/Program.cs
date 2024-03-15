namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*FiveIntegers List = new FiveIntegers(13,11,5,28,12);
            
            foreach(int i in List)
            {
                Console.WriteLine(i);
            }*/

            Random rnd = new Random();
            var MyList = new List<Tempreture>();
            for(int i = 0; i < 100; i++)
            {
                MyList.Add(new Tempreture(rnd.Next(-30, 50)));  
            }
            /*MyList.Sort();
            foreach(var item in MyList)
            {
                Console.WriteLine(item.Value);
            }*/
            DateTime item = DateTime.Parse("2021-2-3");
            





            Console.ReadLine();
        }
    }
}
