using CustomerManagment.Domain.CusromerCompanyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagment.Infrustructure.EfCore.Mapping
{
    public class CustomerCompanyMapping : IEntityTypeConfiguration<CustomerCompany>
    {
        public void Configure(EntityTypeBuilder<CustomerCompany> builder)
        {
            builder.ToTable("CustomerCompany");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new
            {
                x.CustomerId,
                x.CompanyId
            }).IsUnique();

            builder.Property(x => x.CustomerId);
            builder.Property(x => x.CompanyId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerCompanies)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.CustomerCompanies)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
