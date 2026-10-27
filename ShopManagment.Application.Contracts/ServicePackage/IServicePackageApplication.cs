using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.ServicePackage
{
    public interface IServicePackageApplication
    {
        OperationResult Create(CreateServicePackage command);
        OperationResult Edit(EditServicePackage command);
        OperationResult Delete(long id);
        List<ServicePackageViewModel> List();
        ServicePackageViewModel GetBy(long id);
    }
}
