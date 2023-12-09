using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("SalesOrderItem")]
public partial class SalesOrderItem
{
    [Key]
    public int Id { get; set; }

    public int? SalesOrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    public int? ProductVariationId { get; set; }

    public int? ProductColorId { get; set; }

    public bool? CreatedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SalesOrderItems")]
    public virtual Product Product { get; set; }

    [ForeignKey("ProductColorId")]
    [InverseProperty("SalesOrderItems")]
    public virtual ProductColor ProductColor { get; set; }

    [ForeignKey("SalesOrderId")]
    [InverseProperty("SalesOrderItems")]
    public virtual SalesOrder SalesOrder { get; set; }
}
