namespace ManagmentStoreService.Services
{
    public interface IHeadphoneService
    {
        public Task AddNewHeadphonesModel(HeadphonesModelDto phoneModelDto);
        public Task AddNewHeadphonesSpec(HeadphonesSpecDto phoneSpesDto);
        public Task AddNewHeadphones(HeadphonesDto headphonesDto);
    }
}
