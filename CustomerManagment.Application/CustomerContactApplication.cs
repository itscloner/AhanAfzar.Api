using _0_Framework.Application;
using CustomerManagment.Application.Contracts.CustomerContact;
using CustomerManagment.Domain.CusromerContactAgg;

namespace CustomerManagment.Application
{
    public class CustomerContactApplication : ICustomerContactApplication
    {
        private readonly ICustomerContactRepository _customerContactRepository;

        public CustomerContactApplication(ICustomerContactRepository customerContactRepository)
        {
            _customerContactRepository = customerContactRepository;
        }

        public OperationResult Create(CreateCustomerContact command)
        {
            var operation = new OperationResult();
            var isExistCustomerContact = _customerContactRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.ContactId == command.ContactId);
            if (isExistCustomerContact) return operation.Failed("تلفن مشتری قبلا ثبت شده است");

            var customerContact = new CustomerContact(command.CustomerId, command.ContactId);
            _customerContactRepository.Create(customerContact);
            _customerContactRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var customerContact = _customerContactRepository.Get(id);
            if (customerContact == null) return operation.Failed("رکورد یافت نشد");

            customerContact.IsDeleted = true;
            _customerContactRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerContact command)
        {
            var operation = new OperationResult();
            var customerContact = _customerContactRepository.Get(command.Id);
            if (customerContact == null) return operation.Failed("رکورد یافت نشد");

            var isExistCustomerContact = _customerContactRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.ContactId == command.ContactId);
            if (isExistCustomerContact) return operation.Failed("تلفن مشتری قبلا ثبت شده است");

            customerContact.Edit(command.CustomerId, command.ContactId);
            _customerContactRepository.SaveChanges();

            return operation.Succedded();

        }

        public CustomerContactViewModel GetBy(long id)
        {
            return _customerContactRepository.GetBy(id);
        }

        public List<CustomerContactViewModel> List()
        {
            return _customerContactRepository.List();
        }
    }
}
