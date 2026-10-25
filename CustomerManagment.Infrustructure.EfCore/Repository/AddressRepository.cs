using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Address;
using CustomerManagment.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class AddressRepository : ReposioryBase<long, Address>, IAddressRepository
    {
        private readonly CustomerManagmentContext _context;

        public AddressRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public AddressViewModel GetBy(long id)
        {
            return _context.Addresses
                .Include(x => x.Province)
                .Include(x => x.City)
                .Select(x => new AddressViewModel
            {
                Id = x.Id,
                Title = x.Title,
                FullAddress = x.FullAddress,
                PostalCode = x.PostalCode,
                ProvinceName = x.Province.Name,
                CityName = x.City.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AddressViewModel> List()
        {
            return _context.Addresses
                .Include(x => x.Province)
                .Include(x => x.City)
                .Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FullAddress = x.FullAddress,
                    PostalCode = x.PostalCode,
                    ProvinceName = x.Province.Name,
                    CityName = x.City.Name,
                }).ToList();
        }
    }
}
