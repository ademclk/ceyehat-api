namespace Ceyehat.Domain.Entities;

public class Relationship
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid PassengerId { get; set; }
    public string RelationshipType { get; set; } = null!;

    public Customer Customer { get; set; } = null!;
    public Passenger Passenger { get; set; } = null!;
}