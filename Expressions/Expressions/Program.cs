using CostumLib;
using System.Security.Cryptography.X509Certificates;



namespace Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Primary Expressions => type nameVar = Value;
            //ex
         //type name   = lookup.methodCall();
            var amount = Math.Cos(30);
            //void Expressions
            Console.WriteLine("Does not return a value and we do it for functionality in the code");
            //coalasing Null
            string s = null;
            string s1 = s??"Issam"; // if s is null assign s1 to issam else assign it to s
            Console.WriteLine(s1);
            s = s1 ?? "Waleed";
            Console.WriteLine(s);

            //Conditional null
            string a = null;

            string b = a?.ToUpper(); //if a is not null => get its upper else return null
            //the same as
            string c = a is null ? null : a.ToUpper();
            Console.WriteLine($"B==C:" + b == c);
            

            //switch statement

            object o = 3;

            switch (o)
            {
                case int i:
                    Console.WriteLine($"the square root of {i} = {i*i}");
                    break;
                case string ii:
                    Console.WriteLine($"The capilization of {ii} is {ii.ToUpper()}");
                    break;
            }


            bool x = true;

            switch(x)
            {
                case bool when x == true:
                    Console.WriteLine("True");
                    break;
                case bool u:
                    Console.WriteLine(u);
                    break;
            }

            int cardNo = 13;
            string cardStr = cardNo switch
            {
                1 => "One",
                2 => "Two",
                _ => "WildCard",
            } ;

            //jump statements

            int iii = 0;
            start:
            if(iii <= 5)
            {
                Console.WriteLine(iii);
                ++iii;
                goto start;
                
            }

            Console.ReadLine();
            B xxx = new();
            
        }

        public class B : A.C
        {
            public const double x = 1;
        }

    }


}
