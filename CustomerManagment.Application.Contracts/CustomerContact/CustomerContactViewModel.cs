using CustomerManagment.Application.Contracts.Contact;
using CustomerManagment.Application.Contracts.Customer;

namespace CustomerManagment.Application.Contracts.CustomerContact
{
    public class CustomerContactViewModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long ContactId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ContactViewModel Contact { get; set; }
    }
}
