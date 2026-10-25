using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.Address;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressApplication _AddressApplication;

        public AddressController(IAddressApplication AddressApplication)
        {
            _AddressApplication = AddressApplication;
        }

        /// <summary>
        /// ایجاد آدرس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateAddress([FromBody] CreateAddress command)
        {
            var result = _AddressApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی آدرس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AddressViewModel> GetAllAddress()
        {
            return _AddressApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات آدرس براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public AddressViewModel GetById([FromRoute] long id)
        {
            return _AddressApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد آدرس
        /// دریافت جزئیات آدرس براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("AddressDetail/{id:long}")]
        public AddressViewModel GetAddressById(long id)
        {
            return _AddressApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش آدرس
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditAddress([FromBody] EditAddress command)
        {
            var result = _AddressApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی آدرس
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteAddress([FromRoute] long id)
        {
            var result = _AddressApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
