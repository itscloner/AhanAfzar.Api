namespace CustomerManagment.Application.Contracts.Supplier
{
    public class CreateSupplier
    {
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RentPrice { get; set; }
        public decimal OverPrice { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
