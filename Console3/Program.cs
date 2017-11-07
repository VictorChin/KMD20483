using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount A = new BankAccount("Alice", 1000);
            BankAccount B = new BankAccount("Bob", 500);
            A.ReportTransaction = ApproveTransaction;
            Console.WriteLine(A);
            Console.WriteLine(B);
            A.MakeDeposit(100M, DateTime.Now, "From Grandma");
            A.MakeDeposit(200M, DateTime.Now - TimeSpan.FromDays(5), "From $$ Dad Gave to GrandMa");
            A.MakeDeposit(666M, DateTime.Now - TimeSpan.FromDays(2), "I am the devil");
            A.MakeWithdraw(1000M, DateTime.Now - TimeSpan.FromDays(3),"Thief", "I am the thief");
            Console.WriteLine(A);
            A.PrintStatement();
         }

        static bool ApproveTransaction(Transaction tran, int TransactionID)
        {
            if (tran.Type == TransactionType.Deposit && tran.Amount == 666)
            {
                Console.WriteLine($"TransactionID:{TransactionID} rejected, Devil himself!!!");
                return false;
            }
            else if (tran.Type == TransactionType.Withdraw && tran.Amount >= 1000)
            {
                Console.WriteLine($"TransactionID:{TransactionID} rejected, It wasn't me.");
                return false;
            }
            Console.WriteLine($"TransactionID:{TransactionID} Approved");
            return true;
        }
    }
}
