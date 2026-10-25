using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Province;

namespace CustomerManagment.Domain.ProvinceAgg
{
    public interface IProvinceRepository : IRepository<long, Province>
    {
        List<ProvinceViewModel> List(); 
    }
}
