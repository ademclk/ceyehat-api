namespace Ceyehat.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; }
    public Guid SeatId { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal Price { get; set; }

    public Flight Flight { get; set; } = null!;
    public Passenger Passenger { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
}