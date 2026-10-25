using _0_Framework.Domain;

namespace CustomerManagment.Domain.CustomerAgg
{
    public interface ICustomerRepository : IRepository<long, Customer>
    {
        List<CustomerViewModel> List();
        CustomerViewModel GetBy(long id);
    }
}
