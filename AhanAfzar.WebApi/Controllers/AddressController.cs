using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.Supplier;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierApplication _SupplierApplication;

        public SupplierController(ISupplierApplication SupplierApplication)
        {
            _SupplierApplication = SupplierApplication;
        }

        /// <summary>
        /// ایجاد تامین کننده
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateSupplier([FromBody] CreateSupplier command)
        {
            var result = _SupplierApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی تامین کننده
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SupplierViewModel> GetAllSupplier(SupplierSearchModel searchModel)
        {
            return _SupplierApplication.Search(searchModel);
        }
        /// <summary>
        /// دریافت جزئیات تامین کننده براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public SupplierViewModel GetById([FromRoute] long id)
        {
            return _SupplierApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد تامین کننده
        /// دریافت جزئیات تامین کننده براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("SupplierDetail/{id:long}")]
        public SupplierViewModel GetSupplierById(long id)
        {
            return _SupplierApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش تامین کننده
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditSupplier([FromBody] EditSupplier command)
        {
            var result = _SupplierApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی تامین کننده
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteSupplier([FromRoute] long id)
        {
            var result = _SupplierApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
