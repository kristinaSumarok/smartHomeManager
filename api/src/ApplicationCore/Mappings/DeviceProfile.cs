using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Models.Common;
using Homemap.ApplicationCore.Models.Devices;
using Homemap.Domain.Common;
using Homemap.Domain.Core;
using Homemap.Domain.Devices;

namespace Homemap.ApplicationCore.Mappings
{
    internal class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>()
                .IncludeBase<AuditableEntity, AuditableEntityDto>()
                .IncludeAllDerived()
                .ReverseMap()
                .IncludeBase<AuditableEntityDto, AuditableEntity>()
                .IncludeAllDerived();

            CreateMap<ACDevice, ACDeviceDto>()
                .ReverseMap();

            CreateMap<ThermostatDevice, ThermostatDeviceDto>()
                .ReverseMap();

            CreateMap<LightbulbDevice, LightbulbDeviceDto>()
                .ReverseMap();

            CreateMap<SocketDevice, SocketDeviceDto>()
                .ReverseMap();
        }
    }
}
