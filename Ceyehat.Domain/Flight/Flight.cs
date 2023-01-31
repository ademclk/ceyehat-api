using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.Flight.ValueObjects;

namespace Ceyehat.Domain.Flight;

public sealed class Flight : AggregateRoot<FlightId>
{
    public string? flight_no { get; }
    
    public string? airline { get; }

    public FlightStatus status { get; }
    
    public string? aircraft { get; }
    
    public string? departure_airport { get; }
    
    public string? arrival_airport { get; }

    public DateTime departure_date { get; }
    
    public DateTime arrival_date { get; }
    
    public float economy_price { get; }

    public Flight(FlightId id) : base(id)
    {
    }
}