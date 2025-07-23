using Catalog.Models;

namespace Catalog.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();

    }
}
