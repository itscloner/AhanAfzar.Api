using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Brand;
using ShopManagment.Application.Contracts.Product;
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
                Brand = new BrandViewModel
                {
                    Id = x.Brand.Id,
                    Description = x.Brand.Description,
                    Name = x.Brand.Name
                },
                Product = new ProductViewModel
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Description = x.Product.Description,
                }
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductBrandViewModel> List()
        {
            return _context.ProductBrands.Select(x => new ProductBrandViewModel
            {
                Id = x.Id,
                Brand = new BrandViewModel
                {
                    Id = x.Brand.Id,
                    Description = x.Brand.Description,
                    Name = x.Brand.Name
                },
                Product = new ProductViewModel
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Description = x.Product.Description,
                }
            }).ToList();
        }
    }
}
