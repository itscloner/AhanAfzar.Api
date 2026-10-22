using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.ProductUnit;
using ShopManagment.Domain.ProductUnitAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class ProductUnitRepository : ReposioryBase<long, ProductUnit>, IProductUnitRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductUnitRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ProductUnitViewModel GetBy(long id)
        {
            return _context.ProductUnits.Select(x => new ProductUnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditProductUnit GetDetails(long id)
        {
            return _context.ProductUnits.Select(x => new EditProductUnit
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ProductUnitViewModel> List()
        {
            return _context.ProductUnits.Select(x => new ProductUnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<ProductUnitViewModel> Search(string name)
        {
            return _context.ProductUnits.Select(x => new ProductUnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
