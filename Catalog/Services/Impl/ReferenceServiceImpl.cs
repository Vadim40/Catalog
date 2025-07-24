
using Catalog.Config;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repositories.Impl
{
    public class ReferenceServiceImpl<T> : IReferenceDataService<T> where T : class
    {
        private readonly CatalogDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public  ReferenceServiceImpl(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity  {typeof(T).Name} with id {id} not found.");

            return entity;
        }

    }
}
