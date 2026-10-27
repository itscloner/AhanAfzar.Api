using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.Customer;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _CustomerApplication;

        public CustomerController(ICustomerApplication CustomerApplication)
        {
            _CustomerApplication = CustomerApplication;
        }

        /// <summary>
        /// ایجاد مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCustomer([FromBody] CreateCustomer command)
        {
            var result = _CustomerApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی مشتری
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustomerViewModel> GetAllCustomer()
        {
            return _CustomerApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات مشتری براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CustomerViewModel GetById([FromRoute] long id)
        {
            return _CustomerApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد مشتری
        /// دریافت جزئیات مشتری براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CustomerDetail/{id:long}")]
        public CustomerViewModel GetCustomerById(long id)
        {
            return _CustomerApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش مشتری
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCustomer([FromBody] EditCustomer command)
        {
            var result = _CustomerApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی مشتری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCustomer([FromRoute] long id)
        {
            var result = _CustomerApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
