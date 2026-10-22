using _0_Framework.Domain;
using ShopManagment.Domain.CategoryAgg;
using ShopManagment.Domain.StandardAgg;
using ShopManagment.Domain.UnitAgg;
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

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long StandardId { get; set; }
        public Standard Standard { get; set; }

        public long UnitId { get; set; }
        public Unit Unit { get; set; }

        public Product(string code, string name, string description, string size, decimal weight,
            string picture, string pictureAlt, string pictureTitle, long categoryId, long standardId, long unitId)
        {
            Code = code;
            Name = name;
            Description = description;
            Size = size;
            Weight = weight;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            StandardId = standardId;
            UnitId = unitId;
        }

        public void Edit(string code, string name, string description, string size, decimal weight,
            string picture, string pictureAlt, string pictureTitle, long categoryId, long standardId, long unitId)
        {
            Code = code;
            Name = name;
            Description = description;
            Size = size;
            Weight = weight;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            StandardId = standardId;
            UnitId = unitId;

        }
        public void Removed()
        {
            IsDeleted = true;
        }
    }
}
