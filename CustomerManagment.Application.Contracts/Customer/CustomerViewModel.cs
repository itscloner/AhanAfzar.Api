using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Application.Contracts.Contact;

namespace CustomerManagment.Application.Contracts.Customer
{
    public class CustomerViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string NationalCode { get; set; }
        public string CustomerType { get; set; }
        public List<CompanyViewModel> Companies { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public List<ContactViewModel> Contacts { get; set; }
    }
}
