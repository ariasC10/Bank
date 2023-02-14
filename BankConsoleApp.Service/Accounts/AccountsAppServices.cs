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
    private readonly IRepository<Account> _AccountRepository;
    private Account? CurrentAccount;

    public AccountsAppServices(IRepository<Account> accountRepository)
    {
        _AccountRepository = accountRepository;
    }

    public async void AddAccount(string owner, string accountType)
    {
        // Generar el número de cuenta a partir de una seed -> private uint generateAccountNumber()
        // Asignar fecha actual -> DateOnly.FromDateTime(DateTime.Now)
        // Balance inicial 0

        // Crear una nueva instancia de Account con los detalles proporcionados

        var newAccount = new Account
        {
            Owner = owner,
            AccountType = accountType,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            Balance = 0
        };

        await _AccountRepository.Insert(newAccount);

        CurrentAccount = newAccount;

        var newTransaction = new Transaction
        {
            Mount = 0,
            Description = "Initial Balance",
            CreationDate = newAccount.CreationDate,
            AccountNumber = newAccount.AccountNumber,
            AccountNumberNavigation = newAccount
        };

        newAccount.Transactions.Add(newTransaction);

        await _AccountRepository.Update(newAccount);
    }


    private bool AuthorizeTransaction(float amount, Account account)
    {
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
        // si CurrentAccount es de tipo saving, no pede hacer depositos de menos de 100
        // Verificar que tiene saldo suficiente si el mount es negativo -> private bool authorizeTransaction

        // formato de las transacciones :
        //  TransactionNumber es igual a -> AccountCurrent.Transactions.Count + 1
        //  Asignar fecha actual -> DateOnly.FromDateTime(DateTime.Now)
        //  Se le asigna el numero de cuenta de CurrentAccount
        //  No agregar nada a AccountNumberNavigation

        // realizar update del modelo

        if (CurrentAccount == null)
        {
            throw new NullReferenceException("Current account has not been selected");
        }

        if (CurrentAccount.AccountType == "saving" && mount < 100 && description.ToLower() != "interest")
        {
            throw new ArgumentOutOfRangeException("Saving accounts can only make deposits of 100 or more");
        }

        if (mount < 0 && !AuthorizeTransaction(-mount, CurrentAccount))
        {
            throw new ArgumentException("Insufficient balance");
        }

        var newTransaction = new Transaction
        {
            Mount = mount,
            Description = description,
            CreationDate = DateOnly.FromDateTime(DateTime.Now),
            AccountNumber = CurrentAccount.AccountNumber
        };

        CurrentAccount.Transactions.Add(newTransaction);

        _AccountRepository.Update(CurrentAccount);


    }

    public void GetBalanace(int accountNumber)
    {
       
    }

    public void SelectAccount(uint id)
    {
       



    }
    
}