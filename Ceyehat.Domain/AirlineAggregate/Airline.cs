using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.Entities;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate;

public sealed class Airline : AggregateRoot<AirlineId>
{
    private readonly List<AircraftId> _aircraftIds = new();
    public string? Name { get; }
    public string? IataCode { get; }
    public string? IcaoCode { get; }
    public string? Callsign { get; }
    public string? Code { get; }
    public string? Website { get; }
    
    public AirlineAddress AirlineAddress { get; }
    public IReadOnlyList<AircraftId> AircraftIds => _aircraftIds.AsReadOnly();

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Airline(
        AirlineId airlineId, 
        string? name, 
        string? iataCode, 
        string? icaoCode, 
        string? callsign, 
        string? code, 
        string? website, 
        AirlineAddress airlineAddress,
        DateTime createdAt,
        DateTime updatedAt) : base(airlineId)
    {
        Name = name;
        IataCode = iataCode;
        IcaoCode = icaoCode;
        Callsign = callsign;
        Code = code;
        Website = website;
        AirlineAddress = airlineAddress;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static Airline Create(
        string? name, 
        string? iataCode, 
        string? icaoCode, 
        string? callsign, 
        string? code, 
        string? website, 
        AirlineAddress airlineAddress)
    {
        return new(
            AirlineId.CreateUnique(), 
            name, 
            iataCode, 
            icaoCode, 
            callsign, 
            code, 
            website, 
            airlineAddress,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddAircraft(AircraftId aircraftId)
    {
        _aircraftIds.Add(aircraftId);
    }
    
    public void RemoveAircraft(AircraftId aircraftId)
    {
        _aircraftIds.Remove(aircraftId);
    }
}