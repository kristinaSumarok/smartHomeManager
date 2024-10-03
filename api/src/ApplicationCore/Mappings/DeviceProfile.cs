using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Mappings
{
    internal class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>()
                .ForCtorParam(nameof(DeviceDto.Type),
                    opt => opt.MapFrom(src => src.DeviceType.ToString()))
                .ReverseMap()
                .ForMember(nameof(Device.DeviceType),
                    opt => opt.MapFrom(src => Enum.Parse<DeviceType>(src.Type)));
        }
    }
}
