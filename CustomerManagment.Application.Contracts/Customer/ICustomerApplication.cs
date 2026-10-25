using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.Customer
{
    public interface ICustomerApplication
    {
        OperationResult Create(CreateCustomer command);
        OperationResult Edit(EditCustomer command);
        OperationResult Delete(long id);
        List<CustomerViewModel> List();
        CustomerViewModel GetBy(long id);
 
    }
}
