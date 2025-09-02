using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStoreService.Controllers
{
        [ApiController]
        [Route("api/phones")]
        public class PhoneController : ControllerBase
        {
            private readonly IPhoneService _phoneService;

            public PhoneController ( IPhoneService phoneService)
            {
                _phoneService = phoneService;
            }

            [HttpGet("models")]
            public async Task<IActionResult> SearchModels([FromQuery] string name)
            {
                var models = await _phoneService.SearchModelsAsync(name);
                return Ok(models);
            }
            [HttpGet("{modelId}/specs")]
            public async Task<IActionResult> GetSpecs([FromRoute] int modelId)
            {
                var specs = await _phoneService.GetSpecsAsync(modelId);
                return Ok(specs);
            }
            [HttpGet("specs")]
            public async Task<IActionResult> GetSpecs([FromQuery] string search )
            {
                var specs = await _phoneService.SearchSpecsAsync(search);
                return Ok(specs);
            }

            [HttpPost("models")]
            public async Task<IActionResult> AddModel([FromBody] CreatePhoneModelDto phoneModelDto )
            {
                await _phoneService.AddModelAsync(phoneModelDto);
                return Ok();
            }
            [HttpPost("specs")]
            public async Task<IActionResult> AddSpec([FromBody] CreatePhoneSpecDto phoneSpecDto)
            {
                await _phoneService.AddSpecAsync(phoneSpecDto);
                return Ok();
            }
            [HttpPost]
            public async Task<IActionResult> AddPhone([FromBody] CreatePhoneDto phoneDto)
            {
                await _phoneService.AddPhoneAsync(phoneDto);
                return Ok();
            }
        }
}
