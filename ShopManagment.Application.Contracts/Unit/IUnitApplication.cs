using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Unit
{
    public interface IUnitApplication 
    {
        OperationResult Create(CreateUnit command);
        OperationResult Edit(EditUnit command);
        List<UnitViewModel> Search(SearchUnit name);
        List<UnitViewModel> List();
        EditUnit GetDetails(long id);
        OperationResult Delete(long id);
        UnitViewModel GetBy(long id);
        UnitViewModel GetUnit(long id);
    }
}
