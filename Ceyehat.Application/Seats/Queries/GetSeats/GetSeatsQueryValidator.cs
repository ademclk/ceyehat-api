using FluentValidation;

namespace Ceyehat.Application.Seats.Queries.GetSeats;

public class GetSeatsQueryValidator : AbstractValidator<GetSeatsQuery>
{
    public GetSeatsQueryValidator()
    {
        RuleFor(a => a.FlightNumber)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(a => a.AircraftName)
            .MaximumLength(64)
            .NotEmpty();
    }
}