using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Category;
using ShopManagment.Domain.CategoryAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class CategoryRepository : ReposioryBase<long, Category>, ICategoryRepository
    {
        private readonly ShopManagmentContext _context;

        public CategoryRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CategoryViewModel GetBy(long id)
        {
            return _context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditCategory GetDetails(long id)
        {
            return _context.Categories.Select(x => new EditCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<CategoryViewModel> GetCategories()
        {
            return _context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public CategoryViewModel GetCategory(long id)
        {
            return _context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }
        public List<CategoryViewModel> Search(string name)
        {
            return _context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
