using _0_Framework.Application;
using ShopManagment.Application.Contracts.ProductBrand;
using ShopManagment.Domain.ProductBrandAgg;

namespace ShopManagment.Application
{
    public class ProductBrandApplication : IProductBrandApplication
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductBrandApplication(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        public OperationResult Create(CreateProductBrand command)
        {
            var operation = new OperationResult();
            if (_productBrandRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productBrand = new ProductBrand(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productBrandRepository.Create(productBrand);
            _productBrandRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.Get(id);

            if (productBrand == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productBrand.IsDeleted = true;
            _productBrandRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductBrand command)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.Get(command.Id);

            if (productBrand == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productBrandRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productBrand.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productBrandRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductBrandViewModel GetBy(long id)
        {
            return _productBrandRepository.GetBy(id);
        }

        public EditProductBrand GetDetails(long id)
        {
            return _productBrandRepository.GetDetails(id);
        }

        public ProductBrandViewModel GetProductBrand(long id)
        {
            return _productBrandRepository.GetBy(id);
        }

        public List<ProductBrandViewModel> List()
        {
            return _productBrandRepository.List();
        }

        public List<ProductBrandViewModel> Search(SearchProductBrand name)
        {
            return _productBrandRepository.Search(name.Name);
        }

    }
}
