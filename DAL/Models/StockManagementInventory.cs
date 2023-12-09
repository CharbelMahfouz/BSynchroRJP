using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("StockManagementInventory")]
public partial class StockManagementInventory
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityAvailable { get; set; }

    public int? MinimumStockLevel { get; set; }

    public int? MaximumStockLevel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastRestockDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? WholesalePrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RetailPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("StockManagementInventories")]
    public virtual Product Product { get; set; }
}
