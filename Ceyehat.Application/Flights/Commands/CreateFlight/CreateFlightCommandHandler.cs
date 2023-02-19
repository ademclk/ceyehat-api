using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.FlightAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, ErrorOr<Flight>>
{
    private readonly IFlightRepository _flightRepository;


    public CreateFlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<Flight>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = Flight.Create(
            request.FlightNumber,
            request.ScheduledDeparture,
            request.ScheduledArrival,
            request.Status,
            request.Type,
            request.ActualDeparture,
            request.ActualArrival,
            request.AircraftId,
            request.DepartureAirportId,
            request.ArrivalAirportId);

        await _flightRepository.AddFlightAsync(flight);

        return flight;
    }
}