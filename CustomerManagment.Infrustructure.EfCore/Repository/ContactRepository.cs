using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Contact;
using CustomerManagment.Domain.ContactAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class ContactRepository : ReposioryBase<long, Contact>, IContactRepository
    {
        private readonly CustomerManagmentContext _context;

        public ContactRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ContactViewModel GetBy(long id)
        {
            return _context.Contacts
                .Select(x => new ContactViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Phone = x.Phone,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ContactViewModel> List()
        {
            return _context.Contacts
                .Select(x => new ContactViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Phone = x.Phone,
                }).ToList();
        }
    }
}
