using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.Company;
using ShopManagment.Domain.CompanyAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class CompanyRepository : ReposioryBase<long, Company>, ICompanyRepository
    {
        private readonly ShopManagmentContext _context;

        public CompanyRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CompanyViewModel GetBy(long id)
        {
            return _context.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                EconomicCode = x.EconomicCode,
                BrandName = x.BrandName,
                NationalId = x.NationalId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CompanyViewModel> List()
        {
            return _context.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                EconomicCode = x.EconomicCode,
                BrandName = x.BrandName,
                NationalId = x.NationalId
            }).ToList();
        }
    }
}
