using _0_Framework.Domain;
using CustomerManagment.Domain.CustomerAgg;
using ShopManagment.Domain.ProductBrandAgg;
using ShopManagment.Domain.UnitAgg;

namespace ShopManagment.Domain.SaleOrderAgg
{
    public class Order : EntityBase<Guid>
    {
        public string? OrderCode { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderSource OrderSource { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();


    }

    public class OrderItem : EntityBase<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int Amount { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
