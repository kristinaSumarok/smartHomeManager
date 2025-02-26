﻿using Homemap.Domain.Core;
namespace Homemap.ApplicationCore.Interfaces.Repositories;

public interface IDeviceRepository : ICrudRepository<Device>
{
    Task<IReadOnlyList<Device>> FindAllByReceiverId(int receiverId);
}
