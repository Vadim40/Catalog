namespace Catalog.Repositories
{
    public interface IReferenceDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
    }
}
