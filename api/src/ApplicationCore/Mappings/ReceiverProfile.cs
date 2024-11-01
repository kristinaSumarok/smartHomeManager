using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Models.Common;
using Homemap.Domain.Common;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Mappings
{
    internal class ReceiverProfile : Profile
    {
        public ReceiverProfile()
        {
            CreateMap<Receiver, ReceiverDto>()
                .IncludeBase<AuditableEntity, AuditableEntityDto>()
                .ReverseMap()
                .IncludeBase<AuditableEntityDto, AuditableEntity>();
        }
    }
}
