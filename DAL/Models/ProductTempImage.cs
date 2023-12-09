using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProductTempImage")]
public partial class ProductTempImage
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string ImageHostLink { get; set; }

    public string Image { get; set; }
}
