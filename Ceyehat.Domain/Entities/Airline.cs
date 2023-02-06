namespace Ceyehat.Domain.Entities;

public class Airline
{
    public Guid Id { get; set; }
    public string IataCode { get; set; } = null!;
    public string IcaoCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Website { get; set; } = null!;
    public string CallSign { get; set; } = null!;
    
    public ICollection<Aircraft> Aircrafts { get; set; } = null!;
    public AirlineAddress AirlineAddress { get; set; } = null!;
}
