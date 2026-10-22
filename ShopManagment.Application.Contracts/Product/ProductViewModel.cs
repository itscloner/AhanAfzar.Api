using ShopManagment.Application.Contracts.Category;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Application.Contracts.Unit;

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

        public CategoryViewModel Category { get; set; }
        public StandardViewModel Standard { get; set; }
        public UnitViewModel Unit { get; set; }
    }
}
