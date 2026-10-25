using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Domain.ProvinceAgg;
using CustomerManagment.Infrustructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore
{
    public class CustomerManagmentContext : DbContext 
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public CustomerManagmentContext(DbContextOptions<CustomerManagmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new ProvinceMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
