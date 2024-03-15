using Fifo.Lib;

using Fifo.Cars;
namespace Fifo.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d = new Demo("Anas");
            Console.WriteLine(d.Description());

            Console.WriteLine(new Asia.Toyota().ToString());
            Console.ReadLine();
        }
    }
}
