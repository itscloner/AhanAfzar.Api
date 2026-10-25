using _0_Framework.Application;
using CustomerManagment.Application.Contracts.Contact;
using CustomerManagment.Domain.ContactAgg;

namespace CustomerManagment.Application
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactRepository _ContactRepository;

        public ContactApplication(IContactRepository ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public OperationResult Create(CreateContact command)
        {
            var operation = new OperationResult();
            var Contact = new Contact(command.Title, command.Phone);

            _ContactRepository.Create(Contact);
            _ContactRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var Contact = _ContactRepository.Get(id);
            if(Contact == null) return operation.Failed("رکورد یافت نشد");

            Contact.IsDeleted = true;
            _ContactRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditContact command)
        {
            var operation = new OperationResult();
            var Contact = _ContactRepository.Get(command.Id);
            if (Contact == null) return operation.Failed("رکورد یافت نشد");

            Contact.Edit(command.Title, command.Phone);
            _ContactRepository.SaveChanges();

            return operation.Succedded();

        }

        public ContactViewModel GetBy(long id)
        {
            return _ContactRepository.GetBy(id);    
        }

        public List<ContactViewModel> List()
        {
            return _ContactRepository.List();   
        }
    }
}
