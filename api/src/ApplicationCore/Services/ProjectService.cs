using AutoMapper;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Services
{
    public class ProjectService : BaseService<Project, ProjectDto>
    {
        public ProjectService(IMapper mapper, ICrudRepository<Project> repository) : base(mapper, repository)
        {
        }
    }
}
