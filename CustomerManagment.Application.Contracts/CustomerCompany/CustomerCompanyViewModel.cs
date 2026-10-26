using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Application.Contracts.Customer;

namespace CustomerManagment.Application.Contracts.CustomerCompany
{
    public class CustomerCompanyViewModel
    {
        public long CustomerId { get; set; }
        public long CompanyId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
