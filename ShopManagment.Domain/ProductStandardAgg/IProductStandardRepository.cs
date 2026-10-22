using _0_Framework.Domain;
using ShopManagment.Application.Contracts;
using ShopManagment.Application.Contracts.ProductStandard;

namespace ShopManagment.Domain.ProductStandardAgg
{
    public interface IProductStandardRepository : IRepository<long, ProductStandard>
    {
        EditProductStandard GetDetails(long id);
        List<ProductStandardViewModel> List();
        List<ProductStandardViewModel> Search(string name);
        ProductStandardViewModel GetBy(long id);

    }
}
