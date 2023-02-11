using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;

namespace Ceyehat.Domain.FlightAggregate;

public sealed class Flight : AggregateRoot<FlightId>
{
    public string? FlightNumber { get; }
    public DateTime ScheduledDeparture { get; }
    public DateTime ScheduledArrival { get; }
    public FlightStatus Status { get; }
    public FlightType Type { get; }
    public DateTime? ActualDeparture { get; }
    public DateTime? ActualArrival { get; }

    public AircraftId AircraftId { get; }
    public AirportId DepartureAirportId { get; }
    public AirportId ArrivalAirportId { get; }

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

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
}