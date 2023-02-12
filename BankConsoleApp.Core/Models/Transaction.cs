using System;
using System.Collections.Generic;

namespace BankConsoleApp.Core.Models;

public partial class Transaction
{
    public int TransactionNumber { get; set; }

    public float Mount { get; set; }

    public DateOnly CreationDate { get; set; }

    public string Description { get; set; } = null!;

    public uint AccountNumber { get; set; }

    public virtual Account AccountNumberNavigation { get; set; } = null!;
}
