using _0_Framework.Application;

using CustomerManagment.Application.Contracts.Company;
using CustomerManagment.Domain.CompanyAgg;

namespace CustomerManagment.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplication(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public OperationResult Create(CreateCompany command)
        {
            var operation = new OperationResult();
            var isExistCompany = _companyRepository.Exist(x => x.Name == command.Name && x.EconomicCode == command.EconomicCode);
            if (isExistCompany) return operation.Failed("شرکت با این نام و کد اقتصادی قبلا ثبت شده است");

            var company = new Company(command.Name, command.BrandName, command.NationalId, command.EconomicCode, command.Description);
            _companyRepository.Create(company);
            _companyRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var company = _companyRepository.Get(id);
            if (company == null) return operation.Failed("شرکت یافت نشد");

            company.IsDeleted = true;
            _companyRepository.SaveChanges();

            return operation.Succedded();   
        }

        public OperationResult Edit(EditCompany command)
        {
            var operation = new OperationResult();
            var company = _companyRepository.Get(command.Id);
            if (company == null) return operation.Failed("شرکت یافت نشد");

            company.Edit(command.Name, command.BrandName, command.NationalId, command.EconomicCode, command.Description);
            _companyRepository.SaveChanges();

            return operation.Succedded();

        }

        public CompanyViewModel GetBy(long id)
        {
            return _companyRepository.GetBy(id);
        }

        public List<CompanyViewModel> List()
        {
            return _companyRepository.List();
        }
    }
}
