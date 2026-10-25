using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Customer;
using CustomerManagment.Domain.CustomerAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CustomerRepository : ReposioryBase<long, Customer>, ICustomerRepository
    {
        private readonly CustomerManagmentContext _context;

        public CustomerRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public CustomerViewModel GetBy(long id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerViewModel> List()
        {
            throw new NotImplementedException();
        }
    }
}
