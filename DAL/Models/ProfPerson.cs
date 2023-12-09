using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("ProfPerson")]
public partial class ProfPerson
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(511)]
    public string FirstName { get; set; }

    [StringLength(511)]
    public string LastName { get; set; }

    [StringLength(511)]
    public string CountryCode { get; set; }

    [StringLength(511)]
    public string PhoneNumber { get; set; }

    public int? GenCountryId { get; set; }

    [StringLength(511)]
    public string Email { get; set; }

    [InverseProperty("ProfPerson")]
    public virtual ICollection<CrmClientProfile> CrmClientProfiles { get; set; } = new List<CrmClientProfile>();

    [ForeignKey("GenCountryId")]
    [InverseProperty("ProfPeople")]
    public virtual GenCountry GenCountry { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ProfPeople")]
    public virtual AspNetUser User { get; set; }
}
