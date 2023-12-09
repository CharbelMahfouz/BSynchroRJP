using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string UserId { get; set; }

    [Required]
    [StringLength(255)]
    public string FirstName { get; set; }

    [StringLength(255)]
    public string LastName { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Balance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();

    [ForeignKey("UserId")]
    [InverseProperty("Customers")]
    public virtual AspNetUser User { get; set; }
}
