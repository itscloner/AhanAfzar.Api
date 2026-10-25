using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.City;

namespace CustomerManagment.Domain.CityAgg
{
    public interface ICityRepository : IRepository<long, City>
    {
        List<CityViewModel> List(long provinceId);
    }
}
