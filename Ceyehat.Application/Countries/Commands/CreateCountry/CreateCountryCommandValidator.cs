using FluentValidation;

namespace Ceyehat.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(x => x.UnLocode)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Iso2)
            .NotEmpty();
        RuleFor(x => x.Iso3)
            .NotEmpty();
        RuleFor(x => x.Currency)
            .NotEmpty();
    }
}