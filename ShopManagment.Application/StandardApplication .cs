using _0_Framework.Application;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Domain.StandardAgg;

namespace ShopManagment.Application
{
    public class StandardApplication : IStandardApplication
    {
        private readonly IStandardRepository _productStandardRepository;

        public StandardApplication(IStandardRepository productStandardRepository)
        {
            _productStandardRepository = productStandardRepository;
        }

        public OperationResult Create(CreateStandard command)
        {
            var operation = new OperationResult();
            if (_productStandardRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productStandard = new Standard(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productStandardRepository.Create(productStandard);
            _productStandardRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productStandard = _productStandardRepository.Get(id);

            if (productStandard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productStandard.IsDeleted = true;
            _productStandardRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditStandard command)
        {
            var operation = new OperationResult();
            var productStandard = _productStandardRepository.Get(command.Id);

            if (productStandard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_productStandardRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productStandard.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _productStandardRepository.SaveChanges();

            return operation.Succedded();
        }

        public StandardViewModel GetBy(long id)
        {
            return _productStandardRepository.GetBy(id);
        }

        public EditStandard GetDetails(long id)
        {
            return _productStandardRepository.GetDetails(id);
        }

        public StandardViewModel GetProductStandard(long id)
        {
            return _productStandardRepository.GetBy(id);
        }

        public List<StandardViewModel> List()
        {
            return _productStandardRepository.List();
        }

        public List<StandardViewModel> Search(SearchStandard name)
        {
            return _productStandardRepository.Search(name.Name);
        }

    }
}
