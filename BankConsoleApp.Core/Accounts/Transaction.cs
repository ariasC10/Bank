using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
