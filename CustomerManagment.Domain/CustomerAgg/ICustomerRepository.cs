using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Customer;

namespace CustomerManagment.Domain.CustomerAgg
{
    public interface ICustomerRepository : IRepository<long, Customer>
    {
        List<CustomerViewModel> List();
        CustomerViewModel GetBy(long id);
    }
}
