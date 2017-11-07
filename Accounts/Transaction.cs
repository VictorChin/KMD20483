namespace Accounts
{
    public class Transaction
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
    }
    public enum TransactionType
    {
         Deposit,
         Withdraw
    }
}