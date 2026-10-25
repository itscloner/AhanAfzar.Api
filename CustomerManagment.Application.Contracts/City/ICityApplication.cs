namespace CustomerManagment.Application.Contracts.City
{
    public interface ICityApplication
    {
        List<CityViewModel> List(long provinceId);
    }
}
