using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Category;

namespace ShopManagment.Domain.CategoryAgg
{
    public interface ICategoryRepository : IRepository<long, Category>
    {
        EditCategory GetDetails(long id);
        List<CategoryViewModel> GetCategories();
        List<CategoryViewModel> Search(string name);
        CategoryViewModel GetCategory(long id);
        CategoryViewModel GetBy(long id);

    }
}
