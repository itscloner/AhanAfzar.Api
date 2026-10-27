using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Application.Contracts.CustomerAddress;
using CustomerManagment.Domain.CusromerAddressAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CustomerAddressRepository : ReposioryBase<long, CustomerAddress>, ICustomerAddressRepository
    {
        private readonly CustomerManagmentContext _context;

        public CustomerAddressRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CustomerAddressViewModel GetBy(long id)
        {
            return _context.CustomerAddress.Select(x => new CustomerAddressViewModel
            {
               CustomerId = x.CustomerId,
               AddressId = x.AddressId,
               Customer = new CustomerViewModel
               {
                   FirstName = x.Customer.FirstName,
                   LastName = x.Customer.LastName,
                   NationalCode = x.Customer.NationalCode,
                   CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی" 
               },
               Address = new AddressViewModel
               {
                   Title = x.Address.Title,
                   ProvinceName = x.Address.Province.Name,
                   CityName = x.Address.City.Name,
                   FullAddress = x.Address.FullAddress,
               }
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerAddressViewModel> List()
        {
            return _context.CustomerAddress.Select(x => new CustomerAddressViewModel
            {
                CustomerId = x.CustomerId,
                AddressId = x.AddressId,
                Customer = new CustomerViewModel
                {
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    NationalCode = x.Customer.NationalCode,
                    CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی"
                },
                Address = new AddressViewModel
                {
                    Title = x.Address.Title,
                    ProvinceName = x.Address.Province.Name,
                    CityName = x.Address.City.Name,
                    FullAddress = x.Address.FullAddress,
                }
            }).ToList();
        }
    }
}
