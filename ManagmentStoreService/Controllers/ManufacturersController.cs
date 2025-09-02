using ManagmentStoreService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStoreService.Controllers
{
    [ApiController]
    [Route("api/manufacturers")]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
       
        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var manufacturers = await _manufacturerService.GetAllAsync();
            return Ok(manufacturers);
        }
    }
}
