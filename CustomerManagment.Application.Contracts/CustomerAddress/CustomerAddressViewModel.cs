using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Application.Contracts.Customer;

namespace CustomerManagment.Application.Contracts.CustomerAddress
{
    public class CustomerAddressViewModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
