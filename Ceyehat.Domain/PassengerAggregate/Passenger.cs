using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.Entities;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate;

public sealed class Passenger : AggregateRoot<PassengerId>
{
    private readonly List<FlightTicket> _flightTickets = new();
    private readonly List<BoardingPass> _boardingPasses = new();

    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<FlightTicket> FlightTickets => _flightTickets.AsReadOnly();
    public IReadOnlyList<BoardingPass> BoardingPasses => _boardingPasses.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

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
    
    public void AddBoardingPass(BoardingPass boardingPass)
    {
        _boardingPasses.Add(boardingPass);
    }
    
    public void RemoveBoardingPass(BoardingPass boardingPass)
    {
        _boardingPasses.Remove(boardingPass);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Passenger()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}