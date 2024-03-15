using System.Collections;

namespace IEnumerableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Integers = new MyList<int>(5);
            Integers.Add(1);
            Integers.Add(2);
            Integers.Add(3);
            Integers.Add(4);
            Integers.Add(5);
            /*
                        foreach (var item in Integers) Console.WriteLine(item);*/
            Foreach(Integers, (x) => Console.WriteLine(x));
        }

        static void Foreach<T>(MyList<T> items , Action<object> action)
        {
            IEnumerator enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                action(item);
            }
        }
    }

}
