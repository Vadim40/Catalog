using ManagmentStoreService.Config;
using ManagmentStoreService.Dto;

namespace ManagmentStoreService.Services
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<IdNameDto>> GetAllAsync();
       
    }
}
