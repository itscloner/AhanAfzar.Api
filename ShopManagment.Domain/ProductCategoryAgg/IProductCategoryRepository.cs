using _0_Framework.Domain;
using ShopManagment.Application.Contracts.ProductCategory;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(string name);
        ProductCategoryViewModel GetProductCategory(long id);
        ProductCategoryViewModel GetBy(long id);

    }
}
