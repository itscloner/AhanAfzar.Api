using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Contact;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Application.Contracts.CustomerContact;
using CustomerManagment.Domain.CusromerContactAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CustomerContactRepository : ReposioryBase<long, CustomerContact>, ICustomerContactRepository
    {
        private readonly CustomerManagmentContext _context;

        public CustomerContactRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CustomerContactViewModel GetBy(long id)
        {
            return _context.CustomerContact.Select(x => new CustomerContactViewModel
            {
               CustomerId = x.CustomerId,
               ContactId = x.ContactId,
               Customer = new CustomerViewModel
               {
                   FirstName = x.Customer.FirstName,
                   LastName = x.Customer.LastName,
                   NationalCode = x.Customer.NationalCode,
                   CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی" 
               },
               Contact = new ContactViewModel
               {
                   Title = x.Contact.Title,
                   Phone = x.Contact.Phone,
               }
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerContactViewModel> List()
        {
            return _context.CustomerContact.Select(x => new CustomerContactViewModel
            {
                CustomerId = x.CustomerId,
                ContactId = x.ContactId,
                Customer = new CustomerViewModel
                {
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    NationalCode = x.Customer.NationalCode,
                    CustomerType = x.Customer.CustomerType == CustomerType.LEGAL ? "حقوقی" : "حقیقی"
                },
                Contact = new ContactViewModel
                {
                    Title = x.Contact.Title,
                    Phone = x.Contact.Phone,
                }
            }).ToList();
        }
    }
}
