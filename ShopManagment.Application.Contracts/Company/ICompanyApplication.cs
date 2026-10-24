using _0_Framework.Application;

namespace ShopManagment.Application.Contracts.Company
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
