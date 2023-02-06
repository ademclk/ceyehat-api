using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Domain.Entities;

public class Seat
{
    public Guid Id { get; set; }
    public Guid AircraftId { get; set; }
    public string Number { get; init; } = null!;
    public string Class { get; set; } = null!;

    public Aircraft Aircraft { get; set; } = null!;
}