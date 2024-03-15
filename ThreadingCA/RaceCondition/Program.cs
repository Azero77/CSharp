using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Anas", 50);
            Thread T1 = new Thread(() => wallet.Debit(40));
            Thread T2 = new Thread(() => wallet.Debit(20));
            T1.Start();
            T2.Start();
            T1.Join();
            T2.Join();
            Console.WriteLine(wallet);
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
                    Thread.Sleep(1000);
                    Bitcoins -= amount;
                }
            }

        }

        public void Credit(int amount)
        {
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId} , Name: {Thread.CurrentThread.Name}" +
                    $", Processor Id: {Thread.GetCurrentProcessorId()}] +{amount}");

            Thread.Sleep(1000);
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
}