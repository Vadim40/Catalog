using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStoreService.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class PhoneController : ControllerBase
        {
            private readonly IPhoneService _phoneService;

            public PhoneController ( IPhoneService phoneService)
            {
                _phoneService = phoneService;
            }

            [HttpGet("models")]
            public async Task<IActionResult> GetModelsByName([FromQuery] string name)
            {
                var models = await _phoneService.GetPhoneModelsByNameAsync(name);
                return Ok(models);
            }
            [HttpGet("models/{modelId}/specs")]
            public async Task<IActionResult> GetSpecsByModelId([FromRoute] int modelId)
            {
                var specs = await _phoneService.GetPhoneSpecsByModelIdAsync(modelId);
                return Ok(specs);
            }
            [HttpPost("model")]
            public async Task<IActionResult> AddModel([FromBody] CreatePhoneModelDto phoneModelDto )
            {
                await _phoneService.AddNewPhoneModelAsync(phoneModelDto);
                return Ok();
            }
            [HttpPost("models/{modelId}/specs")]
            public async Task<IActionResult> AddSpec([FromBody] CreatePhoneSpecDto phoneSpecDto)
            {
                await _phoneService.AddNewPhoneSpecAsync(phoneSpecDto);
                return Ok();
            }
            [HttpPost]
            public async Task<IActionResult> AddPhone([FromBody] CreatePhoneDto phoneDto)
            {
                await _phoneService.AddNewPhoneAsync(phoneDto);
                return Ok();
            }
        }
}
