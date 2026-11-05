using _0_Framework.Domain;

namespace InventoryManagment.Domain.WarehouseAgg
{
    public class Warehouse : EntityBase<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public Warehouse(string code, string name, string description, string address, bool isActive)
        {
            Code = code;
            Name = name;
            Description = description;
            Address = address;
            IsActive = isActive;
        }

        public void Edit(string code, string name, string description, string address, bool isActive)
        {
            Code = code;
            Name = name;
            Description = description;
            Address = address;
            IsActive = isActive;
        }
    }
}
