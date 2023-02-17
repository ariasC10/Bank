using BankConsoleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Service.Accounts
{
    public interface IAccountsAppServices
    {
        public void AddAccount(string owner, string accountType);
        public void DoTransaction(float mount, string description);
        public void GetBalanace( int accountNumber);
        public bool SelectAccount(uint id);
        public void showAccounts();
        public bool respositoryEmpty();

        public void showTransactions();


    }
}
