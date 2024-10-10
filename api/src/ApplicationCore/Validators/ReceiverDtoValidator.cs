using FluentValidation;
using Homemap.ApplicationCore.Models;

namespace Homemap.ApplicationCore.Validators
{
    public class ReceiverDtoValidator : AbstractValidator<ReceiverDto>
    {
        public ReceiverDtoValidator()
        {
            RuleFor(receiver => receiver.Name)
                .NotEmpty().WithMessage("Receiver name is required.")
                .MaximumLength(100).WithMessage("Receiver name must not exceed 100 characters.");

            //for test purposes
            RuleFor(receiver => receiver.Devices)
                .NotNull().WithMessage("Devices collection cannot be null.")
                .Must(devices => devices.Count > 0).WithMessage("Devices collection must contain at least one device.");

            RuleForEach(receiver => receiver.Devices)
                .SetValidator(new DeviceDtoValidator());
        }
    }
}
