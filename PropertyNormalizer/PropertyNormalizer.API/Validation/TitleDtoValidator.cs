// Validation/TitleDtoValidator.cs
using FluentValidation;
using PropertyNormalizer.API.DTOs;

namespace PropertyNormalizer.API.Validation;

public class TitleDtoValidator : AbstractValidator<TitleDto>
{
    public TitleDtoValidator()
    {
        RuleFor(x => x.Volume)
            .Matches(@"^\d{1,6}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Volume))
            .WithMessage("Volume must be 1–6 digits");

        RuleFor(x => x.Folio)
            .Matches(@"^\d{1,5}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Folio))
            .WithMessage("Folio must be 1–5 digits");
    }
}