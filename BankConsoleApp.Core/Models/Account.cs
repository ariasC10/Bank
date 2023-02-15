using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankConsoleApp.Core.Models;

public partial class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint AccountNumber { get; set; }

    public string Owner { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public string AccountType { get; set; } = null!;

    public float Balance { get; set; }

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}
