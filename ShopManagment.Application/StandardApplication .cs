using _0_Framework.Application;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Domain.StandardAgg;

namespace ShopManagment.Application
{
    public class StandardApplication : IStandardApplication
    {
        private readonly IStandardRepository _standardRepository;

        public StandardApplication(IStandardRepository standardRepository)
        {
            _standardRepository = standardRepository;
        }

        public OperationResult Create(CreateStandard command)
        {
            var operation = new OperationResult();
            if (_standardRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var standard = new Standard(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _standardRepository.Create(standard);
            _standardRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var standard = _standardRepository.Get(id);

            if (standard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            standard.IsDeleted = true;
            _standardRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditStandard command)
        {
            var operation = new OperationResult();
            var standard = _standardRepository.Get(command.Id);

            if (standard == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_standardRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            standard.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _standardRepository.SaveChanges();

            return operation.Succedded();
        }

        public StandardViewModel GetBy(long id)
        {
            return _standardRepository.GetBy(id);
        }

        public EditStandard GetDetails(long id)
        {
            return _standardRepository.GetDetails(id);
        }

        public List<StandardViewModel> List()
        {
            return _standardRepository.List();
        }

        public List<StandardViewModel> Search(SearchStandard name)
        {
            return _standardRepository.Search(name.Name);
        }

    }
}
