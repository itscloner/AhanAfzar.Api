using _0_Framework.Application;
using InventoryManagment.Application.Contracts.Warehouse;
using InventoryManagment.Domain.WarehouseAgg;

namespace InventoryManagment.Application
{
    public class WarehouseApplication : IWarehouseApplication
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseApplication(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public OperationResult Create(CreateWarehouse command)
        {
            var operation = new OperationResult();

            var isExitWarehouse = _warehouseRepository.Exist(x => x.Name == command.Name && x.Code == command.Code);
            if (isExitWarehouse) return operation.Failed("انبار قبلا اضافه شده است");
            
            var warehouse = new Warehouse(command.Code, command.Name, command.Description, command.Address, command.IsActive);
            _warehouseRepository.Create(warehouse);
            _warehouseRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            
            var warehouse = _warehouseRepository.Get(id);
            if (warehouse == null) return operation.Failed("انبار یافت نشد");

            warehouse.IsDeleted = true;
            _warehouseRepository.SaveChanges();

            return operation.Succedded();   
        }

        public OperationResult Edit(EditWarehouse command)
        {
            var operation = new OperationResult();

            var warehouse = _warehouseRepository.Get(command.Id);
            if (warehouse == null) return operation.Failed("انبار یافت نشد");

            var isExitWarehouse = _warehouseRepository.Exist(x => x.Name == command.Name && x.Code == command.Code);
            if (isExitWarehouse) return operation.Failed("انبار قبلا اضافه شده است");

            warehouse.Edit(command.Code, command.Name, command.Description, command.Address, command.IsActive);
            _warehouseRepository.SaveChanges();

            return operation.Succedded();

        }

        public WarehouseViewModel GetBy(long id)
        {
            return _warehouseRepository.GetBy(id);
        }

        public List<WarehouseViewModel> List()
        {
            return _warehouseRepository.List();
        }
    }
}
