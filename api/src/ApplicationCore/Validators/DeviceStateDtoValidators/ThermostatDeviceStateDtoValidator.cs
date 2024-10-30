using FluentValidation;
using Homemap.ApplicationCore.Models.DeviceState;

namespace Homemap.ApplicationCore.Validators.DeviceStateDtoValidators
{
    public class ThermostatDeviceStateDtoValidator : AbstractValidator<ThermostatDeviceStateDto>
    {
        public ThermostatDeviceStateDtoValidator()
        {
            RuleFor(x => x.Temperature)
                .GreaterThanOrEqualTo(18)
                .LessThanOrEqualTo(30)
                .PrecisionScale(3, 1, true);
        }

    }
}
