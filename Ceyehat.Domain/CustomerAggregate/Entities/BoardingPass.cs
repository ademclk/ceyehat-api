using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate.Entities;

public class BoardingPass : Entity<BoardingPassId>
{
    public string? BoardingGroup { get; private set; }
    public string? BoardingGate { get; private set; }
    public DateTime BoardingTime { get; private set; }
    public DateTime CheckInTime { get; private set; }
    
    private BoardingPass(
        BoardingPassId boardingPassId,
        string boardingGroup,
        string boardingGate,
        DateTime boardingTime,
        DateTime checkInTime) : base(boardingPassId)
    {
        BoardingGroup = boardingGroup;
        BoardingGate = boardingGate;
        BoardingTime = boardingTime;
        CheckInTime = checkInTime;
    }
    
    public static BoardingPass Create(
        string boardingGroup,
        string boardingGate,
        DateTime boardingTime,
        DateTime checkInTime)
    {
        return new(
            BoardingPassId.CreateUnique(),
            boardingGroup,
            boardingGate,
            boardingTime,
            checkInTime);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected BoardingPass()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.  
}