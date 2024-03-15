using System;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("Anas", 15);
            var p2 = new Person("Azero", 29);
            var p3 = new Person("Test", 20);

            List<Person> list = new List<Person>() { p1,p2,p3};
            var OrderByAge = list.OrderBy(x => x.Age);
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}