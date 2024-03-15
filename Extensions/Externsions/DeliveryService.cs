using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Externsions
{
    internal class DeliveryService
    {
        private static Random random = new Random();
        

        public static void Start(Delivery delivery)
        {
            try
            {
                Processing(delivery);
                Packaging(delivery);
                Transmitting(delivery);
                Delivering(delivery);
            }

            catch (InvalidDeliveryException ex)
            {
                Console.WriteLine(ex.Status.ToString() + " Is not Finished ");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Processing(Delivery delivery)
        {

            Fakeit("Processing");
            if (random.Next(1,5) == 1)
            {
                throw new InvalidDataException("Failed in Processing");
            }
            delivery.Status = Delivery.DeliveryStatus.Proccessed;
        }

        private static void Packaging(Delivery delivery)
        {

            Fakeit("Packaging");

            if (random.Next(1, 5) == 1)
            {
                throw new InvalidDeliveryException(delivery.Status, "Invalid at Packaging");
            }
            delivery.Status = Delivery.DeliveryStatus.Packaged;
        }

        private static void Transmitting(Delivery delivery)
        {

            Fakeit("Transmitting");
            if (random.Next(1, 5) == 1)
            {
                throw new InvalidDeliveryException(delivery.Status, "Invalid at Transmitting");
            }
            delivery.Status = Delivery.DeliveryStatus.Tranmitted;
        }

        private static void Delivering(Delivery delivery)
        {

            Fakeit("Delivering");

            if (random.Next(1, 5) == 1)
            {
                throw new InvalidDeliveryException(delivery.Status, "Invalid at Delivering");
            }
            delivery.Delivered += End;
            delivery.Status = Delivery.DeliveryStatus.Delivered;
            delivery.OnDelivered();
        }

        private static void  Fakeit(string str)
        {
            Console.Write(str);
            for(int i = 0; i < 5; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine("");
        }

        private static void End(object sender , EventArgs e)
        {
            Console.WriteLine("Packaged!!");
        }
        
    }

}
