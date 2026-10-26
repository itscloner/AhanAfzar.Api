using _0_Framework.Domain;
using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.CustomerAgg;

namespace CustomerManagment.Domain.CusromerAddressAgg
{
    public class CustomerAddress : EntityBase<long>
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }

        public CustomerAddress(long customerId, long addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
        public void Edit(long customerId, long addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }
}
