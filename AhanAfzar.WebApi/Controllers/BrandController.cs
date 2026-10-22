using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Brand;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandApplication _brandApplication;

        public BrandController(IBrandApplication BrandApplication)
        {
            _brandApplication = BrandApplication;
        }

        /// <summary>
        /// ایجاد برند محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateBrand([FromBody] CreateBrand command)
        {
            var result = _brandApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی برند های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<BrandViewModel> GetAllBrand()
        {
            return _brandApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات برند ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public BrandViewModel GetById([FromRoute] long id)
        {
            return _brandApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد برند محصول
        /// دریافت جزئیات برند محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BrandDetail/{id:long}")]
        public BrandViewModel GetBrandById(long id)
        {
            return _brandApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditBrand([FromBody] EditBrand command)
        {
            var result = _brandApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی برند محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteBrand([FromRoute] long id)
        {
            var result = _brandApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
