using _0_Framework.Domain;

namespace ShopManagment.Domain.SaleOrderAgg
{
    public class SaleOrder : EntityBase<long>
    {
        public string? OrderCode { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public SaleOrderSource Source { get; set; }
        public SaleOrderStatus Status { get; set; }


    }
}
