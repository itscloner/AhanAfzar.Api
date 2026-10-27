using _0_Framework.Infrastructure;
using ShopManagment.Application.Contracts.ServicePackage;
using ShopManagment.Domain.ServicePackageAgg;

namespace ShopManagment.Infrustructure.EfCore.Repository
{
    public class ServicePackageRepository : ReposioryBase<long, ServicePackage>, IServicePackageRepository
    {
        private readonly ShopManagmentContext _context;

        public ServicePackageRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ServicePackageViewModel GetBy(long id)
        {
            return _context.ServicePackages.Select(x => new ServicePackageViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ServicePackageViewModel> List()
        {
            return _context.ServicePackages.Select(x => new ServicePackageViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToList();
        }
    }
}
