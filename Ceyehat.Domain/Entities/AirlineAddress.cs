namespace Ceyehat.Domain.Entities;

public class AirlineAddress
{
    public Guid Id { get; set; }
    public Guid AirlineId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string Address { get; set; } = null!;

    public Airline Airline { get; set; } = null!;
    public Neighbourhood Neighbourhood { get; set; } = null!;

    public ICollection<Airport> Airports { get; set; } = new List<Airport>();
}