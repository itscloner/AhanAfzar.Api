using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.ProductBrand;
using ShopManagment.Domain.ProductBrandAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class ProductBrandRepository : ReposioryBase<long, ProductBrand>, IProductBrandRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductBrandRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ProductBrandViewModel GetBy(long id)
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditProductBrand GetDetails(long id)
        {
            return _context.ProductBrands.Select(x => new EditProductBrand
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ProductBrandViewModel> List()
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<ProductBrandViewModel> Search(string name)
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
