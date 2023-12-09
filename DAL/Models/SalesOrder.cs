using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("SalesOrder")]
public partial class SalesOrder
{
    [Key]
    public int Id { get; set; }

    public int? SalesOrderStatusId { get; set; }

    [StringLength(255)]
    public string DeviceType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SubTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Tax { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DiscountPercentage { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DeliveryFees { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CreatedDate { get; set; }

    public int? CrmClientProfileId { get; set; }

    [StringLength(255)]
    public string RejectionReason { get; set; }

    [InverseProperty("SalesOrder")]
    public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();

    [ForeignKey("SalesOrderStatusId")]
    [InverseProperty("SalesOrders")]
    public virtual SalesOrderStatus SalesOrderStatus { get; set; }

    [InverseProperty("SalesOrder")]
    public virtual ICollection<SalesOrderTimeline> SalesOrderTimelines { get; set; } = new List<SalesOrderTimeline>();
}
