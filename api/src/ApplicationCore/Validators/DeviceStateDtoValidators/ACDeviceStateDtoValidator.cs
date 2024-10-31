using FluentValidation;
using Homemap.ApplicationCore.Models.DeviceStates;

namespace Homemap.ApplicationCore.Validators.DeviceStateDtoValidators
{
    public class ACDeviceStateDtoValidator : AbstractValidator<ACDeviceStateDto>
    {
        public ACDeviceStateDtoValidator()
        {
            RuleFor(x => x.Temperature)
                .GreaterThanOrEqualTo(18)
                .LessThanOrEqualTo(30)
                .PrecisionScale(3, 1, true);
        }

    }
}
