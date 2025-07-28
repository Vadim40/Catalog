using StoreService.Dto;
using StoreService.Models.PhoneEntities;


namespace StoreService.Repositories
{
    public interface IPhoneService
    {
        public Task<IEnumerable<Phone>> GetPhonesByFilterAsync(PhoneFilter phoneFilter);
        public Task<Phone> GetPhoneById(int phoneId);
        public Task<IEnumerable<Phone>> GetSimilarPhonesAsync(int phoneId);
    }
}
