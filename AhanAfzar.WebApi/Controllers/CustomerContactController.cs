using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.CustomerContact;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactController : ControllerBase
    {
        private readonly ICustomerContactApplication _CustomerContactApplication;

        public CustomerContactController(ICustomerContactApplication CustomerContactApplication)
        {
            _CustomerContactApplication = CustomerContactApplication;
        }

        /// <summary>
        /// ایجاد تلفن مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCustomerContact([FromBody] CreateCustomerContact command)
        {
            var result = _CustomerContactApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی تلفن مشتری
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustomerContactViewModel> GetAllCustomerContact()
        {
            return _CustomerContactApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات تلفن مشتری براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CustomerContactViewModel GetById([FromRoute] long id)
        {
            return _CustomerContactApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد تلفن مشتری
        /// دریافت جزئیات تلفن مشتری براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CustomerContactDetail/{id:long}")]
        public CustomerContactViewModel GetCustomerContactById(long id)
        {
            return _CustomerContactApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش تلفن مشتری
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCustomerContact([FromBody] EditCustomerContact command)
        {
            var result = _CustomerContactApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی تلفن مشتری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCustomerContact([FromRoute] long id)
        {
            var result = _CustomerContactApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
