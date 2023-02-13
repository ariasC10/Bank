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
}

    public async Task DoTransaction(float mount, string description)
    {
    // si CurrentAccount es de tipo saving, no pede hacer depositos de menos de 100
    // Verificar que tiene saldo suficiente si el mount es negativo -> private bool authorizeTransaction

    // formato de las transacciones :
    //  TransactionNumber es igual a -> AccountCurrent.Transactions.Count + 1
    //  Asignar fecha actual -> DateOnly.FromDateTime(DateTime.Now)
    //  Se le asigna el numero de cuenta de CurrentAccount
    //  No agregar nada a AccountNumberNavigation

    // realizar update del modelo

    var currentAccount = await _accountRepository.GetById(AccountNumber);
    if (currentAccount is SavingAccount && amount < 100)
    {
        throw new ArgumentException("Saving accounts can't deposit less than 100");
    }

    if (!AuthorizeTransaction(currentAccount, amount))
    {
        throw new ArgumentException("Not enough funds");
    }

    var transaction = new Transaction
    {
        TransactionNumber = currentAccount.Transactions.Count + 1,
        Date = DateOnly.FromDateTime(DateTime.Now),
        Amount = amount,
        Description = description,
        AccountNumber = AccountNumber
    };

    currentAccount.Balance += amount;
    currentAccount.Transactions.Add(transaction);
    await _accountRepository.Update(currentAccount);

}

private bool AuthorizeTransaction(Account account, float amount)
{
    if (account.Balance + amount < 0)
    {
        return false;
    }
    return true;
}









public void GetBalanace()
    {
        // Imprimir la suma de los montos de todas las transacciones de la cuenta
        throw new NotImplementedException();
    }

    public void SelectAccount(uint id)
    {
        // Inicializar CurrentAccount
        throw new NotImplementedException();
    }
}
