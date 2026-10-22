using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.Contracts.Category;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication CategoryApplication)
        {
            _categoryApplication = CategoryApplication;
        }

        /// <summary>
        /// ایجاد دسته بندی محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateCategory([FromBody] CreateCategory command)
        {
            var result = _categoryApplication.Create(command);
            return new JsonResult(result);
        }

        /// <summary>
        /// لیست تمامی دسته بندی های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CategoryViewModel> GetAllCategory()
        {
            return _categoryApplication.List();
        }
        /// <summary>
        /// دریافت جزئیات دسته بندی ها براساس ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public CategoryViewModel GetById([FromRoute] long id)
        {
            return _categoryApplication.GetBy(id);
        }
        /// <summary>
        /// ایجاد دسته بندی محصول
        /// دریافت جزئیات دسته بندی محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CategoryDetail/{id:long}")]
        public CategoryViewModel GetCategoryById(long id)
        {
            return _categoryApplication.GetBy(id);
        }
        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditCategory([FromBody] EditCategory command)
        {
            var result = _categoryApplication.Edit(command);
            return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی دسته بندی محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteCategory([FromRoute] long id)
        {
            var result = _categoryApplication.Delete(id);
            return new JsonResult(result);
        }

    }
}
