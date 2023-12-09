using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProductSoldHistory")]
public partial class ProductSoldHistory
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? AmountSold { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PercentageOfSales { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalSales { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateSold { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductSoldHistories")]
    public virtual Product Product { get; set; }
}
