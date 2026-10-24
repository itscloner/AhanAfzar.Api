using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.BrandAgg;
using ShopManagment.Domain.CategoryAgg;
using ShopManagment.Domain.StandardAgg;
using ShopManagment.Domain.UnitAgg;
using ShopManagment.Infrustructure.EfCore.Mapping;
using ShopManagment.Domain.ProductBrandAgg;
using ShopManagment.Domain.CompanyAgg;

namespace ShopManagment.Infrustructure.EfCore
{
    public class ShopManagmentContext : DbContext 
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Company> Companies { get; set; }
        public ShopManagmentContext(DbContextOptions<ShopManagmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new StandardMapping());
            modelBuilder.ApplyConfiguration(new UnitMapping());
            modelBuilder.ApplyConfiguration(new BrandMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductBrandMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
