using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPart2
{
    public class BankAccount
    {
        private int account_No;
        private decimal balance;
        private string holder;

        public BankAccount(int account_No, decimal balance, string holder)
        {
            this.account_No = account_No;
            this.balance = balance;
            this.holder = holder;
        }

        public int AccountNO { get { return account_No; } }
        public decimal Balance { get { return balance; } }
        public string Holder { get { return holder; } }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }
        public event EventHandler NegativeValue;
        public void WithDraw(decimal amount)
        {
            balance -= amount;
            if (balance < 0) NegativeValue?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"{{Id : {AccountNO} , Balance : {Balance} , Holder : {Holder} }}";
        }
    }
}
