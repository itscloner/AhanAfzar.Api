using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.BrandAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.Slug);

            builder.HasMany(x => x.ProductBrands)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);
        }
    }
}
