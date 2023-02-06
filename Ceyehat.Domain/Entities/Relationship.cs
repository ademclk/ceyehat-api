namespace Ceyehat.Domain.Entities;

public class Relationship
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PassengerId { get; set; }
    public string RelationshipType { get; set; } = null!;
    
    public User User { get; set; } = null!;
    public Passenger Passenger { get; set; } = null!;
}