using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.UserAggregate.Entities;

public class Relationship : Entity<RelationshipId>
{
    public RelationshipType Type { get; }
    public CustomerId CustomerId { get; }

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
}