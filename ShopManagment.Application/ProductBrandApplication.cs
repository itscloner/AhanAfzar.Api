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

            var isExistProductBrand = _productBrandRepository.Exist(x => x.ProductId == command.ProductId && x.BrandId == command.BrandId);
            if (isExistProductBrand) return operation.Failed("کالابرند قبلا در سیستم ثبت شده است");

            var productBrand = new ProductBrand(command.ProductId, command.BrandId);

            _productBrandRepository.Create(productBrand);
            _productBrandRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.Get(id);
            if (productBrand == null) return operation.Failed("کالابرند در سامانه ثبت نشده");

            productBrand.IsDeleted = true;
            _productBrandRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductBrand command)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.Get(command.Id);
            if (productBrand == null) return operation.Failed("کالابرند در سامانه ثبت نشده");
            var isExistProductBrand = _productBrandRepository.Exist(x => x.ProductId == command.ProductId && x.BrandId == command.BrandId);
            if (isExistProductBrand) return operation.Failed("کالابرند قبلا در سیستم ثبت شده است");

            productBrand.Edit(command.ProductId, command.BrandId);
            _productBrandRepository.SaveChanges();

            return operation.Succedded();

        }

        public ProductBrandViewModel GetBy(long id)
        {
            return _productBrandRepository.GetBy(id);
        }

        public List<ProductBrandViewModel> List()
        {
            return _productBrandRepository.List();
        }
    }
}
