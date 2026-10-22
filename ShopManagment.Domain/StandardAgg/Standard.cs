using _0_Framework.Domain;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.StandardAgg
{
    public class Standard : EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Standard(string name, string description, 
             string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }
        public void Edit(string name, string description, 
             string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Removed()
        {
            IsDeleted = true;
        }
    }
}
