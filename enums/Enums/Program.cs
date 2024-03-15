namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enums is Strongly Typed Named Constants
            //Enum is Value Type
            //ENUM value to constants are int by default
            //you can do: "enum Month : long" to specify the type;



            //Get Month number
            Console.WriteLine((int)Month.FEB);
            


            //Try Parsing Giving Value By using Enum abstract class
            string input = "FEB";
            if(Enum.TryParse(input , out Month month))
            {
                Console.WriteLine(month.ToString());
                var x = Enum.Parse(typeof(Month), input);
                Console.WriteLine(x);
                

            }
            else
            {
                Console.WriteLine("Invalid");
            }


            //how can i get the name of the var based on its value
            var y = (Month)2;
            Console.WriteLine(y.ToString());
            Console.WriteLine("______________");

            //looping on enums
            foreach(var mon in Enum.GetNames(typeof(Month)))
            {
                Console.WriteLine($"{mon} => {(int)Enum.Parse(typeof(Month) , mon)}");
            }

            //or

            Console.WriteLine("______________");
            foreach(var num in Enum.GetValues(typeof(Month)))
            {
                Console.WriteLine($"{(Month) num} => {(int) num}");
            }

        }
    }

    //simple enums
    enum Month
    {
        JAN = 1,
        FEB,
        MAR,
        APR,
        MAY,
        JUN,
        JUL,
        AUG,
        NOV,
        DEC
    }

    //flags enum
    [Flags]
    enum DAY
    {
        Monday    = 0b_0000_0001,//1
        Tuesday   = 0b_0000_0010,//2
        Wednesday = 0b_0000_0100,//4
        Friday = 0b_0000_1000,  //8
        Saturday = 0b_0001_0000,//16
        Sunday   = 0b_0010_0000,//32

        WeekEnd = Sunday | Saturday ,
        WeekDay = Monday | Tuesday| Wednesday | Friday,
    }


    interface Methods
    {
        public abstract void returnType(int num);
        public abstract void method(int num);

        public abstract void Print(string msg);
    }

    abstract class MethodsA
    {
        public abstract void returnType(int num);

        public int Test(int num1 , int num2)
        {
            return num1 + num2;
        }


    }

    class A : Methods
    {
        public  void returnType(int num)
        {
            Console.WriteLine(num);
        }
        public void method(int num)
        {
            Console.WriteLine(num);
        }

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

