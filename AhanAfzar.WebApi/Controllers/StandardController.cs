using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Standard;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly IStandardApplication _StandardApplication;

        public StandardController(IStandardApplication StandardApplication)
        {
            _StandardApplication = StandardApplication;
        }

        /// <summary>
        /// ایجاد استاندارد محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateStandard([FromBody] CreateStandard command)
        {
            var result = _StandardApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی استاندارد های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<StandardViewModel> GetAllStandard()
        {
            return _StandardApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات استاندارد ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public StandardViewModel GetById([FromRoute] long id)
        {
            return _StandardApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد استاندارد محصول
        /// دریافت جزئیات استاندارد محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("StandardDetail/{id:long}")]
        public StandardViewModel GetStandardById(long id)
        {
            return _StandardApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditStandard([FromBody] EditStandard command)
        {
            var result = _StandardApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی استاندارد محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteStandard([FromRoute] long id)
        {
            var result = _StandardApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
