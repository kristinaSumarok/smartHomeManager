using ErrorOr;
using Homemap.ApplicationCore.Models;
using System.Collections.Concurrent;

namespace Homemap.ApplicationCore.Interfaces.Services
{
    public interface IDeviceService : IService<DeviceDto>
    {
        Task<ErrorOr<IReadOnlyList<DeviceDto>>> GetAllAsync(int receiverId);

        Task<ErrorOr<DeviceDto>> CreateAsync(int receiverId, DeviceDto dto);

        Task<ErrorOr<DeviceStateDto>> GetStateAsync(int deviceId);

        Task<ErrorOr<Updated>> SetStateAsync(int deviceId, DeviceStateDto deviceStateDto);
    }
}
