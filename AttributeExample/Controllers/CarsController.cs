using AttributeExample.ActionFilters;
using AttributeExample.Models;
using AttributeExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //header'da gönderilmiş olan user-name'den User nesnesi yaratıp geriye döner
    [UserInformation]

    //Kullanıldığı class veya methodu loglar
    [BaseLogger]
    public class CarsController : ControllerBase
    {
        private readonly CarService carService;
        private readonly UserService userService;
        private readonly User userInfo;

        public CarsController(CarService carService, UserService userService, User userInfo)
        {
            this.carService = carService;
            this.userService = userService;
            this.userInfo = userInfo;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // UserInformation attribute'ünde oluşturulan instance ile UserService'tan GetUser isteği yapılıyor.
            var user = userService.GetUserByName(userInfo.Username);

            // Request'i oluşturan user'ın sahip olduğu markaya ait araçlar listeleniyor.
            var cars = carService.GetCarsByBrandName(user.Brand).ToList();

            return Ok(cars);
        }
    }
}
