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
            Console.WriteLine(A);
            Console.WriteLine(B);
            A.MakeDeposit(100M, DateTime.Now, "From Grandma");
            A.MakeDeposit(200M, DateTime.Now - TimeSpan.FromDays(5), "From $$ Dad Gave to GrandMa");
            Console.WriteLine(A);
            A.PrintStatement();


        }
    }
}
