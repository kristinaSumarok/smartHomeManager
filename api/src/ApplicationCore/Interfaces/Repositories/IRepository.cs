namespace Homemap.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<bool> SaveAsync();
    }
}
