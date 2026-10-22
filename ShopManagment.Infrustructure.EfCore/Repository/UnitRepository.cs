using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Unit;
using ShopManagment.Domain.UnitAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class UnitRepository : ReposioryBase<long, Unit>, IUnitRepository
    {
        private readonly ShopManagmentContext _context;

        public UnitRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public UnitViewModel GetBy(long id)
        {
            return _context.Units.Select(x => new UnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public EditUnit GetDetails(long id)
        {
            return _context.Units.Select(x => new EditUnit
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<UnitViewModel> List()
        {
            return _context.Units.Select(x => new UnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<UnitViewModel> Search(string name)
        {
            return _context.Units.Select(x => new UnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
