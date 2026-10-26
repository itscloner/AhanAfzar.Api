using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.CustomerCompany;

namespace CustomerManagment.Domain.CusromerCompanyAgg
{
    public interface ICustomerCompanyRepository : IRepository<long, CustomerCompany>
    {
        List<CustomerCompanyViewModel> List();
        CustomerCompanyViewModel GetBy(long id);
    }
}
