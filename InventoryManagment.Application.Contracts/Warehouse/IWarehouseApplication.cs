using _0_Framework.Application;

namespace InventoryManagment.Application.Contracts.Warehouse
{
    public interface IWarehouseApplication
    {
        OperationResult Create(CreateWarehouse command);
        OperationResult Edit(EditWarehouse command);
        OperationResult Delete(long id);
        List<WarehouseViewModel> List();
        WarehouseViewModel GetBy(long id);
    }
}
