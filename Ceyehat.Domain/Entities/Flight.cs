using Ceyehat.Domain.Enums;

namespace Ceyehat.Domain.Entities;

public class Flight
{
    public Guid Id { get; set; }
    public Guid AircraftId { get; set; }
    public Guid DepartureAirportId { get; set; }
    public Guid ArrivalAirportId { get; set; }
    public string FlightNumber { get; set; } = null!;
    public DateTime ScheduledDeparture { get; set; }
    public DateTime ScheduledArrival { get; set; }
    public DateTime? ActualDeparture { get; set; }
    public DateTime? ActualArrival { get; set; }
    public FlightStatus Status { get; set; }

    public Aircraft Aircraft { get; set; } = null!;
    public Airport DepartureAirport { get; set; } = null!;
    public Airport ArrivalAirport { get; set; } = null!;
}