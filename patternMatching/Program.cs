using System;

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new(1, "Anas", 19);
        Person p2 = new(2, "Azero", 20);
        object s = "string";
        var A = new int?[12];
        //type matching
        if(s is string val)
        {
            Console.WriteLine("After Patter Matching:" + val);
        }
        if(A[0] is not null)
        {
            Console.WriteLine("A[0] is not null");
        }
        else { Console.WriteLine("it is"); }

        if(p1 is Person { Name: "Anas" , Id : 1 })
        {
            Console.WriteLine($"It is {p1.Name}");
        }

        if(p2 is Person { Name:})
    }
    //pattern matching

}

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(int id, string name , int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}