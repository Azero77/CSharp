using System;


namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            (string message , bool valid) = new Program().CheckingAddress("123 sea st");
            if(valid)
            {
                Console.WriteLine(message + " Is Valid");
            }
            else
            {
                Console.WriteLine(message + ",Location is not valid");
            }
        }

        public (string new_address , bool is_valid) CheckingAddress(string Address)
        {
            if(Address.Equals("123 sea st"))
            {
                return ("123 sea street", true);
            }
            else
            {
                return (Address, false);
            }
        }
    }


}