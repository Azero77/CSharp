namespace CA01ThreadsVsTasks
{
    internal class Program
    {
        async static Task  Main(string[] args)
        {
            /*Thread th1 = new Thread(Display);
            th1.Start();
            //but when using Tasks
            th1.Join();
            Task.Run(Display);*/
            Task<DateTime> task = Task.Run(() => DateTime.Now);
            var t = await task;
            Console.WriteLine(t);
            Console.WriteLine("First");

        }
        
        static void Display()
        {
            Console.Write("Id:");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.Write("BackGround:");
            Console.WriteLine(Thread.CurrentThread.IsBackground);

            Console.Write("Alive:");
            Console.WriteLine(Thread.CurrentThread.IsAlive);

            Console.Write("ThreadPool:");
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        }

        static DateTime ReturnDateTime()
        {
            Thread.Sleep(1000);
            Console.WriteLine(DateTime.Now);
            return DateTime.Now;
        }
    }
}
