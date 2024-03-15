using System;


namespace Delegates
{
    class Program
    {
        public delegate bool Fun<T>(T x);

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var items = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
            Print<int>(arr, (x) => x % 2 == 0);
            Console.WriteLine("0000000000000000000");
            Print<int>(items, (x) => x % 2== 1);
        }

        public static void Print<T>(IEnumerable<T> arr , Predicate<T> filter)
        {
            foreach (T i in arr)
            {
                if (filter(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    
}