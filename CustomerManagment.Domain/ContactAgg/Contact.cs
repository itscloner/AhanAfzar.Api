using _0_Framework.Domain;
using CustomerManagment.Domain.CusromerContactAgg;

namespace CustomerManagment.Domain.ContactAgg
{
    public class Contact : EntityBase<long>
    {
        public string Title { get; set; }
        public string Phone { get; set; }
        public ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();

        public Contact(string title, string phone)
        {
            Title = title;
            Phone = phone;
        }

        public void Edit(string title, string phone)
        {
            Title = title;
            Phone = phone;
        }
    }
}
