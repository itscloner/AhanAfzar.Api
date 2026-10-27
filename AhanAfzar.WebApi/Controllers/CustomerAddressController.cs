using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.CustomerAddress;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressApplication _CustomerAddressApplication;

        public CustomerAddressController(ICustomerAddressApplication CustomerAddressApplication)
        {
            _CustomerAddressApplication = CustomerAddressApplication;
        }

        /// <summary>
        /// ایجاد آدرس مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCustomerAddress([FromBody] CreateCustomerAddress command)
        {
            var result = _CustomerAddressApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی آدرس مشتری
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustomerAddressViewModel> GetAllCustomerAddress()
        {
            return _CustomerAddressApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات آدرس مشتری براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CustomerAddressViewModel GetById([FromRoute] long id)
        {
            return _CustomerAddressApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد آدرس مشتری
        /// دریافت جزئیات آدرس مشتری براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CustomerAddressDetail/{id:long}")]
        public CustomerAddressViewModel GetCustomerAddressById(long id)
        {
            return _CustomerAddressApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش آدرس مشتری
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCustomerAddress([FromBody] EditCustomerAddress command)
        {
            var result = _CustomerAddressApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی آدرس مشتری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCustomerAddress([FromRoute] long id)
        {
            var result = _CustomerAddressApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
