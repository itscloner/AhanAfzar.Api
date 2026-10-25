using Microsoft.AspNetCore.Mvc;
using CustomerManagment.Application.Contracts.Contact;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactApplication _ContactApplication;

        public ContactController(IContactApplication ContactApplication)
        {
            _ContactApplication = ContactApplication;
        }

        /// <summary>
        /// ایجاد تلفن
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateContact([FromBody] CreateContact command)
        {
            var result = _ContactApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی تلفن
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ContactViewModel> GetAllContact()
        {
            return _ContactApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات تلفن براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ContactViewModel GetById([FromRoute] long id)
        {
            return _ContactApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد تلفن
        /// دریافت جزئیات تلفن براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ContactDetail/{id:long}")]
        public ContactViewModel GetContactById(long id)
        {
            return _ContactApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش تلفن
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditContact([FromBody] EditContact command)
        {
            var result = _ContactApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی تلفن
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteContact([FromRoute] long id)
        {
            var result = _ContactApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
