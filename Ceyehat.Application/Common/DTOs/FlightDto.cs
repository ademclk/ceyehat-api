namespace Ceyehat.Application.Common.DTOs;

public class FlightDto
{
    public string? FlightNumber { get; set; }
    public string? AirlineName { get; set; }
    public string? AircraftName { get; set; }
    public DateTime? DepartureHour { get; set; }
    public DateTime? ArrivalHour { get; set; }
    public decimal EconomyPrice { get; set; }
    public decimal ComfortPrice { get; set; }
    public decimal BusinessPrice { get; set; }
    public List<SeatDto>? Seats { get; set; }
}