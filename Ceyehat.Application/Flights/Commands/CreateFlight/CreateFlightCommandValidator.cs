using FluentValidation;

namespace Ceyehat.Application.Flights.Commands.CreateFlight;

public class CreateAircraftCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateAircraftCommandValidator()
    {
        RuleFor(x => x.FlightNumber)
            .NotEmpty();
        RuleFor(x => x.AircraftId)
            .NotEmpty();
        RuleFor(x => x.DepartureAirportId)
            .NotEmpty();
        RuleFor(x => x.ArrivalAirportId)
            .NotEmpty();
        RuleFor(x => x.ScheduledArrival)
            .NotEmpty();
        RuleFor(x => x.ScheduledDeparture)
            .NotEmpty();
    }
}