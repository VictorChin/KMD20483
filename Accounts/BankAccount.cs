using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class BankAccount 
    {
        public string Number { get; }
        public string Owner { get; set; }
        private decimal startingBalance;
        public decimal Balance { get
            { decimal currentBalance = startingBalance;
                foreach (var tran in Transactions)
                {
                    if (tran.Value.Type == TransactionType.Deposit)
                    { currentBalance += tran.Value.Amount; }
                    else
                    { currentBalance -= tran.Value.Amount; }
                }
                return currentBalance;
            }
         }
        private static int account = 1000000;
        SortedDictionary<DateTime,Transaction> Transactions = 
            new SortedDictionary<DateTime,Transaction>();
        public BankAccount(string name, decimal initialDeposit)
        {
            Owner = name;
            startingBalance = initialDeposit;
            Number = BankAccount.account++.ToString();
        }

        public void PrintStatement()
        {
            foreach (var item in Transactions)
            {
                Console.WriteLine($"{item.Key.ToString("dd MM yyyy HH:M")} -- " +
                    $"{item.Value.Type} " +
                    $"{item.Value.Note} " +
                    $"{item.Value.Amount.ToString("C")}" );
            }
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

            var tran = new Transaction { Amount = amount, Note = note, Type = TransactionType.Deposit };
            Transactions.Add(date, tran);
            Notify(date, tran);
        }
        public void MakeWithdraw(decimal amount, DateTime date, string payee, string note) {
            if (amount > this.Balance)
            {
                throw new OverdrawnException(this,amount);
            }
            var tran = new Transaction { Amount = amount, Note = note, Type = TransactionType.Withdraw };
            Transactions.Add(date, tran);
            Notify(date, tran);

        }
        public override string ToString()
        {
            return $"Account Number:{Number}, Owner: {Owner},Balance{Balance}";
        }

        public Func<Transaction, int, bool> ReportTransaction;
        //public Action<Transaction, int> ReportTransaction;
        private void Notify(DateTime date, Transaction tran)
        {
            if (ReportTransaction != null)
            {
                if (ReportTransaction(tran, Transactions.Count))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Customer Confirmed");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer Rejected");
                    Transactions.Remove(date);
                    Console.ResetColor();
                }
            }
        }

    }
}
