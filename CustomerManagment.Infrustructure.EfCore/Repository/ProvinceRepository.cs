using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Province;
using CustomerManagment.Domain.ProvinceAgg;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class ProvinceRepository : ReposioryBase<long, Province>, IProvinceRepository
    {
        private readonly CustomerManagmentContext _context;

        public ProvinceRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }


        public List<ProvinceViewModel> List()
        {
            return _context.Provinces.Select(x => new ProvinceViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
            }).ToList();
        }
    }
}
