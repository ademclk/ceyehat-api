namespace Ceyehat.Domain.Entities;

public class Neighbourhood
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string Name { get; set; } = null!;
    
    public ICollection<AirlineAddress> AirlineAddresses { get; set; } = null!;
    
    public District District { get; set; } = null!;
}