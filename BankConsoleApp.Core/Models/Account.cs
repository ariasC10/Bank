using System;
using System.Collections.Generic;

namespace BankConsoleApp.Core.Models;

public partial class Account
{
    public uint AccountNumber { get; set; }

    public string Owner { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public string AccountType { get; set; } = null!;

    public float Balance { get; set; }

    public List<Transaction> Transactions { get; set; }

    public Account() 
    {
        Transactions = new List<Transaction>();
    }
}
