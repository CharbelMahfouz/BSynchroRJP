using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("Subcategory")]
public partial class Subcategory
{
    [Key]
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    [StringLength(255)]
    public string ImageHostLink { get; set; }

    public string Image { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Subcategories")]
    public virtual Category Category { get; set; }

    [InverseProperty("SubCategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
