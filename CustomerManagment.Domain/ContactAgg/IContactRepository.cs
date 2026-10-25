using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Contact;

namespace CustomerManagment.Domain.ContactAgg
{
    public interface IContactRepository : IRepository<long, Contact>
    {
        List<ContactViewModel> List();
        ContactViewModel GetBy(long id);
    }
}
