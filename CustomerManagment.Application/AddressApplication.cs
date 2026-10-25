using _0_Framework.Application;
using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Domain.AddressAgg;

namespace CustomerManagment.Application
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IAddressRepository _addressRepository;

        public AddressApplication(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public OperationResult Create(CreateAddress command)
        {
            var operation = new OperationResult();
            var address = new Address(command.Title, command.FullAddress, command.PostalCode, command.ProvinceId, command.CityId);

            _addressRepository.Create(address);
            _addressRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var address = _addressRepository.Get(id);
            if(address == null) return operation.Failed("رکورد یافت نشد");

            address.IsDeleted = true;
            _addressRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditAddress command)
        {
            var operation = new OperationResult();
            var address = _addressRepository.Get(command.Id);
            if (address == null) return operation.Failed("رکورد یافت نشد");

            address.Edit(command.Title, command.FullAddress, command.PostalCode, command.ProvinceId, command.CityId);
            _addressRepository.SaveChanges();

            return operation.Succedded();

        }

        public AddressViewModel GetBy(long id)
        {
            return _addressRepository.GetBy(id);    
        }

        public List<AddressViewModel> List()
        {
            return _addressRepository.List();   
        }
    }
}
