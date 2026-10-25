using _0_Framework.Domain;
using CustomerManagment.Domain.CityAgg;

namespace CustomerManagment.Domain.ProvinceAgg
{
    public class Province : EntityBase<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();

    }
}
