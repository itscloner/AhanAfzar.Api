using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.ProductBrand;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandApplication _productBrandApplication;

        public ProductBrandController(IProductBrandApplication productBrandApplication)
        {
            _productBrandApplication = productBrandApplication;
        }

        /// <summary>
        /// ایجاد برند محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProductBrand([FromBody] CreateProductBrand command)
        {
            var result = _productBrandApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی برند های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductBrandViewModel> GetAllProductBrand()
        {
            return _productBrandApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات برند ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductBrandViewModel GetById([FromRoute] long id)
        {
            return _productBrandApplication.GetProductBrand(id);
        }
        /// <summary>
        /// ایجاد برند محصول
        /// دریافت جزئیات برند محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BrandDetail/{id:long}")]
        public ProductBrandViewModel GetProductBrandById(long id)
        {
            return _productBrandApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProductBrand([FromBody] EditProductBrand command)
        {
            var result = _productBrandApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی برند محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductBrand([FromRoute] long id)
        {
            var result = _productBrandApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
