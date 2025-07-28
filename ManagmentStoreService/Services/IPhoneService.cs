using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using StoreService.Models;

namespace ManagmentStoreService.Services
{
    public interface IPhoneService
    {
        public Task AddNewPhoneModelAsync(CreatePhoneModelDto phoneModelDto);
        public Task AddNewPhoneSpecAsync(CreatePhoneSpecDto phoneSpesDto);
        public Task AddNewPhoneAsync(CreatePhoneDto phonDto);
        public Task<IEnumerable<PhoneModelDto>> GetPhoneModelsByNameAsync(string name);
        public Task<IEnumerable<PhoneSpecDto>> GetPhoneSpecByModelIdAsync(int modelId);

        public Task AddImagesToPhoneModelAsync(CreateImagesDto images);
    }
}
