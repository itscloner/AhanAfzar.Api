using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Unit;

namespace ShopManagment.Domain.UnitAgg
{
    public interface IUnitRepository : IRepository<long, Unit>
    {
        EditUnit GetDetails(long id);
        List<UnitViewModel> List();
        List<UnitViewModel> Search(string name);
        UnitViewModel GetBy(long id);

    }
}
