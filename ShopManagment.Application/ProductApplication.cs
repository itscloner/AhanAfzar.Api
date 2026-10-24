using _0_Framework.Application;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var category = new Product(command.Code, command.Name, command.Description,
                command.Size, command.Weight, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId, command.StandardId, command.UnitId);

            _productRepository.Create(category);
            _productRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            product.IsDeleted = true;
            _productRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            product.Edit(command.Code, command.Name, command.Description,
                command.Size, command.Weight, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId, command.StandardId, command.UnitId);

            _productRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductViewModel GetBy(long id)
        {
            return _productRepository.GetBy(id);
        }

        public List<ProductViewModel> List()
        {
            return _productRepository.List();
        }

        public List<ProductViewModel> Search(SearchProduct command)
        {
            return _productRepository.Search(command.Name);
        }
    }
}
