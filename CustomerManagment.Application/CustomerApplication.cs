using _0_Framework.Application;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Domain.CustomerAgg;

namespace CustomerManagment.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerApplication(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public OperationResult Create(CreateCustomer command)
        {
            var operation = new OperationResult();
            var isExistCustomer = _customerRepository.Exist(x =>
            x.FirstName == command.FirstName &&
            x.LastName == command.LastName &&
            x.NationalCode == command.NationalCode);

            if (isExistCustomer) return operation.Failed("مشتری با این اطلاعات قبلا ثبت شده است");

            var customer = new Customer(command.FirstName, command.LastName, command.Description,
                command.NationalCode, command.CustomerType);

            _customerRepository.Create(customer);
            _customerRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var customer = _customerRepository.Get(id);

            if (customer == null) return operation.Failed("رکورد یافت نشد");
            customer.IsDeleted = true;
            _customerRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomer command)
        {
            var operation = new OperationResult();
            var customer = _customerRepository.Get(command.Id);

            if (customer == null) return operation.Failed("رکورد یافت نشد");

            customer.Edit(command.FirstName, command.LastName, command.Description,
                command.NationalCode, command.CustomerType);

            _customerRepository.SaveChanges();

            return operation.Succedded();
        }

        public CustomerViewModel GetBy(long id)
        {
            return _customerRepository.GetBy(id);
        }

        public List<CustomerViewModel> List()
        {
            return _customerRepository.List();
        }
    }
}
