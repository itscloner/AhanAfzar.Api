using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Domain.CustomerAgg;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CustomerRepository : ReposioryBase<long, Customer>, ICustomerRepository
    {
        private readonly CustomerManagmentContext _context;

        public CustomerRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CustomerViewModel GetBy(long id)
        {
            return _context.Customer
                .Select(x => new CustomerViewModel
            {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    NationalCode = x.NationalCode,
                    Description = x.Description, 
                    CustomerType = x.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی",
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerViewModel> List()
        {
            return _context.Customer
                .Select(x => new CustomerViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    NationalCode = x.NationalCode,
                    Description = x.Description,
                    CustomerType = x.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی",
                }).ToList();
        }
    }
}
