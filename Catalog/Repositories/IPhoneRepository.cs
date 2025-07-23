using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IPhoneRepository
    {
        public Task<IEnumerable<Phone>> GetPhonesByFilter(PhoneFilter phoneFilter);
        public Task<Phone> GetPhoneById(int phoneId);
        public Task<IEnumerable<Phone>> GetSimilarPhonesToPhoneId(int phoneId);
    }
}
