using System.Reflection;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reflection
            //Inspect the metadata at Runtime

            /*DateTime date = DateTime.Now;
            var t1 = typeof(DateTime); //compile time
            var t2 = date.GetType(); //runtime
            Console.WriteLine(t1 ==  t2);

            Console.WriteLine("FullName" + t1.FullName);
            Console.WriteLine("Name" + t1.Name);
            Console.WriteLine("NameSpace:" + t1.Namespace);
            Console.WriteLine("BaseType: " + t1.BaseType);
            Console.WriteLine("IsPublic" + t1.IsPublic);
            Console.WriteLine("Assembly:" + t1.Assembly);
            var NestTypes = typeof(Employee).GetNestedTypes();

            for (int i = 0; i < NestTypes.Length; i++)
            {
                Console.WriteLine(NestTypes[i]);
            }

            var t4 = typeof(int);
            var interfaces = t4.GetInterfaces();
            for(int i = 0;i < interfaces.Length; i++)
            {
                Console.WriteLine(interfaces[i]);
            }

            //there are two ways to instantiate an object

            //the old way
            *//* int a = new Int32():
             a = 3;*//*
            int a = (int)Activator.CreateInstance(typeof(int));
            //another overload
            var d = (DateTime) Activator.CreateInstance(typeof(DateTime), 2021, 2, 2);
            Console.ReadKey();
*/
            do
            {
                Console.Write("Enemy:");
                var input = Console.ReadLine();
                object obj = null;
                try
                {
                    var assembly = typeof(Program).Assembly.GetName().Name;
                    var Enemy = Activator.CreateInstance(assembly, assembly + "." + input);

                    obj = Enemy.Unwrap();
                }
                catch
                {

                }
                switch(obj)
                {
                    case Goon g: Console.WriteLine(g); break;
                    case Alex a: Console.WriteLine(a); break;
                    case Pixa p: Console.WriteLine(p); break;
                }
            }while(true);



        }
    }

    class Employee
    {

        public class FullTimeEmp
        {

        }
        public class PartTimeEmp
        {

        }
    }

    class Goon
    {
        public override string ToString()
        {
            return $"{{Name : Goon , Strength : 45 , Punch : 23 , Kill : 12}}";
        }
    }

    class Pixa
    {
        public override string ToString()
        {
            return $"{{Name : Pixa , Strength : 35 , Punch : 33 , Kill : 32}}";
        }
    }

    class Alex
    {
        public override string ToString()
        {
            return $"{{Name : Goon , Strength : 51 , Punch : 22 , Kill : 11}}";
        }
    }
}
