using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Repository;
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
    private Account? CurrentAccount;

    public AccountsAppServices(IRepository<Account> accountRepository)
    {
        _repository = accountRepository;
    }

    public async void AddAccount(string owner, string accountType)
    {
        var random = new Random(19390);
        int number = random.Next(Int32.MinValue, Int32.MaxValue);
        uint accountNumber = (uint)(number + (uint)Int32.MaxValue);

        var newAccount = new Account
        {
            AccountNumber= accountNumber,
            Owner = owner,
            AccountType = accountType,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            Balance = 0
        };

        await _repository.Insert(newAccount);

        CurrentAccount = newAccount;
        Console.Write($"\nAccount number selected: {newAccount.AccountNumber}");
        Console.WriteLine("\nThe account was created succesfully!\n");
    }

    public async void DoTransaction(float mount, string description)
    {
        if (CurrentAccount == null)
        {
            throw new NullReferenceException("Current account has not been selected");
        }

        if (CurrentAccount.AccountType == "saving" && mount < 100 && description.ToLower() != "interest")
        {
            throw new ArgumentOutOfRangeException("Saving accounts can only make deposits of 100 or more");
        }
        
        if (CurrentAccount.Balance + mount < 0)
        {
            throw new ArgumentOutOfRangeException("Insufficient balance");
        }
        
        CurrentAccount.Balance = CurrentAccount.Balance + mount;
        
        var newTransaction = new Transaction
        {
            Mount = mount,
            Description = description,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            AccountNumber = CurrentAccount.AccountNumber,
            AccountNumberNavigation = CurrentAccount,
        };

        CurrentAccount.Transactions.Add(newTransaction);

        await _repository.Update(CurrentAccount);

        Console.WriteLine("\nThe transaction was successfully!\n");
    }

    public void GetBalanace()
    {
        if (CurrentAccount == null)
        {
            throw new NullReferenceException("Current account has not been selected");
        }

        float balance = 0f;
        foreach (var transaction in CurrentAccount.Transactions)
        {
            balance += transaction.Mount;
        }

        Console.WriteLine($"\nAccount balance: {balance}\n");
    }

    public bool SelectAccount(uint id)
    {
        var account = _repository.GetById(id);

        if (account == null)
        {
            throw new NullReferenceException("Account not found.");
        }

        CurrentAccount = account;
        Console.WriteLine($"\nWelcome {CurrentAccount.Owner}!\n");

        return true;
    }
}
