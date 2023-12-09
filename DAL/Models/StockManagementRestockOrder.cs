using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("StockManagementRestockOrder")]
public partial class StockManagementRestockOrder
{
    [Key]
    public int Id { get; set; }

    public int? SupplierCompanyId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    public int? GenStockManagementRestockOrderStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("StockManagementRestockOrder")]
    public virtual ICollection<StockManagementRestockOrderItem> StockManagementRestockOrderItems { get; set; } = new List<StockManagementRestockOrderItem>();

    [ForeignKey("SupplierCompanyId")]
    [InverseProperty("StockManagementRestockOrders")]
    public virtual CrmCompany SupplierCompany { get; set; }
}
