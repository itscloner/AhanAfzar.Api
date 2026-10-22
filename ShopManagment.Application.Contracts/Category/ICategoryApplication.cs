using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Category
{
    public interface ICategoryApplication 
    {
        OperationResult Create(CreateCategory command);
        OperationResult Edit(EditCategory command);
        List<CategoryViewModel> Search(SearchCategory name);
        List<CategoryViewModel> List();
        EditCategory GetDetails(long id);
        OperationResult Delete(long id);
        CategoryViewModel GetBy(long id);
    }
}
