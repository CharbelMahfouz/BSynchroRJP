using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("SalesOrderTimeline")]
public partial class SalesOrderTimeline
{
    [Key]
    public int Id { get; set; }

    public int? SalesOrderId { get; set; }

    [StringLength(511)]
    public string Title { get; set; }

    public string Description { get; set; }

    [ForeignKey("SalesOrderId")]
    [InverseProperty("SalesOrderTimelines")]
    public virtual SalesOrder SalesOrder { get; set; }
}
