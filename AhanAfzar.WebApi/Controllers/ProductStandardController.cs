using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.ProductStandard;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStandardController : ControllerBase
    {
        private readonly IProductStandardApplication _productStandardApplication;

        public ProductStandardController(IProductStandardApplication productStandardApplication)
        {
            _productStandardApplication = productStandardApplication;
        }

        /// <summary>
        /// ایجاد استاندارد محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProductStandard([FromBody] CreateProductStandard command)
        {
            var result = _productStandardApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی استاندارد های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductStandardViewModel> GetAllProductStandard()
        {
            return _productStandardApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات استاندارد ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductStandardViewModel GetById([FromRoute] long id)
        {
            return _productStandardApplication.GetProductStandard(id);
        }
        /// <summary>
        /// ایجاد استاندارد محصول
        /// دریافت جزئیات استاندارد محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("StandardDetail/{id:long}")]
        public ProductStandardViewModel GetProductStandardById(long id)
        {
            return _productStandardApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProductStandard([FromBody] EditProductStandard command)
        {
            var result = _productStandardApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی استاندارد محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductStandard([FromRoute] long id)
        {
            var result = _productStandardApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
