using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerManagment.Application;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Infrustructure.EfCore.Repository;
using CustomerManagment.Infrustructure.EfCore;

namespace CustomerManagment.Infrustructure.Configuration
{
    public class CustomerManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();


            services.AddDbContext<CustomerManagmentContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
