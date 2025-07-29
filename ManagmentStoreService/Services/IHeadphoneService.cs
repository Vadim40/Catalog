using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Headphones;

namespace ManagmentStoreService.Services
{
    public interface IHeadphoneService
    {
        public Task AddNewHeadphonesModelAsync(CreateHeadponesModelDto headphonesModelDto);
        public Task AddNewHeadphonesSpecAsync(CreateHeadphonesSpecDto headphonesSpesDto);
        public Task AddNewHeadphonesAsync(CreateHeadphonesDto headphonesDto);

        public Task<IEnumerable<HeadphonesModelDto>> GetHeadphonesModelsByNameAsync(string name);
        public Task<IEnumerable<HeadphonesSpecDto>> GetHeadphonesSpecsByModelIdAsync(int modelId);

        public Task AddImagesToHeadphonesModelAsync(CreateImagesDto images);
    }
}
