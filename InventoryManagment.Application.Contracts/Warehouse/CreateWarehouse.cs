namespace InventoryManagment.Application.Contracts.Warehouse
{
    public class CreateWarehouse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
