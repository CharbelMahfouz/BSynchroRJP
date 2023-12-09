using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("Transaction")]
public partial class Transaction
{
    [Key]
    public int Id { get; set; }

    public int? CurrentAccountId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TransactionAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OldBalance { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NewBalance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("CurrentAccountId")]
    [InverseProperty("Transactions")]
    public virtual CurrentAccount CurrentAccount { get; set; }
}
