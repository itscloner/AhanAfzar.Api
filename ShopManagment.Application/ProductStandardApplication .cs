using _0_Framework.Application;
using ShopManagment.Application.Contracts.ProductStandard;
using ShopManagment.Domain.ProductStandardAgg;

namespace ShopManagment.Application
{
    public class ProductStandardApplication : IProductStandardApplication
    {
        private readonly IProductStandardRepository _productStandardRepository;

        public ProductStandardApplication(IProductStandardRepository productStandardRepository)
        {
            _productStandardRepository = productStandardRepository;
        }

        public OperationResult Create(CreateProductStandard command)
        {
            var operation = new OperationResult();
            if (_productStandardRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productStandard = new ProductStandard(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productStandardRepository.Create(productStandard);
            _productStandardRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productStandard = _productStandardRepository.Get(id);

            if (productStandard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productStandard.IsDeleted = true;
            _productStandardRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductStandard command)
        {
            var operation = new OperationResult();
            var productStandard = _productStandardRepository.Get(command.Id);

            if (productStandard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productStandardRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productStandard.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productStandardRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductStandardViewModel GetBy(long id)
        {
            return _productStandardRepository.GetBy(id);
        }

        public EditProductStandard GetDetails(long id)
        {
            return _productStandardRepository.GetDetails(id);
        }

        public ProductStandardViewModel GetProductStandard(long id)
        {
            return _productStandardRepository.GetBy(id);
        }

        public List<ProductStandardViewModel> List()
        {
            return _productStandardRepository.List();
        }

        public List<ProductStandardViewModel> Search(SearchProductStandard name)
        {
            return _productStandardRepository.Search(name.Name);
        }

    }
}
