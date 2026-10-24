using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Company;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyApplication _CompanyApplication;

        public CompanyController(ICompanyApplication CompanyApplication)
        {
            _CompanyApplication = CompanyApplication;
        }

        /// <summary>
        /// ایجاد شرکت
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCompany([FromBody] CreateCompany command)
        {
            var result = _CompanyApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی شرکت
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CompanyViewModel> GetAllCompany()
        {
            return _CompanyApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات شرکت ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CompanyViewModel GetById([FromRoute] long id)
        {
            return _CompanyApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد شرکت
        /// دریافت جزئیات شرکت براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CompanyDetail/{id:long}")]
        public CompanyViewModel GetCompanyById(long id)
        {
            return _CompanyApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCompany([FromBody] EditCompany command)
        {
            var result = _CompanyApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی شرکت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCompany([FromRoute] long id)
        {
            var result = _CompanyApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
