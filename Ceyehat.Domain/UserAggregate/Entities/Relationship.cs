using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.UserAggregate.Entities;

public class Relationship : Entity<RelationshipId>
{
    public RelationshipType Type { get; private set; }
    public CustomerId CustomerId { get; private set; }
    
    private Relationship(
        RelationshipId relationshipId,
        CustomerId customerId,
        RelationshipType type) : base(relationshipId)
    {
        Type = type;
        CustomerId = customerId;
    }

    public static Relationship Create(
        RelationshipType type,
        CustomerId customerId)
    {
        return new(
            RelationshipId.CreateUnique(),
            customerId,
            type);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Relationship()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}