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

    public void AddAccount(string owner, string accountType)
    {
        // Generar el número de cuenta a partir de una seed -> private uint generateAccountNumber()
        // Asignar fecha actual -> DateOnly.FromDateTime(DateTime.Now)
        // Balance inicial 0
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
