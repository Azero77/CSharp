using System;


namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FactoryPoints(10);
            foreach(Point P in factory.CreatePoints())
            {
                Console.WriteLine("Point:\n X:" + P.X + ":: Y:" + P.Y + "\n");
            }
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            //testing Type Parameters
            var Obj_Pair = new Pair<int, string>(12, "Azero");
            Console.WriteLine(Obj_Pair.First.ToString());
        }
    }

    class Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

    class FactoryPoints(int NumberOfPoints)
    {
        public IEnumerable<Point> CreatePoints()
        {
            var generator = new Random();
            for(int i = 0;  i < NumberOfPoints; i++)
            {
                yield return new Point(generator.Next(), generator.Next());
            }
        }
    }

    //Type Parameters
    public class Pair<T1 , T2>
    {
        public T1 First { get; init; }
        public T2 Second { get; init; }

        public Pair(T1 first, T2 second) => (First, Second) = (first, second);

    }


    //inheritance and base classes

    public class Point3D : Point
    {
        //the child can inherit the class members of its base but not the constructor or finalizers
        public int Z { get; init; }
        public Point3D(int x , int y , int z) : base(x, y)
        {
            Z = z;
        }
    }

    //virtual , abstract , override
}