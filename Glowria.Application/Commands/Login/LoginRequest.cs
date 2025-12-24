using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Glowria.Application.Commands.Login;

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequestVaildator : AbstractValidator<LoginRequest>
{
    public LoginRequestVaildator(IStringLocalizer<LoginRequestVaildator> localizer)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(localizer["Email is required"])
            .EmailAddress().WithMessage(localizer["Invalid email address"]);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(localizer["Password is required"]);
    }
}