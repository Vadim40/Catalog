using ManagmentStoreService.Dto;
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

        public PhoneController(IPhoneService phoneService)
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
        public async Task<IActionResult> GetSpecs([FromQuery] string search)
        {
            var specs = await _phoneService.SearchSpecsAsync(search);
            return Ok(specs);
        }

        [HttpPost("models")]
        public async Task<IActionResult> AddModel([FromBody] PhoneModelCreateDto phoneModelDto)
        {
            await _phoneService.AddModelAsync(phoneModelDto);
            return Ok();
        }
        [HttpPost("specs")]
        public async Task<IActionResult> AddSpec([FromBody] PhoneSpecCreateDto phoneSpecDto)
        {
            Console.WriteLine(phoneSpecDto.DisplayIn);
            await _phoneService.AddSpecAsync(phoneSpecDto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddPhone([FromBody] PhoneCreateDto phoneDto)
        {
            await _phoneService.AddPhoneAsync(phoneDto);
            return Ok();
        }

        [HttpPost("images")]
        public async Task<IActionResult> AddImages([FromForm] VariantImagesUploadDto uploadImages)
        {
            await _phoneService.AddImagesToModelAsync(uploadImages);
            return Ok();
        }
        [HttpGet("images")]
        public async Task<IActionResult> GetImages([FromQuery] int modelId, [FromQuery] int colorId)
        {
            var images = await _phoneService.GetImagesAsync(modelId, colorId);
            return Ok(images);
        }

        [HttpPost("variants")]
        public async Task<IActionResult> AddVariant([FromBody] PhoneVariantCreateDto variantDto)
        {
            var variantId = await _phoneService.AddPhoneVariantAsync(variantDto);
            return Ok(variantId);
        }
        [HttpGet("variants")]
        public async Task<IActionResult> SearchVariants([FromQuery] string name)
        {
            Console.Write("test()");
            var variants = await _phoneService.SearchVariantsAsync(name);
            return Ok(variants);
        }
    }
}
