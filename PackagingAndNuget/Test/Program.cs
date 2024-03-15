using MetigatorCA;
using MetigatorCA.Models;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d = new DecimalSystem("10");

            var binary = d.To(NumberBaseSystem.Binary);
            var octal = d.To(NumberBaseSystem.Octal);
            var hexadecimal = d.To(NumberBaseSystem.HexaDecimal);
            List<string> items = [binary, octal, hexadecimal];
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
