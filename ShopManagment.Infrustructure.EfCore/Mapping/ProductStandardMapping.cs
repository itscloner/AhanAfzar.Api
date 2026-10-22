using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductStandardAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class ProductStandardMapping : IEntityTypeConfiguration<ProductStandard>
    {
        public void Configure(EntityTypeBuilder<ProductStandard> builder)
        {
            builder.ToTable("ProductStandards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.Slug);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductStandard)
                .HasForeignKey(x => x.ProductStandardId);
        }
    }
}
