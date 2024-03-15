using System.Formats.Tar;

namespace DeadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var w1 = new Wallet("anas", 100);
            var w2 = new Wallet("azero", 50);

            var t1 = new TransferManager(w1, w2, 50);
            var t2 = new TransferManager(w2, w1, 30);

            Thread T1 = new Thread(t1.Transfer)
            {
                Name = "T1"
            };
            Thread T2 = new Thread(t2.Transfer)
            {
                Name = "T2"
            };

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();
            Console.WriteLine(w1);
            Console.WriteLine(w2);
            Console.Read();
        }
    }

    class Wallet
    {

        public static void Hello()
        {
            Console.WriteLine("Hello");
        }
        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Debit(int amount)
        {
            lock (this) //anyobject is acceptable
            {
                Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId} , Name: {Thread.CurrentThread.Name}" +
                    $", Processor Id: {Thread.GetCurrentProcessorId()}] -{amount}");
                if (Bitcoins >= amount)
                {
                    Bitcoins -= amount;
                }
            }

        }

        public void Credit(int amount)
        {
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId} , Name: {Thread.CurrentThread.Name}" +
                    $", Processor Id: {Thread.GetCurrentProcessorId()}] +{amount}");

            Bitcoins += amount;
        }

        public void RunRandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);
                if (amount < 0)
                    Debit(absValue);
                else
                    Credit(absValue);

            }
        }

        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }
    class TransferManager
    {
        private static object obj = new object();
        private Wallet From;
        private Wallet To;
        private int AmountToTransfer;

        public TransferManager(Wallet from, Wallet to, int amountToTransfer)
        {
            From = from;
            To = to;
            AmountToTransfer = amountToTransfer;
        }

        public void Transfer() 
        {
            Console.WriteLine($"Trying to Lock {From}...");
            lock (From)
            {
                Console.WriteLine($"Locking {From} is aquired");
                //transfer money from From to To
                Console.WriteLine($"Trying to Lock {To}");
                lock (To)
                {

                    Console.WriteLine($"Locking {To} is aquired");
                    Thread.Sleep(1000);
                    From.Debit(AmountToTransfer);
                    To.Credit(AmountToTransfer);
                }

            }
        }
    }

}
