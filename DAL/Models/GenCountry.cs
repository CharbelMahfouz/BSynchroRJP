using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("GenCountry")]
public partial class GenCountry
{
    [Key]
    public int Id { get; set; }

    [StringLength(511)]
    public string Title { get; set; }

    public int? UtcOffset { get; set; }

    [StringLength(20)]
    public string CountryCode { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("GenCountry")]
    public virtual ICollection<ProfPerson> ProfPeople { get; set; } = new List<ProfPerson>();
}
