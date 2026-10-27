using _0_Framework.Domain;

namespace ShopManagment.Domain.ServicePackageAgg
{
    public class ServicePackage : EntityBase<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public ServicePackage(string title, string description, decimal unitPrice)
        {
            Title = title;
            Description = description;
            UnitPrice = unitPrice;
        }

        public void Edit(string title, string description, decimal unitPrice)
        {
            Title = title;
            Description = description;
            UnitPrice = unitPrice;
        }
    }
}
