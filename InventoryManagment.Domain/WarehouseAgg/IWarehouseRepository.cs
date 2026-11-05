using _0_Framework.Domain;

namespace InventoryManagment.Domain.WarehouseAgg
{
    public interface IWarehouseRepository : IRepository<long, Warehouse>
    {
        List<WarehouseViewModel> List();
        WarehouseViewModel GetBy(long id);
    }
}
