using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("GenStockManagementRestockOrderStatus")]
public partial class GenStockManagementRestockOrderStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Title { get; set; }
}
