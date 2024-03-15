namespace Test
{
    internal class Program
    {

        public static readonly object o = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread T = new Thread(() => 
                {
                    lock (o)
                    {
                        File.AppendAllText(@"C:\Users\mazag\OneDrive\Desktop\test1.txt", "YT1 ");
                        Thread.Sleep(1000);
                        File.AppendAllText(@"C:\Users\mazag\OneDrive\Desktop\test1.txt", "YT2 ");
                    }

                });
                T.Start();
            }
        }
    }
}
