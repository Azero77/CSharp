using System;

namespace HelloWorld
{
    //when we view the solution expolorer we can see the following
    /// 
    /// 1- Properties
    ///     which Contain an assemble for your IL that will be run by your CLR
    /// 2- Dependencies
    ///     is the name of all assemblies you are using (like packages in python)
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            string aFriend = "Bill";
            Console.WriteLine(aFriend);
            //we can change the value of the variable without declaring
            aFriend = "Marry";
            Console.WriteLine(aFriend);
            Console.WriteLine("Hello " +  aFriend);
            Console.WriteLine($"Hello {aFriend}");
            Console.WriteLine($"{aFriend} has {aFriend.Length}");
            string Greeting = "---Hello---";
            Console.WriteLine(Greeting);
            Console.WriteLine(Greeting.Trim('-'));
            Console.WriteLine(Greeting.TrimEnd('-'));
            Console.WriteLine(Greeting.TrimStart('-'));
            string NewGreeting = Greeting.Replace("Hello", "Greeting");
            Console.WriteLine(NewGreeting);
            Console.WriteLine(NewGreeting.ToLower());
            Console.WriteLine(NewGreeting.Contains("Hello"));
            Console.WriteLine(NewGreeting.StartsWith("---"));
        }
    }
}