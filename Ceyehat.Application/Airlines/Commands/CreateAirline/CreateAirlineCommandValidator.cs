using FluentValidation;

namespace Ceyehat.Application.Airlines.Commands.CreateAirline;

public class CreateAirlineCommandValidator : AbstractValidator<CreateAirlineCommand>
{
    public CreateAirlineCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.IataCode)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.IcaoCode)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Callsign)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Code)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Website)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Address.CityId)
            .NotEmpty();
    }
}