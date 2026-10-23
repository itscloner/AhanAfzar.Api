using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.ProductBrand;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandApplication _ProductBrandApplication;

        public ProductBrandController(IProductBrandApplication ProductBrandApplication)
        {
            _ProductBrandApplication = ProductBrandApplication;
        }

        /// <summary>
        /// ایجاد  کالابرند
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProductBrand([FromBody] CreateProductBrand command)
        {
            var result = _ProductBrandApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی  های کالابرند
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductBrandViewModel> GetAllProductBrand()
        {
            return _ProductBrandApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات  ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductBrandViewModel GetById([FromRoute] long id)
        {
            return _ProductBrandApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد  کالابرند
        /// دریافت جزئیات  کالابرند براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Detail/{id:long}")]
        public ProductBrandViewModel GetProductBrandById(long id)
        {
            return _ProductBrandApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته کالابرند
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProductBrand([FromBody] EditProductBrand command)
        {
            var result = _ProductBrandApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی  کالابرند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductBrand([FromRoute] long id)
        {
            var result = _ProductBrandApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
