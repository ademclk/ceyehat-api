using Ceyehat.Domain.AirportAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airports.Commands.CreateAirport;

public abstract record CreateAirportCommand(
    string? Name,
    string? IataCode,
    string? IcaoCode,
    double Latitude,
    double Longitude,
    string? Timezone,
    string? CityId) : IRequest<ErrorOr<Airport>>;