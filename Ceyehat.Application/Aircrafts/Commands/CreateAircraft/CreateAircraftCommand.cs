using Ceyehat.Domain.AircraftAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public abstract record CreateAircraftCommand(
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration,
    string? CountryId,
    string? AirlineId
) : IRequest<ErrorOr<Aircraft>>;