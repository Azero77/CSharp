using LongRunningVsShortRunningTasks;


namespace ParellelPrograming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<DailyWork> MyList = new List<DailyWork>
            {
                new DailyWork("T1"),
                new DailyWork("T2"),
                new DailyWork("T3"),
                new DailyWork("T4"),
                new DailyWork("T5"),
                new DailyWork("T6"),
                new DailyWork("T6"),
                new DailyWork("T6"),
                new DailyWork("T6"),
                new DailyWork("T6"),
                new DailyWork("T6"),
            };

            await ParellelProgramming(MyList);
        }

        static Task ParellelProgramming(IEnumerable<DailyWork> things)
        {
            Parallel.ForEach(things , thing =>thing.Process());
            return Task.CompletedTask;
        }
    }

    public class DailyWork
    {
        public string Work { get;private set; }
        public bool Processed { get; private set; }
        public DailyWork(string work)
        {
            Work = work;
        }

        public void Process()
        {
            Task.Delay(300).Wait();
            MyProgram.GetThreadInfo(Thread.CurrentThread);
            Processed = true;
        }
    }
}
