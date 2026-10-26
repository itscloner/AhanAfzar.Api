using CustomerManagment.Domain.CusromerAddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class CustomerAddressMapping : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddress");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new
            {
                x.CustomerId,
                x.AddressId
            }).IsUnique();

            builder.Property(x => x.CustomerId);
            builder.Property(x => x.AddressId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerAddresses)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Address)
                .WithMany(x => x.CustomerAddresses)
                .HasForeignKey(x => x.AddressId);
        }
    }
}
