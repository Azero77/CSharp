using LongRunningVsShortRunningTasks;
using System;

namespace AsyncAwait
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            /* var task = Task.Run(() => ReadContentAsync("https://www.youtube.com/watch?v=kDUDX3VJFEc&list=PL4n1Qos4Tb6SWPbJNpiznp-Ok4A8J_23l&index=39"));
             task.GetAwaiter().OnCompleted(() => Console.WriteLine(task.GetAwaiter().GetResult()));*/
            MyProgram.GetThreadInfo(Thread.CurrentThread, 17);
            var client = new HttpClient();
            var content = await returnString("https://www.youtube.com/watch?v=kDUDX3VJFEc&list=PL4n1Qos4Tb6SWPbJNpiznp-Ok4A8J_23l&index=39");
            MyProgram.GetThreadInfo(Thread.CurrentThread, 27);
           
            Console.WriteLine(content.Substring(1, 15) );
        }

        async static Task<string> ReadContentAsync(string url)
        {
            MyProgram.GetThreadInfo(Thread.CurrentThread , 17);
            var client = new HttpClient();
            var content = await returnString(url);
            await Task.Delay(3000).ContinueWith((Task t) => MyProgram.GetThreadInfo(Thread.CurrentThread));
            MyProgram.GetThreadInfo(Thread.CurrentThread, 27);
            return content.Substring(1,15);
        }


        async static Task<string> returnString(string url)
        {
            var client = new HttpClient();
            var k = client.GetStringAsync(url);
            var content = await k;
            MyProgram.GetThreadInfo(Thread.CurrentThread, 33);
            return content;
        }
        static void DoSomething()
        {
            MyProgram.GetThreadInfo(Thread.CurrentThread , 33);
            Console.WriteLine("Working..."); 
        }

        static async Task ShowThreads()
        {
            MyProgram.GetThreadInfo(Thread.CurrentThread);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10);
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10).ContinueWith((Task t)=> MyProgram.GetThreadInfo(Thread.CurrentThread));
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
            await Task.Delay(10); 
            await Task.Run(() => MyProgram.GetThreadInfo(Thread.CurrentThread) );
        }
    }


}
