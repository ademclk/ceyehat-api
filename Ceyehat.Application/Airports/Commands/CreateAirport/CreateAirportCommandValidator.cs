using FluentValidation;

namespace Ceyehat.Application.Airports.Commands.CreateAirport;

public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportCommandValidator()
    {
        RuleFor(a => a.Name)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(a => a.IataCode)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(a => a.IcaoCode)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(a => a.Latitude)
            .InclusiveBetween(0, 90)
            .NotEmpty();
        RuleFor(a => a.Longitude)
            .InclusiveBetween(0, 180)
            .NotEmpty();
        RuleFor(a => a.Timezone)
            .MaximumLength(64)
            .NotEmpty();
    }
}