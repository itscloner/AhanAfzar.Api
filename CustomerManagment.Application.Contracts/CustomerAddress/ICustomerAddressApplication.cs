using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.CustomerAddress
{
    public interface ICustomerAddressApplication
    {
        OperationResult Create(CreateCustomerAddress command);
        OperationResult Edit(EditCustomerAddress command);
        OperationResult Delete(long id);
        List<CustomerAddressViewModel> List();
        CustomerAddressViewModel GetBy(long id);
    }
}
