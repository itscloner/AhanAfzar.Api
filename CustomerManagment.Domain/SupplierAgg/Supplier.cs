using _0_Framework.Domain;
using CustomerManagment.Domain.CustomerAgg;
using ShopManagment.Domain.ProductAgg;

namespace CustomerManagment.Domain.SupplierAgg
{
    public class Supplier : EntityBase<long>
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RentPrice { get; set; } // کرایه تمام شده   
        public decimal OverPrice { get; set; } // قیمت تمام شده
        public DateTime PriceDate { get; set; } // تاریخ قیمت گذاری

        public Supplier(long customerId, long productId, decimal unitPrice, 
            decimal rentPrice, decimal overPrice, DateTime priceDate)
        {
            CustomerId = customerId;
            ProductId = productId;
            UnitPrice = unitPrice;
            RentPrice = rentPrice;
            OverPrice = overPrice;
            PriceDate = priceDate;
        }

        public void Edit(long customerId, long productId, decimal unitPrice,
            decimal rentPrice, decimal overPrice, DateTime priceDate)
        {
            CustomerId = customerId;
            ProductId = productId;
            UnitPrice = unitPrice;
            RentPrice = rentPrice;
            OverPrice = overPrice;
            PriceDate = priceDate;
        }
    }


}
