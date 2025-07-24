using Catalog.Dto;
using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IPhoneService
    {
        public Task<IEnumerable<Phone>> GetPhonesByFilterAsync(PhoneFilter phoneFilter);
        public Task<Phone> GetPhoneById(int phoneId);
        public Task<IEnumerable<Phone>> GetSimilarPhonesAsync(int phoneId);
    }
}
