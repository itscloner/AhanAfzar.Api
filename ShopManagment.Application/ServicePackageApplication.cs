using _0_Framework.Application;
using ShopManagment.Application.Contracts.ServicePackage;
using ShopManagment.Domain.ServicePackageAgg;

namespace ShopManagment.Application
{
    public class ServicePackageApplication : IServicePackageApplication
    {
        private readonly IServicePackageRepository _productServicePackageRepository;

        public ServicePackageApplication(IServicePackageRepository productServicePackageRepository)
        {
            _productServicePackageRepository = productServicePackageRepository;
        }

        public OperationResult Create(CreateServicePackage command)
        {
            var operation = new OperationResult();
            if (_productServicePackageRepository.Exist(x => x.Title == command.Title))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productServicePackage = new ServicePackage(command.Title, command.Description,  command.UnitPrice);

            _productServicePackageRepository.Create(productServicePackage);
            _productServicePackageRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productServicePackage = _productServicePackageRepository.Get(id);

            if (productServicePackage == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productServicePackage.IsDeleted = true;
            _productServicePackageRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditServicePackage command)
        {
            var operation = new OperationResult();
            var productServicePackage = _productServicePackageRepository.Get(command.Id);

            if (productServicePackage == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productServicePackageRepository.Exist(x => x.Title == command.Title))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productServicePackage.Edit(command.Title, command.Description,  command.UnitPrice);

            _productServicePackageRepository.SaveChanges();

            return operation.Succedded();
        }

        public ServicePackageViewModel GetBy(long id)
        {
            return _productServicePackageRepository.GetBy(id);
        }

        public List<ServicePackageViewModel> List()
        {
            return _productServicePackageRepository.List();
        }

    }
}
