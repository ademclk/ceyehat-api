using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.Entities;
using Ceyehat.Domain.FlightAggregate.ValueObjects;

namespace Ceyehat.Domain.FlightAggregate;

public sealed class Flight : AggregateRoot<FlightId>
{
    private readonly List<Price> _prices = new();
    public string? FlightNumber { get; private set; }
    public DateTime ScheduledDeparture { get; private set; }
    public DateTime ScheduledArrival { get; private set; }
    public FlightStatus Status { get; private set; }
    public FlightType Type { get; private set; }
    public DateTime? ActualDeparture { get; private set; }
    public DateTime? ActualArrival { get; private set; }

    public AircraftId AircraftId { get; private set; }
    public AirportId DepartureAirportId { get; private set; }
    public AirportId ArrivalAirportId { get; private set; }
    public IReadOnlyCollection<Price> Prices => _prices.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Flight(
        FlightId flightId,
        string flightNumber,
        DateTime scheduledDeparture,
        DateTime scheduledArrival,
        FlightStatus status,
        FlightType type,
        DateTime? actualDeparture,
        DateTime? actualArrival,
        AircraftId aircraftId,
        AirportId departureAirportId,
        AirportId arrivalAirportId,
        DateTime createdAt,
        DateTime updatedAt) : base(flightId)
    {
        FlightNumber = flightNumber;
        ScheduledDeparture = scheduledDeparture;
        ScheduledArrival = scheduledArrival;
        Status = status;
        Type = type;
        ActualDeparture = actualDeparture;
        ActualArrival = actualArrival;
        AircraftId = aircraftId;
        DepartureAirportId = departureAirportId;
        ArrivalAirportId = arrivalAirportId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Flight Create(
        string? flightNumber,
        DateTime scheduledDeparture,
        DateTime scheduledArrival,
        FlightStatus status,
        FlightType type,
        DateTime? actualDeparture,
        DateTime? actualArrival,
        AircraftId aircraftId,
        AirportId departureAirport,
        AirportId arrivalAirport)
    {
        return new Flight(
            FlightId.CreateUnique(),
            flightNumber!,
            scheduledDeparture,
            scheduledArrival,
            status,
            type,
            actualDeparture,
            actualArrival,
            aircraftId,
            departureAirport,
            arrivalAirport,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
    
    public void AddPrice(Price price)
    {
        _prices.Add(price);
    }
    
    public void RemovePrice(Price price)
    {
        _prices.Remove(price);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Flight()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}