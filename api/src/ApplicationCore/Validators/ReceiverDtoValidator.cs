using FluentValidation;
using Homemap.ApplicationCore.Models;

namespace Homemap.ApplicationCore.Validators
{
    public class ReceiverDtoValidator : AbstractValidator<ReceiverDto>
    {
        public ReceiverDtoValidator()
        {
            RuleFor(receiver => receiver.Name)
                .MaximumLength(100).WithMessage("Receiver name must not exceed 100 characters.");
        }
    }
}
