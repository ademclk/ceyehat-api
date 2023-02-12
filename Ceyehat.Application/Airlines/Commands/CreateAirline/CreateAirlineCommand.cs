using Ceyehat.Contracts.Airlines;
using Ceyehat.Domain.AirlineAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airlines.Commands.CreateAirline;

public record CreateAirlineCommand(
    string? Name,
    string? IataCode,
    string? IcaoCode,
    string? Callsign,
    string? Country,
    string? Website,
    AirlineAddress Address
) : IRequest<ErrorOr<Airline>>;