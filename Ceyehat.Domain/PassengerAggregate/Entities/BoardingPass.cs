using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate.Entities;

public sealed class BoardingPass : Entity<BoardingPassId>
{
    public string? Gate { get; }
    public DateTime BoardingTime { get; }
    public FlightId FlightId { get; }
    public PassengerId PassengerId { get; }

    private BoardingPass(
        BoardingPassId boardingPassId,
        string? gate,
        DateTime boardingTime,
        FlightId flightId,
        PassengerId passengerId)
        : base(boardingPassId)
    {
        Gate = gate;
        BoardingTime = boardingTime;
        FlightId = flightId;
        PassengerId = passengerId;
    }

    public static BoardingPass Create(
        string? gate,
        DateTime boardingTime,
        FlightId flightId,
        PassengerId passengerId)
    {
        return new(
            BoardingPassId.CreateUnique(),
            gate,
            boardingTime,
            flightId,
            passengerId);
    }
}