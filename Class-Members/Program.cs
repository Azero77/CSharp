using System;


namespace Members
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing Swap
            int x = 1; int y = 2;
            MyClass.swap(ref x, ref y);
            Console.WriteLine("X:" + x+ "  " + "Y:" + y);

            //testing Divide

            MyClass.divide(10, 3, out int quo, out int rem);
            Console.WriteLine(quo);

            //testing multiplications with a specific base

            Console.WriteLine(MyClass.Multiplication(4, 1, 2, 3, 4, 5));


            ///testing Entity
            Entity.SetNextSerialNumber(100);
            Entity e1 = new();
            Entity e2 = new();
            Console.WriteLine(e1.Get_Serial());
            Console.WriteLine(e2.Get_Serial());
            Console.WriteLine(Entity.Get_Next());

        }
    }

    class Color
    {
        //Fields
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color Red = new Color(255, 0, 0);

        public byte R;
        public byte G;
        public byte B;

        //when we define a class all members of it should be unique and not repeated in the class
        //for methods for example
        //the signature is gonna be:
            /*The name of the method
            The number, modifiers, and types of its parameters
            The number of type parameters in generic methods.*/
        //Constructor
        public Color(byte r, byte g, byte b) => (R, G, B) = (r, g, b);
    }

    //Parameters Types
    class MyClass
    {
        //refrence parameters
        public static void swap(ref int x , ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        //out parameters

        public static void divide(int x , int y , out int qoutient , out int remainder)
        {
            qoutient = x / y;
            remainder = x % y;
        }


        //params (array paramets)

        public static int Multiplication(int base_number , params int[] numbers)
        {
            int result = base_number;
            foreach(var number in numbers)
            {
                result *= number;
            }
            return result;
        }
    }

    class Entity
    {
        static int Next_Serail_N;
        int Serial_Number;

        public Entity()
        {
            Serial_Number = Next_Serail_N++;
            
        }

        public static int Get_Next()
        {
            return Next_Serail_N;
        }

        public int Get_Serial()
        {
            return Serial_Number;
        }

        public static void SetNextSerialNumber(int Value)
        {
            Next_Serail_N = Value;
        }
    }
}