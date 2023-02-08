using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AirportAggregate;
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
    
    public Aircraft Aircraft { get; }
    public Airport DepartureAirport { get; }
    public Airport ArrivalAirport { get; }
    
    private Flight(
        FlightId id, 
        string flightNumber, 
        DateTime scheduledDeparture, 
        DateTime scheduledArrival, 
        FlightStatus status, 
        FlightType type, 
        DateTime? actualDeparture, 
        DateTime? actualArrival, 
        Aircraft aircraft, 
        Airport departureAirport, 
        Airport arrivalAirport) : base(id)
    {
        FlightNumber = flightNumber;
        ScheduledDeparture = scheduledDeparture;
        ScheduledArrival = scheduledArrival;
        Status = status;
        Type = type;
        ActualDeparture = actualDeparture;
        ActualArrival = actualArrival;
        Aircraft = aircraft;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
    }
    
    public static Flight Create(
        FlightId id, 
        string flightNumber, 
        DateTime scheduledDeparture, 
        DateTime scheduledArrival, 
        FlightStatus status, 
        FlightType type, 
        DateTime? actualDeparture, 
        DateTime? actualArrival, 
        Aircraft aircraft, 
        Airport departureAirport, 
        Airport arrivalAirport)
    {
        return new Flight(
            id, 
            flightNumber, 
            scheduledDeparture, 
            scheduledArrival, 
            status, 
            type, 
            actualDeparture, 
            actualArrival, 
            aircraft, 
            departureAirport, 
            arrivalAirport);
    }
}