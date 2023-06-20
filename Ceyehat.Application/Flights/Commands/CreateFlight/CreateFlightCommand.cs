using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Flights.Commands.CreateFlight;

public abstract record CreateFlightCommand(
    string? FlightNumber,
    DateTime ScheduledDeparture,
    DateTime ScheduledArrival,
    FlightStatus Status,
    FlightType Type,
    DateTime? ActualDeparture,
    DateTime? ActualArrival,
    string? AircraftId,
    string? DepartureAirportId,
    string? ArrivalAirportId,
    string? EconomyPriceId,
    string? ComfortPriceId,
    string? BusinessPriceId
) : IRequest<ErrorOr<Flight>>;