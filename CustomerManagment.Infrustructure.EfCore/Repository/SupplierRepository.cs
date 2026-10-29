using _0_Framework.Infrastructure;
using CustomerManagment.Application.Contracts.Supplier;
using CustomerManagment.Domain.SupplierAgg;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagment.Infrustructure.EfCore.Repository
{
    public class SupplierRepository : ReposioryBase<long, Supplier>, ISupplierRepository
    {
        private readonly CustomerManagmentContext _context;

        public SupplierRepository(CustomerManagmentContext context) : base(context)
        {
            _context = context;
        }

        public SupplierViewModel GetBy(long id)
        {
            return _context.Suppliers
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Select(x => new SupplierViewModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.FirstName + "" +x.Customer.LastName,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                UnitPrice = x.UnitPrice,
                OverPrice = x.OverPrice,
                PriceDate = x.PriceDate,
                RentPrice = x.RentPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SupplierViewModel> List()
        {
            return _context.Suppliers
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Select(x => new SupplierViewModel
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FirstName + "" + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    UnitPrice = x.UnitPrice,
                    OverPrice = x.OverPrice,
                    PriceDate = x.PriceDate,
                    RentPrice = x.RentPrice
                }).ToList();
        }

        public List<SupplierViewModel> Search(SupplierSearchModel searchModel)
        {
            var query = _context.Suppliers
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Select(x => new SupplierViewModel
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FirstName + "" + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    UnitPrice = x.UnitPrice,
                    OverPrice = x.OverPrice,
                    PriceDate = x.PriceDate,
                    RentPrice = x.RentPrice
                });

            if(searchModel.CustomerId != 0)
                query = query.Where(x => x.CustomerId == searchModel.CustomerId);
            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.ToList();


        }
    }
}
