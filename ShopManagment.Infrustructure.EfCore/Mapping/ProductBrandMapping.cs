using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductBrandAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class ProductBrandMapping : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("ProductBrands");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new
            {
                x.ProductId,
                x.BrandId
            }).IsUnique();
            
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductBrands)
                .HasForeignKey(pb => pb.ProductId);

            builder.HasOne(pb => pb.Brand)
                .WithMany(b => b.ProductBrands)
                .HasForeignKey(pb => pb.BrandId);

        }
    }
}
