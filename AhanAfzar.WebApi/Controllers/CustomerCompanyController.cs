using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.CustomerCompany;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCompanyController : ControllerBase
    {
        private readonly ICustomerCompanyApplication _CustomerCompanyApplication;

        public CustomerCompanyController(ICustomerCompanyApplication CustomerCompanyApplication)
        {
            _CustomerCompanyApplication = CustomerCompanyApplication;
        }

        /// <summary>
        /// ایجاد شرکت مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCustomerCompany([FromBody] CreateCustomerCompany command)
        {
            var result = _CustomerCompanyApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی شرکت مشتری
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustomerCompanyViewModel> GetAllCustomerCompany()
        {
            return _CustomerCompanyApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات شرکت مشتری براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CustomerCompanyViewModel GetById([FromRoute] long id)
        {
            return _CustomerCompanyApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد شرکت مشتری
        /// دریافت جزئیات شرکت مشتری براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CustomerCompanyDetail/{id:long}")]
        public CustomerCompanyViewModel GetCustomerCompanyById(long id)
        {
            return _CustomerCompanyApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش شرکت مشتری
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCustomerCompany([FromBody] EditCustomerCompany command)
        {
            var result = _CustomerCompanyApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی شرکت مشتری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCustomerCompany([FromRoute] long id)
        {
            var result = _CustomerCompanyApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
