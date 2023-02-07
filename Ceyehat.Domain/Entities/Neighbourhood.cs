namespace Ceyehat.Domain.Entities;

public class Neighbourhood
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string Name { get; set; } = null!;

    public District District { get; set; } = null!;

    public List<AirlineAddress> AirlineAddresses { get; set; } = null!;
}