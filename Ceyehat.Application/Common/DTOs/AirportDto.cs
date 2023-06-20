namespace Ceyehat.Application.Common.DTOs;

public class AirportDto
{
    public string? Name { get; init; }
    public string? IataCode { get; init; }
    public string? CityName { get; init; }
    public string? CountryName { get; init; }
    public double Longitude { get; init; }
    public double Latitude { get; init; }
}