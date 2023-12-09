using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class StockManagementRestockOrderItem
{
    [Key]
    public int Id { get; set; }

    public int? StockManagementRestockOrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Tax { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("StockManagementRestockOrderItems")]
    public virtual Product Product { get; set; }

    [ForeignKey("StockManagementRestockOrderId")]
    [InverseProperty("StockManagementRestockOrderItems")]
    public virtual StockManagementRestockOrder StockManagementRestockOrder { get; set; }
}
