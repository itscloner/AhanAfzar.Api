using _0_Framework.Domain;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductStandardAgg;
using ShopManagment.Domain.ProductUnitAgg;
using System.Drawing;

namespace ShopManagment.Domain.ProductAgg
{
    public class Product : EntityBase<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public long ProductStandardId { get; set; }
        public ProductStandard ProductStandard { get; set; }

        public long ProductUnitId { get; set; }
        public ProductUnit ProductUnit { get; set; }

        public Product(string code, string name, string description, string size, decimal weight,
            string picture, string pictureAlt, string pictureTitle, long productCategoryId, long productStandardId, long productUnitId)
        {
            Code = code;
            Name = name;
            Description = description;
            Size = size;
            Weight = weight;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductCategoryId = productCategoryId;
            ProductStandardId = productStandardId;
            ProductUnitId = productUnitId;
        }

        public void Edit(string code, string name, string description, string size, decimal weight,
            string picture, string pictureAlt, string pictureTitle, long productCategoryId, long productStandardId, long productUnitId)
        {
            Code = code;
            Name = name;
            Description = description;
            Size = size;
            Weight = weight;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductCategoryId = productCategoryId;
            ProductStandardId = productStandardId;
            ProductUnitId = productUnitId;

        }
        public void Removed()
        {
            IsDeleted = true;
        }
    }
}
