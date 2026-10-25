using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.Contact
{
    public interface IContactApplication
    {
        OperationResult Create(CreateContact command);
        OperationResult Edit(EditContact command);
        OperationResult Delete(long id);
        List<ContactViewModel> List();
        ContactViewModel GetBy(long id);
    }
}
