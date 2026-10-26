using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.CustomerContact
{
    public interface ICustomerContactApplication
    {
        OperationResult Create(CreateCustomerContact command);
        OperationResult Edit(EditCustomerContact command);
        OperationResult Delete(long id);
        List<CustomerContactViewModel> List();
        CustomerContactViewModel GetBy(long id);
    }
}
