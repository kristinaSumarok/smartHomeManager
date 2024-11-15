using FluentValidation;
using Homemap.ApplicationCore.Models;

namespace Homemap.ApplicationCore.Validators
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
        public ProjectDtoValidator()
        {
            RuleFor(project => project.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MinimumLength(3)
                .MaximumLength(100).WithMessage("Project name must not exceed 100 characters.");
        }
    }
}
