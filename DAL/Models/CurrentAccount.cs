using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("CurrentAccount")]
public partial class CurrentAccount
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Balance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CurrentAccounts")]
    public virtual Customer Customer { get; set; }

    [InverseProperty("CurrentAccount")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
