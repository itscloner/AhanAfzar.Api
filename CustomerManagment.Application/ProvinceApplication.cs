using CustomerManagment.Application.Contracts.Province;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Application
{
    public class ProvinceApplication : IProvinceApplication
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceApplication(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public List<ProvinceViewModel> List()
        {
            return _provinceRepository.List();
        }
    }
}
