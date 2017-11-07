using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string name, decimal initialDeposit) : base(name, initialDeposit)
        {
        }
    }
}
