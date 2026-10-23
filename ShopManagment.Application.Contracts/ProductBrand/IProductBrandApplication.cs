using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.ProductBrand
{
    public interface IProductBrandApplication
    {
        OperationResult Create(CreateProductBrand command);
        OperationResult Edit(EditProductBrand command);
        List<ProductBrandViewModel> List();
        OperationResult Delete(long id);
        ProductBrandViewModel GetBy(long id);
    }
}
