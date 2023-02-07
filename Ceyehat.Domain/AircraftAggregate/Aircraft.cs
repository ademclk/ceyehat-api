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
    
    public static Aircraft Create(
        AircraftId id,
        string? registrationNumber,
        string? icao24Code,
        string? model,
        string? manufacturerSerialNumber,
        string? faaRegistration,
        CountryId countryId,
        AirlineId airlineId,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new(
            id, 
            registrationNumber, 
            icao24Code, 
            model, 
            manufacturerSerialNumber, 
            faaRegistration, 
            countryId,
            airlineId, 
            createdAt, 
            updatedAt);
    }
    
    public void AddFlight(FlightId flightId)
    {
        _flightIds.Add(flightId);
    }
    public void AddSeat(SeatId seatId)
    {
        _seatIds.Add(seatId);
    }
    public void RemoveFlight(FlightId flightId)
    {
        _flightIds.Remove(flightId);
    }
    public void RemoveSeat(SeatId seatId)
    {
        _seatIds.Remove(seatId);
    }
}