namespace Ceyehat.Application.Common.DTOs;

public class AirportDto
{
    public string? Name { get; set; }
    public string? IataCode { get; set; }
    public string? CityName { get; set; }
    public string? CountryName { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}