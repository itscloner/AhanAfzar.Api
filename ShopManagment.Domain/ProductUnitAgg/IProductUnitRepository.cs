using _0_Framework.Domain;
using ShopManagment.Application.Contracts;
using ShopManagment.Application.Contracts.ProductUnit;

namespace ShopManagment.Domain.ProductUnitAgg
{
    public interface IProductUnitRepository : IRepository<long, ProductUnit>
    {
        EditProductUnit GetDetails(long id);
        List<ProductUnitViewModel> List();
        List<ProductUnitViewModel> Search(string name);
        ProductUnitViewModel GetBy(long id);

    }
}
