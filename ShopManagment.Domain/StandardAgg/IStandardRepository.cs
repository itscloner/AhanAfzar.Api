using _0_Framework.Domain;
using ShopManagment.Application.Contracts.Standard;

namespace ShopManagment.Domain.StandardAgg
{
    public interface IStandardRepository : IRepository<long, Standard>
    {
        EditStandard GetDetails(long id);
        List<StandardViewModel> List();
        List<StandardViewModel> Search(string name);
        StandardViewModel GetBy(long id);

    }
}
