using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Standard
{
    public interface IStandardApplication 
    {
        OperationResult Create(CreateStandard command);
        OperationResult Edit(EditStandard command);
        List<StandardViewModel> Search(SearchStandard name);
        List<StandardViewModel> List();
        EditStandard GetDetails(long id);
        OperationResult Delete(long id);
        StandardViewModel GetBy(long id);
    }
}
