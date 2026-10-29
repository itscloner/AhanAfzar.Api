namespace CustomerManagment.Application.Contracts.Supplier
{
    public class SupplierViewModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RentPrice { get; set; }
        public decimal OverPrice { get; set; }
        public DateTime PriceDate { get; set; }

    }
}
