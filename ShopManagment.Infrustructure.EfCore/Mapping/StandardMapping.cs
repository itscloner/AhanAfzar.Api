using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.StandardAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class StandardMapping : IEntityTypeConfiguration<Standard>
    {
        public void Configure(EntityTypeBuilder<Standard> builder)
        {
            builder.ToTable("Standards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.Slug);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Standard)
                .HasForeignKey(x => x.StandardId);
        }
    }
}
