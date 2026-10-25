namespace CustomerManagment.Application.Contracts.Address
{
    public class CreateAddress
    {
        public string Title { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
        public long ProvinceId { get; set; }
        public long CityId { get; set; }
    }
}
