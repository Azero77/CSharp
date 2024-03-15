using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace ThreadBoolCA
{
    internal class Program
    {
        public static HashSet<int> IDS = new HashSet<int>();
        private static int tasksCompleted = 0;
        private static int totalTasks = 10;
        private static readonly object lockObj = new object();

        static readonly object obj = new object();
        static void Main(string[] args)
        {


            //synchrouns
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < totalTasks; i++) DisplayItems(new object());
            stp.Stop();
            ThreadPool.SetMaxThreads(40, 10);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < totalTasks; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayItems));
            }

            // Wait until all tasks are completed
            lock (lockObj)
            {
                while (tasksCompleted < totalTasks)
                {
                    Monitor.Wait(lockObj);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms \n Synchronus : {stp.ElapsedMilliseconds}");

            Console.ReadKey();
        }

        public static void DisplayItems(object? state)
        {
            lock (obj)
            {
                Console.WriteLine("--------------");
                Console.Write("Name:");
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.Write("Id:");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                IDS.Add(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(IDS.ToArray().Length);
                Console.Write("Processor:");
                Console.WriteLine(Thread.GetCurrentProcessorId());
                Console.WriteLine("--------------");
            }

            // Increment the tasksCompleted counter atomically
            Interlocked.Increment(ref tasksCompleted);

            // Check if all tasks are completed, then signal the main thread
            if (tasksCompleted == totalTasks)
            {
                lock (lockObj)
                {
                    Monitor.PulseAll(lockObj);
                }
            }
        }
    }
}
//100911 ms
