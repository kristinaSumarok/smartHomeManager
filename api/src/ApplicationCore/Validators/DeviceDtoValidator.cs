using FluentValidation;
using Homemap.ApplicationCore.Models;

namespace Homemap.ApplicationCore.Validators
{
    public class DeviceDtoValidator : AbstractValidator<DeviceDto>
    {
        public DeviceDtoValidator()
        {
            RuleFor(device => device.Name)
                .NotEmpty().WithMessage("Device name is required.")
                .MinimumLength(3)
                .MaximumLength(100).WithMessage("Device name must not exceed 100 characters.");
        }
    }
}
