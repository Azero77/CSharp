using System.Threading;

namespace CancellationTokenCA
{
    internal class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static async Task Main(string[] args)
        {
            await DoTasks(cancellationTokenSource);
            
        }

        static async Task DoTasks(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() => {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q) 
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Terminated.....");
                }
            });
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("checking...");
                await Task.Delay(3000);
                Console.WriteLine("Checked");
            }

            Console.WriteLine("Request Terminated");
        }
    }
}
