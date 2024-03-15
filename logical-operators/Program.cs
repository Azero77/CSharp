using System;

namespace Logical
{
    class Program
    {
        static void Main(string[] args)
        {
            ///there are
            ///1-unary operators -> !
            //ex
            /*Console.WriteLine(!true);*/
            ///2-binary operators
            ///And -> & , OR -> | , ^ -> XOR (exclusive or) ==> evaluates both operands
            //The conditional logical operators && and || don't support bool? operands. only & , ^,|
            ///&& , || ,-> evaluates right hand only if necessary
            ///ex
            bool a = false & new Program().SecondOperand();
            Console.WriteLine(a);
            bool b = false && new Program().SecondOperand();
            Console.WriteLine(b);
            Console.WriteLine("############");
            bool c = true && new Program().SecondOperand();
            Console.WriteLine(c);
            //using x==y is equivelant to x = x=y
            // x op= y -> x = x op y
            Console.WriteLine(a &= b);
            //chars:
            /*The char type is implicitly convertible to the following integral types: ushort, int, uint, long, and ulong.It's also implicitly convertible to the built-in floating-point numeric types: float, double, and decimal. It's explicitly convertible to sbyte, byte, and short integral types.

There are no implicit conversions from other types to the char type.However, any integral or floating-point numeric type is explicitly convertible to char */
        }
        bool SecondOperand()
        {
            Console.WriteLine("Run");
            return true;
        }

    }
}