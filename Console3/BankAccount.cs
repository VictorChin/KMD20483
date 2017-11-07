using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3
{
    class BankAccount 
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; private set; }
        private static int account = 1000000;
        SortedDictionary<DateTime,Transaction> Transactions = 
            new SortedDictionary<DateTime,Transaction>();
        public BankAccount(string name, decimal initialDeposit)
        {
            Owner = name;
            Balance = initialDeposit;
            Number = BankAccount.account++.ToString();
        }

        internal void PrintStatement()
        {
            foreach (var item in Transactions)
            {
                Console.WriteLine($"{item.Key.ToString("dd MM yyyy HH:M")} -- " +
                    $"{item.Value.Type} " +
                    $"{item.Value.Note} " +
                    $"{item.Value.Amount.ToString("C")}" );
            }
        }

        public void MakeDeposit(decimal amount, DateTime date, string note) {
            this.Balance += amount;
            var tran = new Transaction { Amount = amount, Note = note, Type = TransactionType.Deposit };
            Transactions.Add(date,tran);
            if (ReportTransaction != null)
            {
                if (ReportTransaction(tran, Transactions.Count))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Customer Confirmed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer Rejected");
                    this.Balance -= amount;
                    Transactions.Remove(date);
                }
            }

        }
        public void MakeWithdraw(decimal amount, DateTime date, string payee, string note) {
            this.Balance -= amount;
            var tran = new Transaction { Amount = amount, Note = note, Type = TransactionType.Withdraw };
            Transactions.Add(date, tran);
            if (ReportTransaction != null)
            {
                if (ReportTransaction(tran, Transactions.Count))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Customer Confirmed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer Rejected");
                    this.Balance += amount;
                    Transactions.Remove(date);
                }
            }
        }
        public override string ToString()
        {
            return $"Account Number:{Number}, Owner: {Owner},Balance{Balance}";
        }

        public Func<Transaction, int, bool> ReportTransaction;
        //public Action<Transaction, int> ReportTransaction;

    }
}
