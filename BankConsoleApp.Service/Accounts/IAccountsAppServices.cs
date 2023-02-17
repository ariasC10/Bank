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
        void AddAccount(string owner, string accountType);
        void DoTransaction(float mount, string description);
        void GetBalanace();
        bool SelectAccount(uint id);
    }
}
