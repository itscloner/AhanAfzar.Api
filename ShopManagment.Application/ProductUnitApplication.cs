using _0_Framework.Application;
using ShopManagment.Application.Contracts.ProductUnit;
using ShopManagment.Domain.ProductUnitAgg;

namespace ShopManagment.Application
{
    public class ProductUnitApplication : IProductUnitApplication
    {
        private readonly IProductUnitRepository _productUnitRepository;

        public ProductUnitApplication(IProductUnitRepository productUnitRepository)
        {
            _productUnitRepository = productUnitRepository;
        }

        public OperationResult Create(CreateProductUnit command)
        {
            var operation = new OperationResult();
            if (_productUnitRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productUnit = new ProductUnit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productUnitRepository.Create(productUnit);
            _productUnitRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productUnit = _productUnitRepository.Get(id);

            if (productUnit == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productUnit.IsDeleted = true;
            _productUnitRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductUnit command)
        {
            var operation = new OperationResult();
            var productUnit = _productUnitRepository.Get(command.Id);

            if (productUnit == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productUnitRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productUnit.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productUnitRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductUnitViewModel GetBy(long id)
        {
            return _productUnitRepository.GetBy(id);
        }

        public EditProductUnit GetDetails(long id)
        {
            return _productUnitRepository.GetDetails(id);
        }

        public ProductUnitViewModel GetProductUnit(long id)
        {
            return _productUnitRepository.GetBy(id);
        }

        public List<ProductUnitViewModel> List()
        {
            return _productUnitRepository.List();
        }

        public List<ProductUnitViewModel> Search(SearchProductUnit name)
        {
            return _productUnitRepository.Search(name.Name);
        }

    }
}
