using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerManagment.Application;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Infrustructure.EfCore.Repository;
using CustomerManagment.Infrustructure.EfCore;
using CustomerManagment.Application.Contracts.Province;
using CustomerManagment.Domain.ProvinceAgg;
using CustomerManagment.Application.Contracts.City;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Application.Contracts.Contact;
using CustomerManagment.Domain.ContactAgg;

namespace CustomerManagment.Infrustructure.Configuration
{
    public class CustomerManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IProvinceApplication, ProvinceApplication>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            
            services.AddTransient<ICityApplication, CityApplication>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<IAddressApplication, AddressApplication>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IContactApplication, ContactApplication>();
            services.AddTransient<IContactRepository, ContactRepository>();



            services.AddDbContext<CustomerManagmentContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
