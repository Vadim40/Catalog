using Catalog.Dto;
using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IHeadphonesService
    {
        public Task<IEnumerable<Headphones>> GetHeadphonesByFilterAsync(HeadphonesFilter headphonesFilter);
        public Task<Headphones> GetHeadphonesByIdAsync(int headphonesId);
        public Task<IEnumerable<Headphones>> GetSimilarHeadphonesAsync(int headphonesId);
    }
}
