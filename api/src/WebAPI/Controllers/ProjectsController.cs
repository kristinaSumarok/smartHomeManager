using FluentValidation;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;

namespace Homemap.WebAPI.Controllers
{
    public class ProjectsController : BaseController<ProjectDto>
    {
        public ProjectsController(IService<ProjectDto> service, IValidator<ProjectDto> validator) : base(service, validator)
        {
        }
    }
}
