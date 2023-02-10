using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.AircraftAggregate;

public sealed class Aircraft : AggregateRoot<AircraftId>
{
    private readonly List<FlightId> _flightIds = new();
    private readonly List<SeatId> _seatIds = new();

    public string? RegistrationNumber { get; private set; }
    public string? Icao24Code { get; private set; }
    public string? Model { get; private set; }
    public string? ManufacturerSerialNumber { get; private set; }
    public string? FaaRegistration { get; private set; }
    public CountryId CountryId { get; private set; }
    public AirlineId AirlineId { get; private set; }

    public IReadOnlyList<FlightId> FlightIds => _flightIds.AsReadOnly();
    public IReadOnlyList<SeatId> SeatIds => _seatIds.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Aircraft(
        AircraftId aircraftId,
        string? registrationNumber,
        string? icao24Code,
        string? model,
        string? manufacturerSerialNumber,
        string? faaRegistration,
        CountryId countryId,
        AirlineId airlineId,
        DateTime createdAt,
        DateTime updatedAt) : base(aircraftId)
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

    public static Aircraft Create(
        string? registrationNumber,
        string? icao24Code,
        string? model,
        string? manufacturerSerialNumber,
        string? faaRegistration,
        CountryId countryId,
        AirlineId airlineId)
    {
        return new(
            AircraftId.CreateUnique(),
            registrationNumber,
            icao24Code,
            model,
            manufacturerSerialNumber,
            faaRegistration,
            countryId,
            airlineId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddFlight(FlightId flightId)
    {
        _flightIds.Add(flightId);
    }
    public void RemoveFlight(FlightId flightId)
    {
        _flightIds.Remove(flightId);
    }
    public void AddSeat(SeatId seatId)
    {
        _seatIds.Add(seatId);
    }
    public void RemoveSeat(SeatId seatId)
    {
        _seatIds.Remove(seatId);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Aircraft()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}