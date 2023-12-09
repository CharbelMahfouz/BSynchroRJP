using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("CrmClientProfile")]
public partial class CrmClientProfile
{
    [Key]
    public int Id { get; set; }

    public int? ProfPersonId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? TotalOrdersCount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalPaid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastOrderDate { get; set; }

    [ForeignKey("ProfPersonId")]
    [InverseProperty("CrmClientProfiles")]
    public virtual ProfPerson ProfPerson { get; set; }
}
