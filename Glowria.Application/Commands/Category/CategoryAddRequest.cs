using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Glowria.Application.Commands.Category;

public class CategoryAddRequest
{
    public string NameEn { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;

    public string? DescriptionEn { get; set; }
    public string? DescriptionAr { get; set; }

    public bool IsActive { get; set; }
}

public class CategoryAddRequestValidator : AbstractValidator<CategoryAddRequest>
{
    public CategoryAddRequestValidator(
        IStringLocalizer<CategoryAddRequestValidator> localizer)
    {
        RuleFor(x => x.NameEn)
            .NotEmpty().WithMessage(localizer["Category.NameEn.Required"])
            .MaximumLength(100).WithMessage(localizer["Category.NameEn.MaxLength"]);

        RuleFor(x => x.NameAr)
            .NotEmpty().WithMessage(localizer["Category.NameAr.Required"])
            .MaximumLength(100).WithMessage(localizer["Category.NameAr.MaxLength"]);

        RuleFor(x => x.DescriptionEn)
            .MaximumLength(500)
            .WithMessage(localizer["Category.DescriptionEn.MaxLength"])
            .When(x => !string.IsNullOrEmpty(x.DescriptionEn));

        RuleFor(x => x.DescriptionAr)
            .MaximumLength(500)
            .WithMessage(localizer["Category.DescriptionAr.MaxLength"])
            .When(x => !string.IsNullOrEmpty(x.DescriptionAr));
    }
}
