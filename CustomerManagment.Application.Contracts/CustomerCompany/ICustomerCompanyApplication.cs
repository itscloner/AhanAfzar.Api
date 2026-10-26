using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.CustomerCompany
{
    public interface ICustomerCompanyApplication
    {
        OperationResult Create(CreateCustomerCompany command);
        OperationResult Edit(EditCustomerCompany command);
        OperationResult Delete(long id);
        List<CustomerCompanyViewModel> List();
        CustomerCompanyViewModel GetBy(long id);
    }
}
