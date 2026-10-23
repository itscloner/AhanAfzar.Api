using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Unit;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitApplication _UnitApplication;

        public UnitController(IUnitApplication UnitApplication)
        {
            _UnitApplication = UnitApplication;
        }

        /// <summary>
        /// ایجاد واحد محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateUnit([FromBody] CreateUnit command)
        {
            var result = _UnitApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی واحد های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UnitViewModel> GetAllUnit()
        {
            return _UnitApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات واحد ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public UnitViewModel GetById([FromRoute] long id)
        {
            return _UnitApplication.GetUnit(id);
        }
        /// <summary>
        /// ایجاد واحد محصول
        /// دریافت جزئیات واحد محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UnitDetail/{id:long}")]
        public UnitViewModel GetUnitById(long id)
        {
            return _UnitApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditUnit([FromBody] EditUnit command)
        {
            var result = _UnitApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی واحد محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteUnit([FromRoute] long id)
        {
            var result = _UnitApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
