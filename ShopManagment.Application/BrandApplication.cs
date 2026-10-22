using _0_Framework.Application;
using ShopManagment.Application.Contracts.Brand;
using ShopManagment.Domain.BrandAgg;

namespace ShopManagment.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly IBrandRepository _productBrandRepository;

        public BrandApplication(IBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        public OperationResult Create(CreateBrand command)
        {
            var operation = new OperationResult();
            if (_productBrandRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productBrand = new Brand(command.Name, command.Description,  command.Keyword,
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

        public OperationResult Edit(EditBrand command)
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

        public BrandViewModel GetBy(long id)
        {
            return _productBrandRepository.GetBy(id);
        }

        public EditBrand GetDetails(long id)
        {
            return _productBrandRepository.GetDetails(id);
        }

        public BrandViewModel GetProductBrand(long id)
        {
            return _productBrandRepository.GetBy(id);
        }

        public List<BrandViewModel> List()
        {
            return _productBrandRepository.List();
        }

        public List<BrandViewModel> Search(SearchBrand name)
        {
            return _productBrandRepository.Search(name.Name);
        }

    }
}
