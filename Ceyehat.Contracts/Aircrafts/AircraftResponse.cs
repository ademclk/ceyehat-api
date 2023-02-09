namespace Ceyehat.Contracts.Aircrafts;

public record AircraftResponse(
    string Id,
    string? RegistrationNumber,
    string? Icao24Code,
    string? Model,
    string? ManufacturerSerialNumber,
    string? FaaRegistration,
    string CountryId,
    string AirlineId,
    List<string> FlightIds,
    List<string> SeatIds,
    DateTime CreatedAt,
    DateTime UpdatedAt
);