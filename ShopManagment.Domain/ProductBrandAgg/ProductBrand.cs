using _0_Framework.Domain;
using ShopManagment.Domain.BrandAgg;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.ProductBrandAgg
{
    public class ProductBrand : EntityBase<long>
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long BrandId { get; set; }
        public Brand Brand { get; set; }

        public ProductBrand(long productId, long brandId)
        {
            ProductId = productId;
            BrandId = brandId;
        }

        public void Edit(long productId, long brandId)
        {
            ProductId = productId;
            BrandId = brandId;
        }
    }
}
