namespace Ceyehat.Domain.Entities;

public class Airport
{
    public Guid Id { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string IataCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string TimeZone { get; set; } = null!;

    public Neighbourhood Neighbourhood { get; set; } = null!;
}