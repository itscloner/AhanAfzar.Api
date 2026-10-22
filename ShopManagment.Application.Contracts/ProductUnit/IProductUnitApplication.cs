using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.ProductUnit
{
    public interface IProductUnitApplication 
    {
        OperationResult Create(CreateProductUnit command);
        OperationResult Edit(EditProductUnit command);
        List<ProductUnitViewModel> Search(SearchProductUnit name);
        List<ProductUnitViewModel> List();
        EditProductUnit GetDetails(long id);
        OperationResult Delete(long id);
        ProductUnitViewModel GetBy(long id);
        ProductUnitViewModel GetProductUnit(long id);
    }
}
