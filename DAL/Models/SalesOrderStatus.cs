using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("SalesOrderStatus")]
public partial class SalesOrderStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [InverseProperty("SalesOrderStatus")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
