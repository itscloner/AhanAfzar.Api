using _0_Framework.Domain;

namespace ShopManagment.Domain.CustomerAgg
{
    public class Customer : EntityBase<long>
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; } = string.Empty;
        public string Mobile { get; set; }
        public bool IsSupplier { get; set; } = false;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CustomerType CustomerType { get; set; } = CustomerType.REAL;


    }
}
