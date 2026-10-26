using CustomerManagment.Domain.CustomerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.NationalCode);
            builder.Property(x => x.CustomerType);

            builder.HasMany(x => x.CustomerCompanies)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.CustomerContacts)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.ContactId);

            builder.HasMany(x => x.CustomerAddresses)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.AddressId);

        }
    }
}
