namespace Ceyehat.Domain.Entities;

public class City
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; } = null!;
    public string CityCode { get; set; } = null!;

    public Country Country { get; set; } = null!;

    public List<Airport> Airports { get; set; } = null!;
}