using Ceyehat.Domain.Aircraft.ValueObjects;
using Ceyehat.Domain.Airline.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Country.ValueObjects;
using Ceyehat.Domain.Flight.ValueObjects;
using Ceyehat.Domain.Seat.ValueObjects;

namespace Ceyehat.Domain.Aircraft;

public sealed class Aircraft : AggregateRoot<AircraftId>
{
    private readonly List<FlightId> _flightIds = new();
    private readonly List<SeatId> _seatIds = new();

    public string? RegistrationNumber { get; }
    public string? Icao24Code { get; }
    public string? Model { get; }
    public string? ManufacturerSerialNumber { get; }
    public string? FaaRegistration { get; }
    public CountryId CountryId { get; }
    public AirlineId AirlineId { get; }

    public IReadOnlyList<FlightId> FlightIds => _flightIds.AsReadOnly();
    public IReadOnlyList<SeatId> SeatIds => _seatIds.AsReadOnly();

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Aircraft(
        AircraftId id,
        string? registrationNumber,
        string? icao24Code,
        string? model,
        string? manufacturerSerialNumber,
        string? faaRegistration,
        CountryId countryId,
        AirlineId airlineId,
        DateTime createdAt,
        DateTime updatedAt) : base(id)
    {
        RegistrationNumber = registrationNumber;
        Icao24Code = icao24Code;
        Model = model;
        ManufacturerSerialNumber = manufacturerSerialNumber;
        FaaRegistration = faaRegistration;
        CountryId = countryId;
        AirlineId = airlineId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}