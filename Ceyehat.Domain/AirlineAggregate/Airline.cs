using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.Entities;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate;

public sealed class Airline : AggregateRoot<AirlineId>
{
    private readonly List<AircraftId> _aircraftIds = new();
    public string? Name { get; private set; }
    public string? IataCode { get; private set; }
    public string? IcaoCode { get; private set; }
    public string? Callsign { get; private set; }
    public string? Code { get; private set; }
    public string? Website { get; private set; }

    public AirlineAddress AirlineAddress { get; private set; }
    public IReadOnlyList<AircraftId> AircraftIds => _aircraftIds.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

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

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Airline()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}