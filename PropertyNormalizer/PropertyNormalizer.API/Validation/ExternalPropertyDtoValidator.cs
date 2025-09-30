using FluentValidation;
using PropertyNormalizer.API.DTOs;

namespace PropertyNormalizer.API.Validation;

public class ExternalPropertyDtoValidator : AbstractValidator<ExternalPropertyDto>
{
    public ExternalPropertyDtoValidator()
    {
        RuleFor(x => x.Title).SetValidator(new TitleDtoValidator()!);   
    }
}