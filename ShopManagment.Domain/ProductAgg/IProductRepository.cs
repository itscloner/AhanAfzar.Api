using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        List<ProductViewModel> List();
        List<ProductViewModel> Search(string name);
        ProductViewModel GetBy(long id);



    }
}
