using _0_Framework.Domain;
using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Domain.ContactAgg;
using CustomerManagment.Domain.CusromerAddressAgg;
using CustomerManagment.Domain.CusromerCompanyAgg;
using CustomerManagment.Domain.CusromerContactAgg;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Domain.CustomerAgg
{
    public class Customer : EntityBase<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string NationalCode { get; set; }
        public CustomerType CustomerType { get; set; }

        public ICollection<CustomerCompany> CustomerCompanies { get; set; } = new List<CustomerCompany>();
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
        public ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();

        public Customer(string firstName, string lastName, string description, 
            string nationalCode, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            NationalCode = nationalCode;
            CustomerType = customerType;
        }

        public void Edit(string firstName, string lastName, string description,
            string nationalCode, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            NationalCode = nationalCode;
            CustomerType = customerType;
        }
    }
}
