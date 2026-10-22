using _0_Framework.Application;
using ShopManagment.Application.Contracts.Unit;
using ShopManagment.Domain.UnitAgg;

namespace ShopManagment.Application
{
    public class UnitApplication : IUnitApplication
    {
        private readonly IUnitRepository _UnitRepository;

        public UnitApplication(IUnitRepository UnitRepository)
        {
            _UnitRepository = UnitRepository;
        }

        public OperationResult Create(CreateUnit command)
        {
            var operation = new OperationResult();
            if (_UnitRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var Unit = new Unit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _UnitRepository.Create(Unit);
            _UnitRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var Unit = _UnitRepository.Get(id);

            if (Unit == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            Unit.IsDeleted = true;
            _UnitRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditUnit command)
        {
            var operation = new OperationResult();
            var Unit = _UnitRepository.Get(command.Id);

            if (Unit == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            if (_UnitRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            Unit.Edit(command.Name, command.Description,  command.Keyword,
                command.MetaDescription, command.Slug);

            _UnitRepository.SaveChanges();

            return operation.Succedded();
        }

        public UnitViewModel GetBy(long id)
        {
            return _UnitRepository.GetBy(id);
        }

        public EditUnit GetDetails(long id)
        {
            return _UnitRepository.GetDetails(id);
        }

        public UnitViewModel GetUnit(long id)
        {
            return _UnitRepository.GetBy(id);
        }

        public List<UnitViewModel> List()
        {
            return _UnitRepository.List();
        }

        public List<UnitViewModel> Search(SearchUnit name)
        {
            return _UnitRepository.Search(name.Name);
        }

    }
}
