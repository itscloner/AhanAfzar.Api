using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.ProductStandard
{
    public interface IProductStandardApplication 
    {
        OperationResult Create(CreateProductStandard command);
        OperationResult Edit(EditProductStandard command);
        List<ProductStandardViewModel> Search(SearchProductStandard name);
        List<ProductStandardViewModel> List();
        EditProductStandard GetDetails(long id);
        OperationResult Delete(long id);
        ProductStandardViewModel GetBy(long id);
        ProductStandardViewModel GetProductStandard(long id);
    }
}
