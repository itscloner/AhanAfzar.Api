using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Address;

namespace CustomerManagment.Domain.AddressAgg
{
    public interface IAddressRepository : IRepository<long, Address>
    {
        List<AddressViewModel> List();
        AddressViewModel GetBy(long id);
    }
}
