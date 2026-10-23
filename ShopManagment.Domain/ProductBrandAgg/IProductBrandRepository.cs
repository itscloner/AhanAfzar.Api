using _0_Framework.Domain;
using ShopManagment.Application.Contracts.ProductBrand;

namespace ShopManagment.Domain.ProductBrandAgg
{
    public interface IProductBrandRepository : IRepository<long, ProductBrand>
    {
        List<ProductBrandViewModel> List();
        ProductBrandViewModel GetBy(long id);
    }
}
