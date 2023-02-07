namespace Ceyehat.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SeatId { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal Price { get; set; }

    public Flight Flight { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
}