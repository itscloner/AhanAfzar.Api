using CustomerManagment.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title);
            builder.Property(x => x.FullAddress);
            builder.Property(x => x.PostalCode);
            builder.Property(x => x.ProvinceId);
            builder.Property(x => x.CityId);

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.City)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
