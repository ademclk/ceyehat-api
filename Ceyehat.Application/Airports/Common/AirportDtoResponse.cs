namespace Ceyehat.Application.Airports.Common;

public class AirportDtoResponse
{
    public string Name { get; set; } = null!;
    public string IataCode { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string CountryName { get; set; } = null!;
}