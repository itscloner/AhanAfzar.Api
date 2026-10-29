using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.Supplier
{
    public interface ISupplierApplication
    {
        OperationResult Create(CreateSupplier command);
        OperationResult Edit(EditSupplier command);
        OperationResult Delete(long id);
        List<SupplierViewModel> List();
        SupplierViewModel GetBy(long id);
        List<SupplierViewModel> Search(SupplierSearchModel searchModel);

    }
}
