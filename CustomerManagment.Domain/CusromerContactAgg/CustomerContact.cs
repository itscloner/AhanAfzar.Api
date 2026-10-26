using _0_Framework.Domain;
using CustomerManagment.Domain.ContactAgg;
using CustomerManagment.Domain.CustomerAgg;

namespace CustomerManagment.Domain.CusromerContactAgg
{
    public class CustomerContact : EntityBase<long>
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long ContactId { get; set; }
        public Contact Contact { get; set; }

        public CustomerContact(long customerId, long contactId)
        {
            CustomerId = customerId;
            ContactId = contactId;
        }
        public void Edit(long customerId, long contactId)
        {
            CustomerId = customerId;
            ContactId = contactId;
        }
    }
}
