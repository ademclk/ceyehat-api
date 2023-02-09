using Ceyehat.Domain.AircraftAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public record CreateAircraftCommand(
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration
) : IRequest<ErrorOr<Aircraft>>;