using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IHeadphonesRepository
    {
        public Task<IEnumerable<Headphones>> GetHeadphonessByFilter(HeadphonesFilter headphonesFilter);
        public Task<Headphones> GetHeadphonesById(int headphonesId);
        public Task<IEnumerable<Headphones>> GetSimilarHeadphonessToHeadphonesId(int headphonesId);
    }
}
