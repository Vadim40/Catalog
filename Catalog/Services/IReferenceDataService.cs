namespace Catalog.Repositories
{
    public interface IReferenceDataService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
