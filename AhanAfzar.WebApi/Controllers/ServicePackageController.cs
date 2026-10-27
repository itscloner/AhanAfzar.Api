using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.ServicePackage;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackageController : ControllerBase
    {
        private readonly IServicePackageApplication _ServicePackageApplication;

        public ServicePackageController(IServicePackageApplication ServicePackageApplication)
        {
            _ServicePackageApplication = ServicePackageApplication;
        }

        /// <summary>
        /// ایجاد بسته های خدمت
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateServicePackage([FromBody] CreateServicePackage command)
        {
            var result = _ServicePackageApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی بسته های خدمت
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ServicePackageViewModel> GetAllServicePackage()
        {
            return _ServicePackageApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات بسته های خدمت براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ServicePackageViewModel GetById([FromRoute] long id)
        {
            return _ServicePackageApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد بسته های خدمت
        /// دریافت جزئیات بسته های خدمت براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ServicePackageDetail/{id:long}")]
        public ServicePackageViewModel GetServicePackageById(long id)
        {
            return _ServicePackageApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش بسته های خدمت
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditServicePackage([FromBody] EditServicePackage command)
        {
            var result = _ServicePackageApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی بسته های خدمت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteServicePackage([FromRoute] long id)
        {
            var result = _ServicePackageApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
