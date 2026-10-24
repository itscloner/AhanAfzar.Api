using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Company;

namespace ShopManagment.Domain.CompanyAgg
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        List<CompanyViewModel> List();
        CompanyViewModel GetBy(long id);
    }
}
