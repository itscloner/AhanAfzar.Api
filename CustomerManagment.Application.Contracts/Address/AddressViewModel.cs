namespace CustomerManagment.Application.Contracts.Address
{
    public class AddressViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
    } 
}
