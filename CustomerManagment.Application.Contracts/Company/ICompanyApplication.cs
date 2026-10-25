
using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.Company
{
    public interface ICompanyApplication
    {
        OperationResult Create(CreateCompany command);
        OperationResult Edit(EditCompany command);
        OperationResult Delete(long id);
        List<CompanyViewModel> List();
        CompanyViewModel GetBy(long id);

    }
}
