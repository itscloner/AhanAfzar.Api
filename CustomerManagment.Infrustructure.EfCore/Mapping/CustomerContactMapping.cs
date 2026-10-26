using CustomerManagment.Domain.CusromerContactAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class CustomerContactMapping : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.ToTable("CustomerContact");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new
            {
                x.CustomerId,
                x.ContactId
            }).IsUnique();

            builder.Property(x => x.CustomerId);
            builder.Property(x => x.ContactId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerContacts)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Contact)
                .WithMany(x => x.CustomerContacts)
                .HasForeignKey(x => x.ContactId);
        }
    }
}
