using _0_Framework.Domain;
using CustomerManagment.Application.Contracts.Supplier;

namespace CustomerManagment.Domain.SupplierAgg
{
    public interface ISupplierRepository : IRepository<long, Supplier>
    {
        List<SupplierViewModel> List();
        SupplierViewModel GetBy(long id);
        List<SupplierViewModel> Search(SupplierSearchModel searchModel);
    }
}
