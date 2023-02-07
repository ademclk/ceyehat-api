namespace Ceyehat.Domain.Entities;

public class FlightTicket
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; }
    public Guid SeatId { get; set; }
    public decimal Price { get; set; }

    public BoardingPass? BoardingPass { get; set; } = null!;
    public Flight Flight { get; set; } = null!;
    public Passenger Passenger { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
}