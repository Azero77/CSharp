using System.Reflection;

namespace ReflectionPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new BankAccount(1 , 1000 , "Azero");
            b.WithDraw(500);
            /*Console.WriteLine(b);*/
            b.NegativeValue += NegativeValueEventHandlerMethod;
            b.WithDraw(600);
            Console.WriteLine(b);
            //Now I can get the the elements of the class in run time
            var items = typeof(BankAccount).GetMembers();
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

            //in the same way you can get
            /*var i1 = typeof(BankAccount).GetFields();

            var i2 = typeof(BankAccount).GetEvents();

            var i3 = typeof(BankAccount).GetConstructors();

            var i4 = typeof(BankAccount).GetDefaultMembers();*/

            //how to get the parameters and invoke methods

            var t = typeof(BankAccount);
            var method = t.GetMethod("Deposit");
            method.Invoke(b, new object[] { 500m });
            Console.WriteLine(b);
            Console.WriteLine("##########################################");
            //how to work with refrences to assemblies from apart
            string path =@"C:\Azero\full-csharp\MyList\bin\Debug\net8.0\MyList.dll";
            var assembly = Assembly.LoadFrom(path);
            foreach(var item in assembly.GetTypes())
            {
                Console.WriteLine(item.ToString());
                foreach(var field in item.GetMembers())
                {

                    Console.WriteLine("\t" + field.ToString());
                }
            }

        }

        private static void NegativeValueEventHandlerMethod(object? sender, EventArgs e)
        {
            Console.WriteLine("Aha");
        }
    }
}
