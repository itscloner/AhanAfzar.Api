using _0_Framework.Domain;
using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Domain.ContactAgg;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Domain.CustomerAgg
{
    public class Customer : EntityBase<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string NationalCode { get; set; }
        public long ProvinceId { get; set; }
        public Province Province { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }

        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public Customer(string firstName, string lastName, string description, 
            string nationalCode, long provinceId, long cityId)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            NationalCode = nationalCode;
            ProvinceId = provinceId;
            CityId = cityId;
        }

        public void Edit(string firstName, string lastName, string description,
            string nationalCode, long provinceId, long cityId)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            NationalCode = nationalCode;
            ProvinceId = provinceId;
            CityId = cityId;
        }
    }
}
