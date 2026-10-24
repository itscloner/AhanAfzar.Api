using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Domain.StandardAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class StandardRepository : ReposioryBase<long, Standard>, IStandardRepository
    {
        private readonly ShopManagmentContext _context;

        public StandardRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public StandardViewModel GetBy(long id)
        {
            return _context.Standards.Select(x => new StandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditStandard GetDetails(long id)
        {
            return _context.Standards.Select(x => new EditStandard
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<StandardViewModel> List()
        {
            return _context.Standards.Select(x => new StandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<StandardViewModel> Search(string name)
        {
            return _context.Standards.Select(x => new StandardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
