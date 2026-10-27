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
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Domain.CustomerAgg;
using CustomerManagment.Application.Contracts.CustomerContact;
using CustomerManagment.Domain.CusromerContactAgg;
using CustomerManagment.Application.Contracts.CustomerAddress;
using CustomerManagment.Domain.CusromerAddressAgg;
using CustomerManagment.Application.Contracts.CustomerCompany;
using CustomerManagment.Domain.CusromerCompanyAgg;

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


            services.AddTransient<ICustomerApplication, CustomerApplication>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICustomerContactApplication, CustomerContactApplication>();
            services.AddTransient<ICustomerContactRepository, CustomerContactRepository>();

            services.AddTransient<ICustomerAddressApplication, CustomerAddressApplication>();
            services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();

            services.AddTransient<ICustomerCompanyApplication, CustomerCompanyApplication>();
            services.AddTransient<ICustomerCompanyRepository, CustomerCompanyRepository>();


            services.AddDbContext<CustomerManagmentContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
