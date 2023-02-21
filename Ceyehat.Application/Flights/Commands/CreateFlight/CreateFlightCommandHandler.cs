using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate;
using Ceyehat.Domain.PriceAggregate.ValueObjects;
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
        var aircraftId = AircraftId.Create(Guid.Parse(request.AircraftId!));
        var departureAirportId = AirportId.Create(Guid.Parse(request.DepartureAirportId!));
        var arrivalAirportId = AirportId.Create(Guid.Parse(request.ArrivalAirportId!));
        var priceId = PriceId.Create(Guid.Parse(request.PriceId!));

        var flight = Flight.Create(
            request.FlightNumber,
            request.ScheduledDeparture,
            request.ScheduledArrival,
            request.Status,
            request.Type,
            request.ActualDeparture,
            request.ActualArrival,
            aircraftId,
            departureAirportId,
            arrivalAirportId,
            priceId);

        await _flightRepository.AddFlightAsync(flight);

        return flight;
    }
}