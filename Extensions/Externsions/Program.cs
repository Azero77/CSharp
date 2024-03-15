namespace Externsions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delivary = new Delivery();
            DeliveryService.Start(delivary);
            Console.ReadLine();
        }


        
    }
}
