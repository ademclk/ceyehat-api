namespace Ceyehat.Domain.Entities;

public class Aircraft
{
    public Guid Id { get; set; }
    public Guid AirlineId { get; set; }
    public string RegistrationNumber { get; set; } = null!;
    public Guid CountryId { get; set; }
    public string Icao24 { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string AirlineCode { get; set; } = null!;

    public Country Country { get; set; } = null!;
    public Airline Airline { get; set; } = null!;

    public List<Flight> Flights { get; set; } = null!;
    public List<Seat> Seats { get; set; } = null!;
}