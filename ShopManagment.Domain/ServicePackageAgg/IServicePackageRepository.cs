using _0_Framework.Domain;
using ShopManagment.Application.Contracts.ServicePackage;

namespace ShopManagment.Domain.ServicePackageAgg
{
    public interface IServicePackageRepository : IRepository<long, ServicePackage>
    {
        List<ServicePackageViewModel> List();
        ServicePackageViewModel GetBy(long id);
    }
}
