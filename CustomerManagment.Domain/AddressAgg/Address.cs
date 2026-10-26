using _0_Framework.Domain;
using CustomerManagment.Domain.CityAgg;
using CustomerManagment.Domain.CusromerAddressAgg;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Domain.AddressAgg
{
    public class Address : EntityBase<long>
    {
        public string Title { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
        public long ProvinceId { get; set; }
        public Province Province { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public Address(string title, string fullAddress, string postalCode, long provinceId, long cityId)
        {
            Title = title;
            FullAddress = fullAddress;
            PostalCode = postalCode;
            ProvinceId = provinceId;
            CityId = cityId;
        }

        public void Edit(string title, string fullAddress, string postalCode, long provinceId, long cityId)
        {
            Title = title;
            FullAddress = fullAddress;
            PostalCode = postalCode;
            ProvinceId = provinceId;
            CityId = cityId;
        }
    }
}
