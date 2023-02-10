namespace BankConsoleApp.Core.Accounts
{
    public partial class Account
    {
        int Id { get; set; }
        public string Owner { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}
