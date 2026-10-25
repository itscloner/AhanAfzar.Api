using CustomerManagment.Application.Contracts.City;
using CustomerManagment.Domain.CityAgg;

namespace CustomerManagment.Application
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<CityViewModel> List(long provinceId)
        {
            return _cityRepository.List(provinceId);
        }
    }
}
