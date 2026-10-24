using _0_Framework.Application;
using ShopManagment.Application.Contracts.Category;
using ShopManagment.Domain.CategoryAgg;

namespace ShopManagment.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateCategory command)
        {
            var operation = new OperationResult();
            if (_categoryRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var category = new Category(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _categoryRepository.Create(category);
            _categoryRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var category = _categoryRepository.Get(id);

            if (category == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            category.IsDeleted = true;
            _categoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCategory command)
        {
            var operation = new OperationResult();
            var category = _categoryRepository.Get(command.Id);

            if (category == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_categoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            category.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _categoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public CategoryViewModel GetBy(long id)
        {
            return _categoryRepository.GetBy(id);
        }

        public EditCategory GetDetails(long id)
        {
            return _categoryRepository.GetDetails(id);
        }
        public List<CategoryViewModel> List()
        {
            return _categoryRepository.GetCategories();
        }

        public List<CategoryViewModel> Search(SearchCategory name)
        {
            return _categoryRepository.Search(name.Name);
        }

    }
}
