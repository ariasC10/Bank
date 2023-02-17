using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace BankConsoleApp.Service.Accounts;
public class AccountsAppServices : IAccountsAppServices
{
    private readonly IRepository<Account> _repository;
    private Account CurrentAccount;

    public AccountsAppServices(IRepository<Account> accountRepository)
    {
        _repository = accountRepository;
    }

    public AccountsAppServices()
    {
    }

 
    public async void AddAccount(string owner, string accountType)
    {
        // Instantiate random number generator using system-supplied value as seed.
        var random = new Random(1939);
        int number = random.Next(Int32.MinValue, Int32.MaxValue);
        uint uintAccount = (uint)(number + (uint)Int32.MaxValue);

        var newAccount = new Account
        {
            AccountNumber = uintAccount,
            Owner = owner,
            AccountType = accountType,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            Balance = 0
        };

        await _repository.Insert(newAccount);

        CurrentAccount = newAccount;
    }

    public bool AuthorizeTransaction(float amount)
    {

        Account account = CurrentAccount;
        if (amount >= 0)
        {
            return account.Balance >= amount;
        }
        else
        {
            return account.AccountType == "credit" && Math.Abs(amount) <= account.Balance;
        }
    }


    public void DoTransaction(float mount, string description)
    {
        if (CurrentAccount == null)
        {
            throw new NullReferenceException("Current account has not been selected");
        }

        if (CurrentAccount.AccountType == "saving" && mount < 100 && description.ToLower() != "interest")
        {
            throw new ArgumentOutOfRangeException("Saving accounts can only make deposits of 100 or more");
        }
        
        if (mount < 0 && !AuthorizeTransaction(CurrentAccount.Balance))
        {
            throw new ArgumentException("Insufficient balance");
        }

        var newTransaction = new Transaction
        {
            Mount = mount,
            Description = description,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            AccountNumber = CurrentAccount.AccountNumber,
            AccountNumberNavigation = CurrentAccount,
        };

        CurrentAccount.Transactions.Add(newTransaction);

        _repository.Update(CurrentAccount);
    }

    public void GetBalanace(int accountNumber)
    {
        var account = _repository.GetById((uint)accountNumber);

        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        CurrentAccount = account;

        float balance = 0f;
        foreach (var transaction in CurrentAccount.Transactions)
        {
            balance += transaction.Mount;
        }

        Console.WriteLine($"Account balance: {balance}");
    }

    public void SelectAccount(uint id)
    {
        var account = _repository.GetById(id);

        if (account == null)
        {
            throw new NullReferenceException("Account not found.");
        }

        CurrentAccount = account;
    }
}
