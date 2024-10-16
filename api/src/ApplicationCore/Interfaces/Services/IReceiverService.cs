using ErrorOr;
using Homemap.ApplicationCore.Models;

namespace Homemap.ApplicationCore.Interfaces.Services
{
    public interface IReceiverService : IService<ReceiverDto>
    {

        Task<ErrorOr<IReadOnlyList<ReceiverDto>>> GetAllAsync(int projectId);

        Task<ErrorOr<ReceiverDto>> CreateAsync(int projectId, ReceiverDto dto);
    }
}
