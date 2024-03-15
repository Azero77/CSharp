using CA01ThreadsVsTasks;

namespace DelayVsSleep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelayUsingTask(3000);
            Console.ReadKey();
        }

        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms);
            Console.WriteLine($"Completed in Using Task with {ms} ms");
        }

        static void DelayUsingThread(int ms)
        {
            Thread.Sleep(ms);

            Console.WriteLine($"Completed in Using Task with {ms} ms");
        }

    }

    
}
