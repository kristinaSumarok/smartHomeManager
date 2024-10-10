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
                .MaximumLength(100).WithMessage("Device name must not exceed 100 characters.");

            RuleFor(device => device.Type)
                .NotEmpty().WithMessage("Device type is required.")
                //has to be changed, when we have list of devices
                .MaximumLength(50).WithMessage("Device type must not exceed 50 characters.");
        }

    }
}
