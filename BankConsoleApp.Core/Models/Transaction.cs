using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankConsoleApp.Core.Models;

public partial class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TransactionNumber { get; set; }

    public float Mount { get; set; }

    public DateOnly CreationDate { get; set; }

    public string Description { get; set; } = null!;

    public uint AccountNumber { get; set; }

    [ForeignKey(nameof(AccountNumber))]
    public Account AccountNumberNavigation { get; set; }
}
