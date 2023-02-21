using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public record CreateAircraftCommand(
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration,
    string? CountryId,
    string? AirlineId
) : IRequest<ErrorOr<Aircraft>>;