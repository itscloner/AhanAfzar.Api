using _0_Framework.Domain;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Domain.CityAgg
{
    public class City : EntityBase<long>
    {
        public string Name { get; set; }
        public long ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
