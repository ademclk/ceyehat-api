using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.FlightAggregate.ValueObjects;

namespace Ceyehat.Domain.AirportAggregate;

public sealed class Airport : AggregateRoot<AirportId>
{
    private readonly List<FlightId> _departureFlights = new();
    private readonly List<FlightId> _arrivalFlights = new();
    public string? Name { get; }
    public string? IataCode { get; }
    public string? IcaoCode { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public string? TimeZone { get; }

    public CityId CityId { get; }
    public IReadOnlyList<FlightId> DepartureFlights => _departureFlights.AsReadOnly();
    public IReadOnlyList<FlightId> ArrivalFlights => _arrivalFlights.AsReadOnly();

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Airport(
        AirportId airportId,
        string? iataCode,
        string? icaoCode,
        string? name,
        double latitude,
        double longitude,
        string? timeZone,
        CityId cityId,
        DateTime createdAt,
        DateTime updatedAt) : base(airportId)
    {
        IataCode = iataCode;
        IcaoCode = icaoCode;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        TimeZone = timeZone;
        CityId = cityId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Airport Create(
        string? iataCode,
        string? icaoCode,
        string? name,
        double latitude,
        double longitude,
        string? timeZone,
        CityId cityId)
    {
        return new(
            AirportId.CreateUnique(),
            iataCode,
            icaoCode,
            name,
            latitude,
            longitude,
            timeZone,
            cityId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddDepartureFlight(FlightId flightId)
    {
        _departureFlights.Add(flightId);
    }

    public void RemoveDepartureFlight(FlightId flightId)
    {
        _departureFlights.Remove(flightId);
    }

    public void AddArrivalFlight(FlightId flightId)
    {
        _arrivalFlights.Add(flightId);
    }

    public void RemoveArrivalFlight(FlightId flightId)
    {
        _arrivalFlights.Remove(flightId);
    }
}




