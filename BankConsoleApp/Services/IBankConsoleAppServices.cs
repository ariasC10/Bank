using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Services
{
    public interface IBankConsoleAppServices
    {
        public void CreateAccount(string owner, string accountType);
        public void Deposit(float mount);
        public void Withdraw(float mount);
        public void GetBalanace();

    }
}
