using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    public int? SubCategoryId { get; set; }

    public int? CategoryId { get; set; }

    [StringLength(255)]
    public string ModelNumber { get; set; }

    [StringLength(255)]
    public string ProductSku { get; set; }

    [StringLength(255)]
    public string Title { get; set; }

    [StringLength(255)]
    public string RedeemableCodeValue { get; set; }

    [StringLength(255)]
    public string ShortDescription { get; set; }

    public string Description { get; set; }

    [StringLength(255)]
    public string ImageHostLink { get; set; }

    public string Image { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DiscountPercentage { get; set; }

    public bool? IsOffer { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OfferDateFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OfferDateTo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? WholeSalePrice { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? NewPrice { get; set; }

    public int? AmountInStock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductSoldHistory> ProductSoldHistories { get; set; } = new List<ProductSoldHistory>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductVariation> ProductVariations { get; set; } = new List<ProductVariation>();

    [InverseProperty("Product")]
    public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<StockManagementInventory> StockManagementInventories { get; set; } = new List<StockManagementInventory>();

    [InverseProperty("Product")]
    public virtual ICollection<StockManagementRestockOrderItem> StockManagementRestockOrderItems { get; set; } = new List<StockManagementRestockOrderItem>();

    [ForeignKey("SubCategoryId")]
    [InverseProperty("Products")]
    public virtual Subcategory SubCategory { get; set; }
}
