using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Mappings
{
    internal class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ReverseMap();
        }
    }
}
