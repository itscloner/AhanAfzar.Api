using _0_Framework.Application;
using CustomerManagment.Application.Contracts.CustomerCompany;
using CustomerManagment.Domain.CusromerCompanyAgg;

namespace CustomerManagment.Application
{
    public class CustomerCompanyApplication : ICustomerCompanyApplication
    {
        private readonly ICustomerCompanyRepository _customerCompanyRepository;

        public CustomerCompanyApplication(ICustomerCompanyRepository customerCompanyRepository)
        {
            _customerCompanyRepository = customerCompanyRepository;
        }

        public OperationResult Create(CreateCustomerCompany command)
        {
            var operation = new OperationResult();
            var isExistCustomerCompany = _customerCompanyRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.CompanyId == command.CompanyId);
            if (isExistCustomerCompany) return operation.Failed("شرکت مشتری قبلا ثبت شده است");

            var customerCompany = new CustomerCompany(command.CustomerId, command.CompanyId);
            _customerCompanyRepository.Create(customerCompany);
            _customerCompanyRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var customerCompany = _customerCompanyRepository.Get(id);
            if (customerCompany == null) return operation.Failed("رکورد یافت نشد");

            customerCompany.IsDeleted = true;
            _customerCompanyRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerCompany command)
        {
            var operation = new OperationResult();
            var customerCompany = _customerCompanyRepository.Get(command.Id);
            if (customerCompany == null) return operation.Failed("رکورد یافت نشد");

            var isExistCustomerCompany = _customerCompanyRepository.Exist(x => x.CustomerId == command.CustomerId &&
            x.CompanyId == command.CompanyId);
            if (isExistCustomerCompany) return operation.Failed("شرکت مشتری قبلا ثبت شده است");

            customerCompany.Edit(command.CustomerId, command.CompanyId);
            _customerCompanyRepository.SaveChanges();

            return operation.Succedded();

        }

        public CustomerCompanyViewModel GetBy(long id)
        {
            return _customerCompanyRepository.GetBy(id);
        }

        public List<CustomerCompanyViewModel> List()
        {
            return _customerCompanyRepository.List();
        }
    }
}
