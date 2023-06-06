namespace Ceyehat.Application.Customers.Common;

public class BookingDtoResponse
{
    public string? BookingId { get; set; }
    public string? SeatId { get; set; }
    public string? SeatNumber { get; set; }
    public string? FlightId { get; set; }
    public string? FlightNumber { get; set; }
    public string? Currency { get; set; }
    public float Price { get; set; }
    public string? PassengerType { get; set; }
}