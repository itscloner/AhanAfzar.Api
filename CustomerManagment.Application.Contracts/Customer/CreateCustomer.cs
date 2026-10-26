using CustomerManagment.Application.Contracts.Province;

namespace CustomerManagment.Application.Contracts.Customer
{
    public class CreateCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string NationalCode { get; set; }
        public int CustomerType { get; set; }

    }
}
