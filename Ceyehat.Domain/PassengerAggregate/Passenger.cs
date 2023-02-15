using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.Entities;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate;

public sealed class Passenger : AggregateRoot<PassengerId>
{
    private readonly List<FlightTicket> _flightTickets = new();

    public CustomerId CustomerId { get; private set; }
    public IReadOnlyCollection<FlightTicket> FlightTicketIds => _flightTickets.AsReadOnly();

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

    public void AddFlightTicket(FlightTicket flightTicket)
    {
        _flightTickets.Add(flightTicket);
    }

    public void RemoveFlightTicket(FlightTicket flightTicket)
    {
        _flightTickets.Remove(flightTicket);
    }
}