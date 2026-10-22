using _0_Framework.Domain;

namespace ShopManagment.Domain.ProductStandardAgg
{
    public class ProductStandard : EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }

        public ProductStandard(string name, string description, 
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
