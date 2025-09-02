using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models;

namespace ManagmentStoreService.Services
{
    public interface IPhoneService
    {
        public Task AddModelAsync(CreatePhoneModelDto phoneModelDto);
        public Task AddSpecAsync(CreatePhoneSpecDto phoneSpecDto);
        public Task AddPhoneAsync(CreatePhoneDto phonDto);
        public Task AddImagesToModelAsync(CreateImagesDto images);

        public Task<IEnumerable<PhoneModelDto>> SearchModelsAsync(string name);
        public Task<IEnumerable<PhoneSpecDto>> GetSpecsAsync(int modelId);
        public Task<IEnumerable<PhoneSpecDto>> SearchSpecsAsync(string search);

     
    }
}
