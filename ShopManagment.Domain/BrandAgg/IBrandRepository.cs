using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Brand;

namespace ShopManagment.Domain.BrandAgg
{
    public interface IBrandRepository : IRepository<long, Brand>
    {
        EditBrand GetDetails(long id);
        List<BrandViewModel> List();
        List<BrandViewModel> Search(string name);
        BrandViewModel GetBy(long id);

    }
}
