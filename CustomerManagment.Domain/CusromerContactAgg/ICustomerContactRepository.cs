using _0_Framework.Domain;

using CustomerManagment.Application.Contracts.CustomerContact;
namespace CustomerManagment.Domain.CusromerContactAgg
{
    public interface ICustomerContactRepository : IRepository<long, CustomerContact>
    {
        List<CustomerContactViewModel> List();
        CustomerContactViewModel GetBy(long id);
    }
}
