using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Brand
{
    public interface IBrandApplication 
    {
        OperationResult Create(CreateBrand command);
        OperationResult Edit(EditBrand command);
        List<BrandViewModel> Search(SearchBrand name);
        List<BrandViewModel> List();
        EditBrand GetDetails(long id);
        OperationResult Delete(long id);
        BrandViewModel GetBy(long id);
    }
}
