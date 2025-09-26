using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models;
using ManagmentStoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Services
{
    public interface IPhoneService
    {
        public Task AddModelAsync(PhoneModelCreateDto phoneModelDto);
        public Task AddSpecAsync(PhoneSpecCreateDto phoneSpecDto);
        public Task AddPhoneAsync(PhoneCreateDto phonDto);
        public Task AddImagesToModelAsync(VariantImagesUploadDto images);
        public Task<int> AddPhoneVariantAsync( PhoneVariantCreateDto variantDto);

        public Task<IEnumerable<PhoneModelDto>> SearchModelsAsync(string name);
        public Task<IEnumerable<PhoneSpecDto>> GetSpecsAsync(int modelId);
        public Task<IEnumerable<PhoneSpecDto>> SearchSpecsAsync(string search);

        public Task<IEnumerable<ImageDto>> GetImagesAsync(int modelId, int colorId);

        public Task<IEnumerable<PhoneVariantDto>> SearchVariantsAsync(string name);
     
    }
}
