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
            builder.Property(x => x.ProvinceId);
            builder.Property(x => x.CityId);

        }
    }
}
