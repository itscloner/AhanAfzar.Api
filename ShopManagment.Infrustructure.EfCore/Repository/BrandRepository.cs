using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Brand;
using ShopManagment.Domain.BrandAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class BrandRepository : ReposioryBase<long, Brand>, IBrandRepository
    {
        private readonly ShopManagmentContext _context;

        public BrandRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public BrandViewModel GetBy(long id)
        {
            return _context.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditBrand GetDetails(long id)
        {
            return _context.Brands.Select(x => new EditBrand
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<BrandViewModel> List()
        {
            return _context.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<BrandViewModel> Search(string name)
        {
            return _context.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
