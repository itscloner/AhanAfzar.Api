using ShopManagment.Application.Contracts.Brand;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Application.Contracts.ProductBrand
{
    public class ProductBrandViewModel
    {
        public long Id { get; set; }
        public ProductViewModel Product { get; set; }
        public BrandViewModel Brand { get; set; }
    }
}
