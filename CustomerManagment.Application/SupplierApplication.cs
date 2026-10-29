using _0_Framework.Application;
using CustomerManagment.Application.Contracts.Supplier;
using CustomerManagment.Domain.SupplierAgg;

namespace CustomerManagment.Application
{
    public class SupplierApplication : ISupplierApplication
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierApplication(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public OperationResult Create(CreateSupplier command)
        {
            var operation = new OperationResult();
            var supplier = _supplierRepository.Exist(x => x.CustomerId == command.CustomerId && x.ProductId == command.ProductId);
            if (supplier) return operation.Failed("رکورد تکراری می باشد");

            var createSupplier = new Supplier(command.CustomerId, command.ProductId, command.UnitPrice, 
                command.RentPrice, command.OverPrice, command.PriceDate);
            _supplierRepository.Create(createSupplier);
            _supplierRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var supplier = _supplierRepository.Get(id);
            if (supplier == null) return operation.Failed("رکورد یافت نشد");

            supplier.IsDeleted = true;
            _supplierRepository.SaveChanges();

            return operation.Succedded();   
        }

        public OperationResult Edit(EditSupplier command)
        {
            var operation = new OperationResult();
            var supplier = _supplierRepository.Get(command.Id);
            if (supplier == null) return operation.Failed("رکورد یافت نشد");

            var supplierIsExit = _supplierRepository.Exist(x => x.CustomerId == command.CustomerId && x.ProductId == command.ProductId);
            if (supplierIsExit) return operation.Failed("رکورد تکراری می باشد");

            supplier.Edit(command.CustomerId, command.ProductId, command.UnitPrice,
                command.RentPrice, command.OverPrice, command.PriceDate);

            _supplierRepository.SaveChanges();

            return operation.Succedded();   

        }

        public SupplierViewModel GetBy(long id)
        {
            return _supplierRepository.GetBy(id);
        }

        public List<SupplierViewModel> List()
        {
            return _supplierRepository.List();
        }

        public List<SupplierViewModel> Search(SupplierSearchModel searchModel)
        {
            return _supplierRepository.Search(searchModel);
        }
    }
}
