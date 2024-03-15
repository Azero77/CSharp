using CA01ThreadsVsTasks;


namespace ContinueWithCA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(()=> PrimeInRange(2 , 3_000_000));
            
            //int result = t.Result; //Blocks the Code
            /*var awaiter = t.GetAwaiter();*/
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));
            Console.WriteLine(t.Status);
            t.ContinueWith((x) => Console.WriteLine(x.Result));
            Thread.Sleep(2000);
            Console.WriteLine("Metigator");
            Console.Read();
        }
        static int PrimeInRange(int LowerBound, int UpperBound)
        {
           
            int Count = 0;
            for (int i = LowerBound; i < UpperBound; i++)
            {
                bool IsPrime = true;
                int j = LowerBound;
                while (j < (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                    j++;
                }
                if (IsPrime) Count++;
            }

            return Count++;

        }
    }


}
