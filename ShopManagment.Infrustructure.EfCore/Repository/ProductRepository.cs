using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.Category;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Application.Contracts.Unit;
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
                .Include(x => x.Category)
                .Include(x => x.Standard)
                .Include(x => x.Unit)
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
                Category = new CategoryViewModel
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    Description = x.Category.Description,
                },
                Standard = new StandardViewModel
                {
                    Id = x.Standard.Id,
                    Name = x.Standard.Name,
                    Description = x.Standard.Description,
                },
                Unit = new UnitViewModel
                {
                    Id = x.Unit.Id,
                    Name = x.Unit.Name,
                    Description = x.Unit.Description,
                }
              }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> List()
        {
            return _context.Products
                .Include(x => x.Category)
                .Include(x => x.Standard)
                .Include(x => x.Unit)
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
                Category = new CategoryViewModel
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    Description = x.Category.Description,
                },
                Standard = new StandardViewModel
                {
                    Id = x.Standard.Id,
                    Name = x.Standard.Name,
                    Description = x.Standard.Description,
                },
                Unit = new UnitViewModel
                {
                    Id = x.Unit.Id,
                    Name = x.Unit.Name,
                    Description = x.Unit.Description,
                }
                }).ToList();
        }

        public List<ProductViewModel> Search(string name)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Standard)
                .Include(x => x.Unit)
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
                Category = new CategoryViewModel
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    Description = x.Category.Description,
                },
                Standard = new StandardViewModel
                {
                    Id = x.Standard.Id,
                    Name = x.Standard.Name,
                    Description = x.Standard.Description,
                },
                Unit = new UnitViewModel
                {
                    Id = x.Unit.Id,
                    Name = x.Unit.Name,
                    Description = x.Unit.Description,
                }
                });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name == name);

            return query.ToList();
        }
    }
}
