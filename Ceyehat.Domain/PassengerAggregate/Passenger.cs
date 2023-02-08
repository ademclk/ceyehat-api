using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate;

public sealed class Passenger : AggregateRoot<PassengerId>
{
    private readonly List<FlightTicketId> _flightTicketIds = new();

    public CustomerId CustomerId { get; private set; }
    public IReadOnlyCollection<FlightTicketId> FlightTicketIds => _flightTicketIds.AsReadOnly();
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Passenger(
        PassengerId passengerId,
        CustomerId customerId, 
        DateTime createdAt,
        DateTime updatedAt) : base(passengerId)
    {
        CustomerId = customerId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Passenger Create(
        CustomerId customerId)
    {
        return new(
            PassengerId.CreateUnique(),
            customerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddFlightTicket(FlightTicketId flightTicketId)
    {
        _flightTicketIds.Add(flightTicketId);
    }

    public void RemoveFlightTicket(FlightTicketId flightTicketId)
    {
        _flightTicketIds.Remove(flightTicketId);
    }
}