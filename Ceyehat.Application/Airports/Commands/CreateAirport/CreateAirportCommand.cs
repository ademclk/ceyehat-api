using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airports.Commands.CreateAirport;

public record CreateAirportCommand(
    string? Name,
    string? IataCode,
    string? IcaoCode,
    double Latitude,
    double Longitude,
    string? Timezone,
    CityId CityId) : IRequest<ErrorOr<Airport>>;