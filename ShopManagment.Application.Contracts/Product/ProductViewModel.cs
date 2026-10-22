using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductStandard;
using ShopManagment.Application.Contracts.ProductUnit;

namespace ShopManagment.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }
        public ProductStandardViewModel ProductStandard { get; set; }
        public ProductUnitViewModel ProductUnit { get; set; }
    }
}
