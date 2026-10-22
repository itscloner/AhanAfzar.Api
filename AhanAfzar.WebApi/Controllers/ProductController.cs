using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Product;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        /// <summary>
        /// ایجاد  محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProduct([FromBody] CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی  های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductViewModel> GetAllProduct()
        {
            return _productApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات  ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductViewModel GetById([FromRoute] long id)
        {
            return _productApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد  محصول
        /// دریافت جزئیات  محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Detail/{id:long}")]
        public ProductViewModel GetProductById(long id)
        {
            return _productApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProduct([FromBody] EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی  محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProduct([FromRoute] long id)
        {
            var result = _productApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
