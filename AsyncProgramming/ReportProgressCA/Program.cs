namespace ReportProgressCA
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //we can show the progress of a task
            Action<int> Progress = (p) => { Console.Clear(); Console.WriteLine(p+"%"); };
            await Copy(Progress);
            Console.WriteLine("Finished");
        }


        async static Task Copy(Action<int> ShowProgress)
        {
            //some logic
            await Task.Run(async() => 
            {
                for (int i = 0; i <= 100; i++)
                {
                    await Task.Delay(30);
                    if (i % 10 == 0) ShowProgress(i);
                }
            });
        }
    }
}
