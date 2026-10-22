using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Picture);
            builder.Property(x => x.PictureAlt);
            builder.Property(x => x.PictureTitle);
            builder.Property(x => x.Size);
            builder.Property(x => x.Weight);
            builder.Property(x => x.ProductCategoryId);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCategoryId);

            builder.HasOne(x => x.ProductStandard)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductStandardId);

            builder.HasOne(x => x.ProductUnit)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductUnitId);
        }
    }
}
