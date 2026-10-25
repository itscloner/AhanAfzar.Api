using CustomerManagment.Application.Contracts.City;
using Microsoft.AspNetCore.Mvc;

namespace AhanAfzar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityApplication _CityApplication;

        public CityController(ICityApplication CityApplication)
        {
            _CityApplication = CityApplication;
        }

        /// <summary>
        /// لیست شهرها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CityViewModel> GetAllCity(long provinceId)
        {
            return _CityApplication.List(provinceId);
        }
    }
}
