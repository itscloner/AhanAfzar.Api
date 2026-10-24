using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.CompanyAgg;

namespace ShopManagment.Infrustructure.EfCore.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.BrandName);
            builder.Property(x => x.EconomicCode);
            builder.Property(x => x.NationalId);
            
            
            
        }
    }
}
