using FluentValidation;
using Homemap.ApplicationCore.Models.DeviceStates;

namespace Homemap.ApplicationCore.Validators.DeviceStateDtoValidators
{
    public class LightbulbDeviceStateDtoValidator : AbstractValidator<LightbulbDeviceStateDto>
    {
        public LightbulbDeviceStateDtoValidator()
        {
            RuleFor(x => x.Brightness)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100);

            RuleFor(x => x.Temperature)
                .GreaterThanOrEqualTo(1500)
                .LessThanOrEqualTo(7000);
        }

    }
}
