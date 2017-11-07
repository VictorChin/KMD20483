namespace Console3
{
    internal class Transaction
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
    }
    enum TransactionType
    {
         Deposit,
         Withdraw
    }
}