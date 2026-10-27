using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Application.Contracts.CustomerCompany;
using CustomerManagment.Domain.CusromerCompanyAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CustomerCompanyRepository : ReposioryBase<long, CustomerCompany>, ICustomerCompanyRepository
    {
        private readonly CustomerManagmentContext _context;

        public CustomerCompanyRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CustomerCompanyViewModel GetBy(long id)
        {
            return _context.CustomerCompany.Select(x => new CustomerCompanyViewModel
            {
               CustomerId = x.CustomerId,
               CompanyId = x.CompanyId,
               Customer = new CustomerViewModel
               {
                   FirstName = x.Customer.FirstName,
                   LastName = x.Customer.LastName,
                   NationalCode = x.Customer.NationalCode,
                   CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی" 
               },
               Company = new CompanyViewModel
               {
                   Name = x.Company.Name,
                   BrandName = x.Company.BrandName,
                   Description = x.Company.Description,
               }
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerCompanyViewModel> List()
        {
            return _context.CustomerCompany.Select(x => new CustomerCompanyViewModel
            {
                CustomerId = x.CustomerId,
                CompanyId = x.CompanyId,
                Customer = new CustomerViewModel
                {
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    NationalCode = x.Customer.NationalCode,
                    CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی"
                },
                Company = new CompanyViewModel
                {
                    Name = x.Company.Name,
                    BrandName = x.Company.BrandName,
                    Description = x.Company.Description,
                }
            }).ToList();
        }
    }
}
