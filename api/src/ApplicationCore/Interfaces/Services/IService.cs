namespace Homemap.ApplicationCore.Interfaces.Services
{
    /// <typeparam name="T">must be DTO</typeparam>
    public interface IService<T>
    {
        Task<T?> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> CreateAsync(T dto);

        Task<T> UpdateAsync(int id, T dto);

        Task DeleteAsync(int id);
    }
}
