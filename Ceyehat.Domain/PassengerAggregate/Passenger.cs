using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate;

public sealed class Passenger : AggregateRoot<PassengerId>
{
    private readonly List<FlightTicketId> _flightTicketIds = new();
    
    public CustomerId CustomerId { get; private set; }
    
    public IReadOnlyCollection<FlightTicketId> FlightTicketIds => _flightTicketIds.AsReadOnly();
    
    private Passenger(
        PassengerId passengerId,
        CustomerId customerId)
        : base(passengerId)
    {
        CustomerId = customerId;
    }
    
    public static Passenger Create(
        CustomerId customerId)
    {
        return new(
            PassengerId.CreateUnique(),
            customerId);
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