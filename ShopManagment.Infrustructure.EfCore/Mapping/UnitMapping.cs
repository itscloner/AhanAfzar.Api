using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.UnitAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class UnitMapping : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.Keyword);
            builder.Property(x => x.Slug);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Unit)
                .HasForeignKey(x => x.UnitId);

        }
    }
}
