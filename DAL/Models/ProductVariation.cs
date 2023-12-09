using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProductVariation")]
public partial class ProductVariation
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductVariations")]
    public virtual Product Product { get; set; }
}
