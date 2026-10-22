using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductStandard;
using ShopManagment.Application.Contracts.ProductUnit;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class ProductRepository : ReposioryBase<long, Product>, IProductRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ProductViewModel GetBy(long id)
        {
            return _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductStandard)
                .Include(x => x.ProductUnit)
                .Select(x => new ProductViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                Size = x.Size,
                Weight = x.Weight,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductCategory = new ProductCategoryViewModel
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name,
                    Description = x.ProductCategory.Description,
                },
                ProductStandard = new ProductStandardViewModel
                {
                    Id = x.ProductStandard.Id,
                    Name = x.ProductStandard.Name,
                    Description = x.ProductStandard.Description,
                },
                ProductUnit = new ProductUnitViewModel
                {
                    Id = x.ProductUnit.Id,
                    Name = x.ProductUnit.Name,
                    Description = x.ProductUnit.Description,
                }
              }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> List()
        {
            return _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductStandard)
                .Include(x => x.ProductUnit)
                .Select(x => new ProductViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                Size = x.Size,
                Weight = x.Weight,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductCategory = new ProductCategoryViewModel
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name,
                    Description = x.ProductCategory.Description,
                },
                ProductStandard = new ProductStandardViewModel
                {
                    Id = x.ProductStandard.Id,
                    Name = x.ProductStandard.Name,
                    Description = x.ProductStandard.Description,
                },
                ProductUnit = new ProductUnitViewModel
                {
                    Id = x.ProductUnit.Id,
                    Name = x.ProductUnit.Name,
                    Description = x.ProductUnit.Description,
                }
                }).ToList();
        }

        public List<ProductViewModel> Search(string name)
        {
            var query = _context.Products
                .Include(x => x.ProductCategory)
                .Include (x => x.ProductStandard)
                .Include(x => x.ProductUnit)
                .Select(x => new ProductViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                Size = x.Size,
                Weight = x.Weight,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductCategory = new ProductCategoryViewModel
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name,
                    Description = x.ProductCategory.Description,
                },
                ProductStandard = new ProductStandardViewModel
                {
                    Id = x.ProductStandard.Id,
                    Name = x.ProductStandard.Name,
                    Description = x.ProductStandard.Description,
                },
                ProductUnit = new ProductUnitViewModel
                {
                    Id = x.ProductUnit.Id,
                    Name = x.ProductUnit.Name,
                    Description = x.ProductUnit.Description,
                }
                });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name == name);

            return query.ToList();
        }
    }
}
