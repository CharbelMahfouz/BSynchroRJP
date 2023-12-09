using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("CrmCompany")]
public partial class CrmCompany
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; }

    [Column("GenCrmCompanyTypeID")]
    public int? GenCrmCompanyTypeId { get; set; }

    [StringLength(50)]
    public string Phone { get; set; }

    [StringLength(50)]
    public string Mobile { get; set; }

    [StringLength(500)]
    public string Website { get; set; }

    [StringLength(500)]
    public string LinkedIn { get; set; }

    [StringLength(500)]
    public string Instagram { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CreatedByUserID")]
    [StringLength(450)]
    public string CreatedByUserId { get; set; }

    public bool? IsDeleted { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("CrmCompanies")]
    public virtual AspNetUser CreatedByUser { get; set; }

    [ForeignKey("GenCrmCompanyTypeId")]
    [InverseProperty("CrmCompanies")]
    public virtual GenCrmCompanyType GenCrmCompanyType { get; set; }

    [InverseProperty("SupplierCompany")]
    public virtual ICollection<StockManagementRestockOrder> StockManagementRestockOrders { get; set; } = new List<StockManagementRestockOrder>();
}
