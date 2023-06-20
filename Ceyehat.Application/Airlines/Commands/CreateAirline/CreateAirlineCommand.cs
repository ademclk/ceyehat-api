using Ceyehat.Domain.AirlineAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airlines.Commands.CreateAirline;

public abstract record CreateAirlineCommand(
    string? Name,
    string? IataCode,
    string? IcaoCode,
    string? Callsign,
    string? Code,
    string? Website,
    AirlineAddressCommand Address
) : IRequest<ErrorOr<Airline>>;

public abstract record AirlineAddressCommand(
    string? CityId);