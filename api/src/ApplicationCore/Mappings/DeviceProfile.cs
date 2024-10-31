using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Models.Devices;
using Homemap.Domain.Core;
using Homemap.Domain.Devices;

namespace Homemap.ApplicationCore.Mappings
{
    internal class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>()
                .IncludeAllDerived()
                .ReverseMap()
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
