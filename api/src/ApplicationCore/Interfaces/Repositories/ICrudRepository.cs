namespace Homemap.ApplicationCore.Interfaces.Repositories
{
    public interface ICrudRepository<T> : IRepository where T : class
    {
        Task<T> AddAsync(T entity);

        Task<T?> FindByIdAsync(int id);

        Task<IReadOnlyList<T>> FindAllAsync();

        void Update(T entity);

        void Remove(T entity);
    }
}
