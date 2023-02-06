namespace Ceyehat.Domain.Entities;

public class District
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Neighbourhood> Neighbourhoods { get; set; } = null!;

    public City City { get; set; } = null!;
}