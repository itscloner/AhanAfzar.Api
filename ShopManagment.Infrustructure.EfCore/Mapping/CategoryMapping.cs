using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.CategoryAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Picture);
            builder.Property(x => x.PictureAlt);
            builder.Property(x => x.PictureTitle);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.Slug);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);


        }
    }
}
