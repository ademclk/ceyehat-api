namespace Ceyehat.Domain.Entities;

public class Country
{
    public Guid Id { get; set; }
    public string UnCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Alpha2 { get; set; } = null!;
    public string Alpha3 { get; set; } = null!;

    public List<Airline> Airlines { get; set; } = null!;
    public List<Aircraft> Aircrafts { get; set; } = null!;
    public List<City> Cities { get; set; } = null!;

}