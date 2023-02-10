using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Domain.Repository
{
    public interface IRepository
    {
        void AddAccount(int id, char type, string owner);
        void Deposit(int id, double mount);
        void Withdraw(int id, double mount);
        double GetBalance(int id);
        bool IsAvailable(int id);
    }
}
