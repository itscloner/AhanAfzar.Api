using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.ProductBrand
{
    public interface IProductBrandApplication 
    {
        OperationResult Create(CreateProductBrand command);
        OperationResult Edit(EditProductBrand command);
        List<ProductBrandViewModel> Search(SearchProductBrand name);
        List<ProductBrandViewModel> List();
        EditProductBrand GetDetails(long id);
        OperationResult Delete(long id);
        ProductBrandViewModel GetBy(long id);
        ProductBrandViewModel GetProductBrand(long id);
    }
}
