using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Company;

namespace CustomerManagment.Domain.CompanyAgg
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        List<CompanyViewModel> List();
        CompanyViewModel GetBy(long id);
    }
}
