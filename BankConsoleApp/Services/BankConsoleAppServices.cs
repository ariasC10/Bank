using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Services;
public class BankConsoleAppServices : IBankConsoleAppServices
{
    //Agregar atributo currentaccount
    // Agregar public void GetAccount(uint id); y el que checa que no se pase con los montos con respecto al salario authorizationTransaction


    //static void Main(string[] args)
    //{
    //    int opc = int.Parse(Console.ReadLine());
    //    switch (opc)
    //    {
    //        case 1:

    //            break;
    //        case 2:

    //            break;
    //        case 3:
    //            break;
    //        case 4:
    //            break;
    //    }

    //}

    //Account account;
    //Transaction transaction;

    //private readonly IRepository<Account> _repository;

    //public BankApp(IRepository<Account> repository)
    //{
    //    _repository = repository;
    //}

    //public Account addAccount()
    //{
    //    account = new Account
    //    {
    //        AccountNumber = uint.Parse(Console.ReadLine()),
    //        Owner = Console.ReadLine(),
    //        CreationDate = new DateOnly(),
    //        AccountType = Console.ReadLine(),
    //        Balance = float.Parse(Console.ReadLine())

    //    };
    //    _repository.Insert(account);
    //    return account;
    //}


    //public Transaction doTransaction()
    //{
    //    transaction = new Transaction
    //    {
    //        AccountNumber = uint.Parse(Console.ReadLine()),
    //        TransactionNumber = new Random().Next(),
    //        Mount = int.Parse(Console.ReadLine()),
    //        CreationDate = new DateOnly(),
    //        Description = Console.ReadLine(),
    //        AccountNumberNavigation = account
    //    };
    //    _repository.Update(account, transaction.Mount);
    //    return transaction;
    //}
    //public Account GetAccount(int Id)
    //{
    //    _repository.GetById(Id);
    //    PropertyInfo[] lst = typeof(Account).GetProperties();
    //    foreach (PropertyInfo oProperty in lst)
    //    {
    //        string atr = oProperty.Name;
    //        string valor = oProperty.GetValue(account).ToString();
    //        Console.WriteLine(atr + " : " + valor);
    //    }

    //    return account;
    //}

    //public Transaction GetTransaction(int Id)
    //{
    //    PropertyInfo[] lst = typeof(Transaction).GetProperties();
    //    foreach (PropertyInfo oProperty in lst)
    //    {
    //        string atr = oProperty.Name;
    //        string valor = oProperty.GetValue(transaction).ToString();
    //        Console.WriteLine(atr + " : " + valor);
    //    }
    //    _repository.GetById(Id);
    //    return transaction;
    //}

    private Account CurrentAccount;

    private readonly IRepository<Account> _AccountRepository;

    public BankConsoleAppServices(IRepository<Account> accountRepository)
    {
        _AccountRepository = accountRepository;
    }

    public void CreateAccount(string owner, string accountType)
    {
        throw new NotImplementedException();
    }

    public void Deposit(float mount)
    {
        throw new NotImplementedException();
    }

    public void GetBalanace()
    {
        throw new NotImplementedException();
    }

    public void Withdraw(float mount)
    {
        throw new NotImplementedException();
    }
}