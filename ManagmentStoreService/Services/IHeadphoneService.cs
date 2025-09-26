using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Headphones;

namespace ManagmentStoreService.Services
{
    public interface IHeadphoneService
    {
        public Task AddNewHeadphonesModelAsync(HeadponesModelCreateDto headphonesModelDto);
        public Task AddNewHeadphonesSpecAsync(HeadphonesSpecCreateDto headphonesSpesDto);
        public Task AddNewHeadphonesAsync(HeadphonesCreateDto headphonesDto);

        public Task<IEnumerable<HeadphonesModelDto>> GetHeadphonesModelsByNameAsync(string name);
        public Task<IEnumerable<HeadphonesSpecDto>> GetHeadphonesSpecsByModelIdAsync(int modelId);

        public Task AddImagesToHeadphonesModelAsync(VariantImagesUploadDto images);
    }
}
