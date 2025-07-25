using ManagmentStoreService.Dto;
using StoreService.Models;

namespace ManagmentStoreService.Services
{
    public interface IPhoneService
    {
        public Task AddNewPhoneModel(CreatePhoneModelDto phoneModelDto);
        public Task AddNewPhoneSpec(PhoneSpecDto phoneSpesDto);
        public Task AddNewPhone(PhoneDto phonDto);
       
    }
}
