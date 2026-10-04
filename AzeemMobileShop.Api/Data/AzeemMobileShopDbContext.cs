using AzeemMobileShop.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AzeemMobileShop.Api.Data
{
    public class AzeemMobileShopDbContext : DbContext
    {
        public AzeemMobileShopDbContext(DbContextOptions<AzeemMobileShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Decimal precision configuration
            modelBuilder.Entity<Product>()
                .Property(p => p.BaseCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
                .Property(p => p.BaseRetail).HasColumnType("decimal(18,2)");
                
            modelBuilder.Entity<ProductItem>()
                .Property(p => p.PurchaseCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ProductItem>()
                .Property(p => p.MinimumSalePrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>()
                .Property(c => c.Balance).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Sale>()
                .Property(s => s.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Sale>()
                .Property(s => s.DiscountAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Sale>()
                .Property(s => s.PaidAmount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SaleItem>()
                .Property(si => si.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<SaleItem>()
                .Property(si => si.TotalPrice).HasColumnType("decimal(18,2)");
        }
    }
}
