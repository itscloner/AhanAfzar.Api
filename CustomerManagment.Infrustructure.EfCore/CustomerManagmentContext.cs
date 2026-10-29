using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Domain.ContactAgg;
using CustomerManagment.Domain.CusromerAddressAgg;
using CustomerManagment.Domain.CusromerCompanyAgg;
using CustomerManagment.Domain.CusromerContactAgg;
using CustomerManagment.Domain.CustomerAgg;
using CustomerManagment.Domain.ProvinceAgg;
using CustomerManagment.Domain.SupplierAgg;
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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerCompany> CustomerCompany { get; set; }
        public DbSet<CustomerContact> CustomerContact { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public CustomerManagmentContext(DbContextOptions<CustomerManagmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new ProvinceMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new ContactMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new CustomerAddressMapping());
            modelBuilder.ApplyConfiguration(new CustomerCompanyMapping());
            modelBuilder.ApplyConfiguration(new CustomerCompanyMapping());
            modelBuilder.ApplyConfiguration(new SupplierMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
