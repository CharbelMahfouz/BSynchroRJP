using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProductStatus")]
public partial class ProductStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [StringLength(255)]
    public string Description { get; set; }
}
