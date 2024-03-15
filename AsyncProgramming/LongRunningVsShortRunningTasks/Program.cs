namespace LongRunningVsShortRunningTasks
{
    public class MyProgram
    {
        static void Main(string[] args)
        {
            //short running tasks it is better to be in a thread pool for the scheduler to move and play threads like it wants
            //while long running tasks it is better to be running away from the thread pool
            var t = Task.Factory.StartNew(LongRunningTask ,TaskCreationOptions.LongRunning);
            Console.Read();
        }

        public static void GetThreadInfo(Thread th , int line = 1)
        {/*
            Console.WriteLine("Id:" + th.ManagedThreadId + "line:" + line);
            Console.WriteLine("BackGround:"+ th.IsBackground);
            Console.WriteLine("Pooled:"+ th.IsThreadPoolThread);*/
            Console.WriteLine("Id:" + th.ManagedThreadId + "line:" + line + "\nBackGround:" + th.IsBackground + "\nPooled:" + th.IsThreadPoolThread + "\nProcessor:" + Thread.GetCurrentProcessorId() + "\n");
        }

        static void LongRunningTask()
        {
            Thread.Sleep(3000);
            GetThreadInfo(Thread.CurrentThread);
            Console.WriteLine("This is from long thread");

        }


    }

    
}
