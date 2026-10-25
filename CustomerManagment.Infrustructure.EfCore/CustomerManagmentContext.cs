using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Infrustructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore
{
    public class CustomerManagmentContext : DbContext 
    {
        public DbSet<Company> Companies { get; set; }
        public CustomerManagmentContext(DbContextOptions<CustomerManagmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
