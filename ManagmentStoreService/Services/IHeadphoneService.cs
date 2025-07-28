using ManagmentStoreService.Dto.Headphones;

namespace ManagmentStoreService.Services
{
    public interface IHeadphoneService
    {
        public Task AddNewHeadphonesModel(CreateHeadponesModelDto phoneModelDto);
        public Task AddNewHeadphonesSpec(CreateHeadphonesSpecDto phoneSpesDto);
        public Task AddNewHeadphones(CreateHeadphonesDto headphonesDto);
    }
}
