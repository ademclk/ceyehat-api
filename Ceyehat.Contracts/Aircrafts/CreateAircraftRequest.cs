namespace Ceyehat.Contracts.Aircrafts;

public record CreateAircraftRequest(
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration);