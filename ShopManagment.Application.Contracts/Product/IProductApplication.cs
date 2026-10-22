using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        List<ProductViewModel> Search(SearchProduct command);
        List<ProductViewModel> List();
        OperationResult Delete(long id);
        ProductViewModel GetBy(long id);
    }
}
