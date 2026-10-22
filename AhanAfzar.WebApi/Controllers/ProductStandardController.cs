using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.ProductUnit;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private readonly IProductUnitApplication _productUnitApplication;

        public ProductUnitController(IProductUnitApplication productUnitApplication)
        {
            _productUnitApplication = productUnitApplication;
        }

        /// <summary>
        /// ایجاد استاندارد محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProductUnit([FromBody] CreateProductUnit command)
        {
            var result = _productUnitApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی استاندارد های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductUnitViewModel> GetAllProductUnit()
        {
            return _productUnitApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات استاندارد ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductUnitViewModel GetById([FromRoute] long id)
        {
            return _productUnitApplication.GetProductUnit(id);
        }
        /// <summary>
        /// ایجاد استاندارد محصول
        /// دریافت جزئیات استاندارد محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UnitDetail/{id:long}")]
        public ProductUnitViewModel GetProductUnitById(long id)
        {
            return _productUnitApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProductUnit([FromBody] EditProductUnit command)
        {
            var result = _productUnitApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی استاندارد محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductUnit([FromRoute] long id)
        {
            var result = _productUnitApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
