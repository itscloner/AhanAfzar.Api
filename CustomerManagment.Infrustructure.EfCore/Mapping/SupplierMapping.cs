using CustomerManagment.Domain.SupplierAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.CustomerId,
                x.ProductId
            }).IsUnique();

            builder.Property(x => x.CustomerId);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.UnitPrice);
            builder.Property(x => x.RentPrice);
            builder.Property(x => x.OverPrice);
        }
    }
}
