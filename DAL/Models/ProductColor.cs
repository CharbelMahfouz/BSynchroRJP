using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProductColor")]
public partial class ProductColor
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductColors")]
    public virtual Product Product { get; set; }

    [InverseProperty("ProductColor")]
    public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
}
