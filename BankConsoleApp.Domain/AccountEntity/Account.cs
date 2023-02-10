using BankConsoleApp.Domain.TransactionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Domain.AccountEntity
{
    public class Account
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
