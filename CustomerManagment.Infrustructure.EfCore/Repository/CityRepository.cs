using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.City;
using CustomerManagment.Domain.CityAgg;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class CityRepository : ReposioryBase<long, City>, ICityRepository
    {
        private readonly CustomerManagmentContext _context;

        public CityRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public List<CityViewModel> List(long provinceId)
        {
            return _context.Cities
                .Where(x => x.ProvinceId == provinceId)
                .Include(x => x.Province)
                .Select(x => new CityViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ProvinceId = x.ProvinceId
            }).ToList();
        }
    }
}
