using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.ProductStandard;
using ShopManagment.Domain.ProductStandardAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class ProductStandardRepository : ReposioryBase<long, ProductStandard>, IProductStandardRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductStandardRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ProductStandardViewModel GetBy(long id)
        {
            return _context.ProductStandards.Select(x => new ProductStandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditProductStandard GetDetails(long id)
        {
            return _context.ProductStandards.Select(x => new EditProductStandard
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ProductStandardViewModel> List()
        {
            return _context.ProductStandards.Select(x => new ProductStandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<ProductStandardViewModel> Search(string name)
        {
            return _context.ProductStandards.Select(x => new ProductStandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
