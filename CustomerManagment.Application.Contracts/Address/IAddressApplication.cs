using _0_Framework.Application;

namespace CustomerManagment.Application.Contracts.Address
{
    public interface IAddressApplication
    {
        OperationResult Create(CreateAddress command);
        OperationResult Edit(EditAddress command);
        OperationResult Delete(long id);
        List<AddressViewModel> List();
        AddressViewModel GetBy(long id);
    }
}
