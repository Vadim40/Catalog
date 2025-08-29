using Microsoft.AspNetCore.Mvc;

namespace ManagmentStoreService.Controllers
{
    [ApiController]
    [Route("api/manufacturers")]
    public class ManufacturersController : ControllerBase
    {
        [HttpGet]
        public IActionResult<Manufa>
    }
}
