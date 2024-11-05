using AutoMapper;
using Homemap.ApplicationCore.Models.Common;
using Homemap.Domain.Common;

namespace Homemap.ApplicationCore.Mappings
{
    internal class AuditableEntityProfile : Profile
    {
        public AuditableEntityProfile()
        {
            CreateMap<AuditableEntity, AuditableEntityDto>()
                .ReverseMap()
                .ForMember(nameof(AuditableEntityDto.CreatedAt), opts => opts.Ignore())
                .ForMember(nameof(AuditableEntityDto.LastModifiedAt), opts => opts.Ignore());
        }
    }
}
