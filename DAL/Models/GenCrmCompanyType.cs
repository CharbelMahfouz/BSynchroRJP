using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("GenCrmCompanyType")]
public partial class GenCrmCompanyType
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("GenCrmCompanyType")]
    public virtual ICollection<CrmCompany> CrmCompanies { get; set; } = new List<CrmCompany>();
}
