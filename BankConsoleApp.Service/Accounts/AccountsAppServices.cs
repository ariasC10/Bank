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

    public async void AddAccount(string owner, string accountType)
    {
        var newAccount = new Account
        {
            Owner = owner,
            AccountType = accountType,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            Balance = 0
        };

        await _repository.Insert(newAccount);

        CurrentAccount = newAccount;
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
        

        var newTransaction = new Transaction
        {
            Mount = mount,
            Description = description,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            AccountNumber = CurrentAccount.AccountNumber,
            AccountNumberNavigation = CurrentAccount,
        };



        CurrentAccount.Transactions.Add(newTransaction);
        if(mount < 0)
        {
            CurrentAccount.Balance = CurrentAccount.Balance - mount;
        }
        else
        {
            CurrentAccount.Balance = CurrentAccount.Balance+ mount;
        }


        _repository.Update(CurrentAccount);

        Console.WriteLine("The transaction was successfully ☺☺☺");

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

    public bool SelectAccount(uint id)
    {
        var account = _repository.GetById(id);

        if (account == null)
        {
            return false;
            throw new NullReferenceException("Account not found.");
        }

        CurrentAccount = account;
        return true;
    }

    public void showAccounts()
    {
        _repository.showAccounts();
        
    }

    public bool respositoryEmpty()
    {
        int length = _repository.numberOfAccounts();
        if(length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void showTransactions()
    {
        Console.WriteLine("Transaction number      " + "Type          " + "Mount               "  + "Description       " + "Date");

        foreach (var transaction in CurrentAccount.Transactions)
        {
            Console.WriteLine(transaction.TransactionNumber + " " + GetTypeTransaction(transaction) + "  " + transaction.Mount + "  " + transaction.Description
                + "  " + transaction.CreationDate); ;
        }

    }

    private string GetTypeTransaction(Transaction trans)
    {
        if(trans.Mount < 0)
        {
            return "Withdrawal";
        }
        else
        {
            return "Deposit";
        }
        
    }


}
