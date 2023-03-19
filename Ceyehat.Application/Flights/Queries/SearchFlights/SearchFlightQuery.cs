using Ceyehat.Application.Common.DTOs;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Flights.Queries.SearchFlights;

public record SearchFlightQuery(
    string? DepartureAirportIataCode,
    string? ArrivalAirportIataCode,
    string? DepartureDate,
    string? ReturnDate,
    int PassengerCount
) : IRequest<ErrorOr<List<FlightDto>>>;