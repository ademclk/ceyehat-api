using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate.Entities;

public sealed class BoardingPass : Entity<BoardingPassId>
{
    public string? Gate { get; }
    public DateTime BoardingTime { get; }
    
    private BoardingPass(
        BoardingPassId boardingPassId,
        string? gate,
        DateTime boardingTime)
        : base(boardingPassId)
    {
        Gate = gate;
        BoardingTime = boardingTime;
    }

    public static BoardingPass Create(
        string? gate,
        DateTime boardingTime)
    {
        return new(
            BoardingPassId.CreateUnique(),
            gate,
            boardingTime);
    }
}