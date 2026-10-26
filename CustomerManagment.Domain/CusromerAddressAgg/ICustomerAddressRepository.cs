using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.CustomerAddress;

namespace CustomerManagment.Domain.CusromerAddressAgg
{
    public interface ICustomerAddressRepository : IRepository<long, CustomerAddress>
    {
        List<CustomerAddressViewModel> List();
        CustomerAddressViewModel GetBy(long id);
    }
}
