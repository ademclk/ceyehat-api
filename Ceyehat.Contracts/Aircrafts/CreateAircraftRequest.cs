using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;

namespace Ceyehat.Contracts.Aircrafts;

public record CreateAircraftRequest(
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration,
    CountryId CountryId,
    AirlineId AirlineId
);