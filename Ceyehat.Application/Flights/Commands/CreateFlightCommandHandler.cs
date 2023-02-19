using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.FlightAggregate;
using Ceyehat.Domain.FlightAggregate.Entities;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Flights.Commands;

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

        foreach (var p in request.Prices)
        {
            var price = Price.Create(p.Value, p.Currency, p.SeatClass, p.FlightId);
            flight.AddPrice(price);
        }

        await _flightRepository.AddFlightAsync(flight);

        return flight;
    }
}