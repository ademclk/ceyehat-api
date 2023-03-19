using Ceyehat.Domain.Enums;

namespace Ceyehat.Application.Common.DTOs;

public class SeatDto
{
    public string? SeatNumber { get; set; }
    public SeatClass SeatClass { get; set; }
    public SeatStatus SeatStatus { get; set; }
}