using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Domain.CompanyAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CompanyRepository : ReposioryBase<long, Company>, ICompanyRepository
    {
        private readonly CustomerManagmentContext _context;

        public CompanyRepository(CustomerManagmentContext context) : base(context)
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
