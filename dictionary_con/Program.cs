using System;
using System.Collections.Generic;

namespace dictionary_con
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  Dictionary<int, string> RookieOfTheYear = new();
            RookieOfTheYear.Add(2004, "Anas Zaggar");
            RookieOfTheYear.Add(2005, "Azero");
            Console.WriteLine(RookieOfTheYear[2004]);


            //we can do more than that

            Dictionary<string, List<string>> WishList = new();
            WishList.Add("Anas", new List<string> { "Xbox", "Tesla", "Pizza" });
            WishList.Add("Azero", new List<string> { "Ps5", "Ford", "Hot Dog" });
            foreach(var (key,value) in WishList)
            {
                Console.WriteLine($"WishList of {key}");
                foreach(var item in value)
                {
                    Console.WriteLine($"\t {item}");
                }
            }*/

            Console.WriteLine("-----------------");
            //nice example
            string test = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            Dictionary<char , List<string>> keyValuePairs = new Dictionary<char , List<string>>();
            foreach(string word in test.Split())
            {
                foreach(char ch in word)
                {
                    char c = char.ToLower(ch);
                    if (!keyValuePairs.ContainsKey(c))
                    {
                        keyValuePairs.Add(c, new List<string> { word });
                    }
                    else
                    {
                        keyValuePairs[c].Add(word);
                    }
                }
            }

            foreach(var key in keyValuePairs.Keys)
            {
                Console.Write($"{key}:");
                foreach(var value in keyValuePairs[key])
                {
                    Console.WriteLine("\t\t" + value);
                }
            }
            Console.WriteLine("-----------------");

            List<Employee> employees = new List<Employee>
            {
                new Employee(100 , "Reem S.",null),
                new Employee(101 , "Jack" , 100),
                new Employee(102 , "Ali" , 100),
                new Employee(103 , "Abeer s." , 102),
                new Employee(104 , "Radwan N," , 102),
                new Employee(105 , "Nancy" , 101),
                new Employee(106 , "Saleh A." , 104),
            };

            var managers = employees.ToLookup(x => x.ReportTo).ToDictionary(x => x.Key ?? -1 ,x=>x.ToList());
            
            foreach(var managerKey in managers.Keys)
            {
                if(managerKey == -1)
                {
                    Console.WriteLine("The Big Boss is " + employees.Find(x => x.ReportTo is null));
                    continue;
                }
                Console.WriteLine(employees.Find(x => x.Id == managerKey) + ":");
                foreach(var item in managers[managerKey])
                {
                    Console.WriteLine("\t\t"+ item);
                }
            }
            Console.ReadKey();
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReportTo { get; set; }

        public Employee(int id, string name, int? reportTo)
        {
            Id = id;
            Name = name;
            ReportTo = reportTo;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}