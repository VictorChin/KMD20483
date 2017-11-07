using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
   public class OverdrawnException : System.ApplicationException
    {
        private BankAccount _account;
        private decimal _amount;

        public OverdrawnException(BankAccount account) : base("The account is overdrawn.")
        {
            this._account = account;
        }

        public OverdrawnException(BankAccount account, decimal amount) : this(account)
        {
            this._account = account;
            this._amount = amount;
        }

        public decimal WithdrawLimit { get { return _account.Balance; } }
        public string OwnerName => _account.Owner;

        public decimal WithdrawOverage => _amount - _account.Balance;
    }
}
