namespace Ceyehat.Application.Customers.Common;

public class FlightTicketDtoResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FlightNumber { get; set; }
    public string? DepartureIata { get; set; }
    public string? DepartureName { get; set; }
    public string? ArrivalIata { get; set; }
    public string? ArrivalName { get; set; }
    public string? DepartureDate { get; set; }
    public string? ArrivalDate { get; set; }
    public string? DepartureTime { get; set; }
    public string? ArrivalTime { get; set; }
    public string? SeatNumber { get; set; }
    public float Price { get; set; }
    public string? Currency { get; set; }
    public string? Status { get; set; }
}