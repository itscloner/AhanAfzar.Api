using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductBrandAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductStandardAgg;
using ShopManagment.Domain.ProductUnitAgg;
using ShopManagment.Infrustructure.EfCore.Mapping;

namespace ShopManagment.Infrustructure.EfCore
{
    public class ShopManagmentContext : DbContext 
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductStandard> ProductStandards { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public ShopManagmentContext(DbContextOptions<ShopManagmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductStandardMapping());
            modelBuilder.ApplyConfiguration(new ProductUnitMapping());
            modelBuilder.ApplyConfiguration(new ProductBrandMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
