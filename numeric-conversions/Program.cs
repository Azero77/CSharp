using System;

namespace conversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //implicit conversion
            int a = 123;
            double b;
            b = a;
            Console.WriteLine($"a:{a} , b: {b}");
            /*In two's complement, negative numbers are represented by the binary complement of the corresponding positive number. For example, for an 8-bit signed integer, -12 is represented as:*/
            sbyte bbb = -12;
            Console.WriteLine((byte) bbb);
            Console.WriteLine((int)1.9f);
        }
    }
}