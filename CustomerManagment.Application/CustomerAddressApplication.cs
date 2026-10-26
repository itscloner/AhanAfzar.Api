using _0_Framework.Application;
using CustomerManagment.Application.Contracts.CustomerAddress;
using CustomerManagment.Domain.CusromerAddressAgg;

namespace CustomerManagment.Application
{
    public class CustomerAddressApplication : ICustomerAddressApplication
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CustomerAddressApplication(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }

        public OperationResult Create(CreateCustomerAddress command)
        {
            var operation = new OperationResult();
            var isExistCustomerAddress = _customerAddressRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.AddressId == command.AddressId);
            if (isExistCustomerAddress) return operation.Failed("آدرس مشتری قبلا ثبت شده است");

            var customerAddress = new CustomerAddress(command.CustomerId, command.AddressId);
            _customerAddressRepository.Create(customerAddress);
            _customerAddressRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var customerAddress = _customerAddressRepository.Get(id);
            if (customerAddress == null) return operation.Failed("رکورد یافت نشد");

            customerAddress.IsDeleted = true;
            _customerAddressRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerAddress command)
        {
            var operation = new OperationResult();
            var customerAddress = _customerAddressRepository.Get(command.Id);
            if (customerAddress == null) return operation.Failed("رکورد یافت نشد");

            var isExistCustomerAddress = _customerAddressRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.AddressId == command.AddressId);
            if (isExistCustomerAddress) return operation.Failed("آدرس مشتری قبلا ثبت شده است");

            customerAddress.Edit(command.CustomerId, command.AddressId);
            _customerAddressRepository.SaveChanges();

            return operation.Succedded();

        }

        public CustomerAddressViewModel GetBy(long id)
        {
            return _customerAddressRepository.GetBy(id);
        }

        public List<CustomerAddressViewModel> List()
        {
            return _customerAddressRepository.List();
        }
    }
}
