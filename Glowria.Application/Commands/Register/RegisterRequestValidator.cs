using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Glowria.Application.Commands.Register;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator(IStringLocalizer<RegisterRequestValidator> localizer)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(localizer["Email is required"])
            .EmailAddress().WithMessage(localizer["Invalid email address"]);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(localizer["Password is required"])
            .MinimumLength(6).WithMessage(localizer["Password must be at least 6 characters"]);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(localizer["Name is required"])
            .MinimumLength(3).WithMessage(localizer["Name must be at least 3 characters"]);
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(localizer["Phone number is required"])
            .Matches(@"^(?:\+20|0)?1[0125][0-9]{8}$")
            .WithMessage(localizer["Invalid Egyptian phone number"]);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(localizer["Address is required"]);

        RuleFor(x => x.Confirmpassword)
            .Equal(x => x.Password)
            .WithMessage(localizer["Passwords do not match"]);
    }
}