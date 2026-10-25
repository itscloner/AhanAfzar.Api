using CustomerManagment.Application.Contracts.Province;
using Microsoft.AspNetCore.Mvc;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceApplication _ProvinceApplication;

        public ProvinceController(IProvinceApplication ProvinceApplication)
        {
            _ProvinceApplication = ProvinceApplication;
        }

        /// <summary>
        /// لیست استانها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProvinceViewModel> GetAllProvince()
        {
            return _ProvinceApplication.List();
        }
    }
}
