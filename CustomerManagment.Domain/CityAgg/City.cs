using _0_Framework.Domain;
using CustomerManagment.Domain.AddressAgg;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Domain.CityAgg
{
    public class City : EntityBase<long>
    {
        public string Name { get; set; }
        public long ProvinceId { get; set; }
        public Province Province { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

    }
}
