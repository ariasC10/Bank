namespace BankConsoleApp.Core.Accounts
{
    public partial class Transaction
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public double Mount { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
