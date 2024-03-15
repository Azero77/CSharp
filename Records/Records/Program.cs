namespace Records
{
    internal class Program
    {
        //records are like classes but it is :
        //implement IEquality<T>
        //implement object.Equals
        //implement ==
        //implement !=
        //implement GetHashCode();
        //mutaple while positional record are immutable by default;
        static void Main(string[] args)
        {

            /*var p1 = new Point(2, 3);
            Pointt p3 = new Pointt(2, 3);
            Point p2 = new Point(2, 3);
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1);
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p3.GetHashCode());*/
            var p1 = new Point(2, 3);
            Point p2 = p1 with { Y = 3};
            
        }
    }

    record Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Pointt
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Pointt(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    //positional record are immutable
    record P(int X , int Y);

    //positional struct records are mutable by default if you want it to be immutable => public recod readonly struct RecordStruct()
    public record struct RecordStruct(int x , int y);
    
}
