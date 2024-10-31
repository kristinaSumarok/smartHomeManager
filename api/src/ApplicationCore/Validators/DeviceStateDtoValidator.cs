using FluentValidation;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Validators.DeviceStateDtoValidators;

namespace Homemap.ApplicationCore.Validators
{
    public class DeviceStateDtoValidator : AbstractValidator<DeviceStateDto>
    {
        public DeviceStateDtoValidator(
            ACDeviceStateDtoValidator acDeviceStateValidator,
            ThermostatDeviceStateDtoValidator thermostatDeviceStateValidator,
            LightbulbDeviceStateDtoValidator lightbulbDeviceStateValidator
        )
        {
            RuleFor(x => x)
                .SetInheritanceValidator(v =>
                {
                    v.Add(acDeviceStateValidator);
                    v.Add(thermostatDeviceStateValidator);
                    v.Add(lightbulbDeviceStateValidator);
                });

            RuleFor(x => x.IsTurnedOn)
                .NotNull();
        }

    }
}
