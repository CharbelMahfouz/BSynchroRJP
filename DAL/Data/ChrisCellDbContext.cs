using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public partial class ChrisCellDbContext : DbContext
{
    public ChrisCellDbContext()
    {
    }

    public ChrisCellDbContext(DbContextOptions<ChrisCellDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccResetPasswordDetail> AccResetPasswordDetails { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CrmClientProfile> CrmClientProfiles { get; set; }

    public virtual DbSet<CrmCompany> CrmCompanies { get; set; }

    public virtual DbSet<GenCountry> GenCountries { get; set; }

    public virtual DbSet<GenCrmCompanyType> GenCrmCompanyTypes { get; set; }

    public virtual DbSet<GenStockManagementRestockOrderStatus> GenStockManagementRestockOrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductSoldHistory> ProductSoldHistories { get; set; }

    public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

    public virtual DbSet<ProductTempImage> ProductTempImages { get; set; }

    public virtual DbSet<ProductVariation> ProductVariations { get; set; }

    public virtual DbSet<ProfPerson> ProfPeople { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }

    public virtual DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }

    public virtual DbSet<SalesOrderTimeline> SalesOrderTimelines { get; set; }

    public virtual DbSet<StockManagementInventory> StockManagementInventories { get; set; }

    public virtual DbSet<StockManagementRestockOrder> StockManagementRestockOrders { get; set; }

    public virtual DbSet<StockManagementRestockOrderItem> StockManagementRestockOrderItems { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<CrmClientProfile>(entity =>
        {
            entity.HasOne(d => d.ProfPerson).WithMany(p => p.CrmClientProfiles).HasConstraintName("FK_CrmClientProfile_ProfPerson");
        });

        modelBuilder.Entity<CrmCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Company");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.CrmCompanies).HasConstraintName("FK_Company_Company");

            entity.HasOne(d => d.GenCrmCompanyType).WithMany(p => p.CrmCompanies).HasConstraintName("FK_CrmCompany_GenCrmCompanyType");
        });

        modelBuilder.Entity<GenCrmCompanyType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<GenStockManagementRestockOrderStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Products).HasConstraintName("FK_Product_Subcategory");
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors).HasConstraintName("FK_ProductColor_Product");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductSoldHistory>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductSoldHistories).HasConstraintName("FK_ProductSoldHistory_Product");
        });

        modelBuilder.Entity<ProductStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProductVariation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariations).HasConstraintName("FK_ProductVariation_Product");
        });

        modelBuilder.Entity<ProfPerson>(entity =>
        {
            entity.HasOne(d => d.GenCountry).WithMany(p => p.ProfPeople).HasConstraintName("FK_ProfPerson_GenCountry");

            entity.HasOne(d => d.User).WithMany(p => p.ProfPeople).HasConstraintName("FK_ProfPerson_AspNetUsers");
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasOne(d => d.SalesOrderStatus).WithMany(p => p.SalesOrders).HasConstraintName("FK_SalesOrder_SalesOrderStatus");
        });

        modelBuilder.Entity<SalesOrderItem>(entity =>
        {
            entity.HasOne(d => d.ProductColor).WithMany(p => p.SalesOrderItems).HasConstraintName("FK_SalesOrderItem_ProductColor");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderItems).HasConstraintName("FK_SalesOrderItem_Product");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderItems).HasConstraintName("FK_SalesOrderItem_SalesOrder");
        });

        modelBuilder.Entity<SalesOrderStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SalesOrderTimeline>(entity =>
        {
            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderTimelines).HasConstraintName("FK_SalesOrderTimeline_SalesOrder");
        });

        modelBuilder.Entity<StockManagementInventory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.StockManagementInventories).HasConstraintName("FK_StockManagementInventory_Product");
        });

        modelBuilder.Entity<StockManagementRestockOrder>(entity =>
        {
            entity.HasOne(d => d.SupplierCompany).WithMany(p => p.StockManagementRestockOrders).HasConstraintName("FK_StockManagementRestockOrder_CrmCompany");
        });

        modelBuilder.Entity<StockManagementRestockOrderItem>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.StockManagementRestockOrderItems).HasConstraintName("FK_StockManagementRestockOrderItems_Product");

            entity.HasOne(d => d.StockManagementRestockOrder).WithMany(p => p.StockManagementRestockOrderItems).HasConstraintName("FK_StockManagementRestockOrderItems_StockManagementRestockOrder");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Subcategories).HasConstraintName("FK_Subcategory_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
