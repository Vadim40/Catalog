using ManagmentStoreService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStoreService.Controllers
{
    [ApiController]
    [Route("api/colors")]
    public class ColorContoller : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorContoller(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("{modelId}")]
        public async Task<IActionResult> GetColors([FromRoute] int modelId)
        {
            var colors = await _colorService.GetColorAsync(modelId);
            return Ok(colors);
        }
        [HttpGet]
        public async Task<IActionResult> GetColors([FromQuery] string search)
        {
            var colors = await _colorService.GetColorAsync(search);
            return Ok(colors);
        }
    }
}
