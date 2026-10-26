using _0_Framework.Domain;
using CustomerManagment.Domain.CompanyAgg;
using CustomerManagment.Domain.CustomerAgg;

namespace CustomerManagment.Domain.CusromerCompanyAgg
{
    public class CustomerCompany : EntityBase<long>
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public CustomerCompany(long customerId, long companyId)
        {
            CustomerId = customerId;
            CompanyId = companyId;
        }
        public void Edit(long customerId, long companyId)
        {
            CustomerId = customerId;
            CompanyId = companyId;
        }
    }
}
