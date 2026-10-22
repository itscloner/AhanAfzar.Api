using _0_Framework.Domain;
using ShopManagment.Application.Contracts;
using ShopManagment.Application.Contracts.ProductBrand;

namespace ShopManagment.Domain.ProductBrandAgg
{
    public interface IProductBrandRepository : IRepository<long, ProductBrand>
    {
        EditProductBrand GetDetails(long id);
        List<ProductBrandViewModel> List();
        List<ProductBrandViewModel> Search(string name);
        ProductBrandViewModel GetBy(long id);

    }
}
