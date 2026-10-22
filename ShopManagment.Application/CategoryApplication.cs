using _0_Framework.Application;
using ShopManagment.Application.Contracts.Category;
using ShopManagment.Domain.CategoryAgg;

namespace ShopManagment.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _productCategoryRepository;

        public CategoryApplication(ICategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productCategory = new Category(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);

            if (productCategory == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productCategory.IsDeleted = true;
            _productCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _productCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public CategoryViewModel GetBy(long id)
        {
            return _productCategoryRepository.GetBy(id);
        }

        public EditCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public CategoryViewModel GetProductCategory(long id)
        {
            return _productCategoryRepository.GetCategory(id);   
        }

        public List<CategoryViewModel> List()
        {
            return _productCategoryRepository.GetCategories();
        }

        public List<CategoryViewModel> Search(SearchCategory name)
        {
            return _productCategoryRepository.Search(name.Name);
        }

    }
}
