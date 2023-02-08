using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<RelationshipId> _relationshipIds = new();
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? Email { get; }
    public string? Password { get; }

    public CustomerId CustomerId { get; }
    public IReadOnlyCollection<RelationshipId> RelationshipIds => _relationshipIds.AsReadOnly();

    private User(
        UserId userId,
        string? firstName,
        string? lastName,
        string? email,
        string? password,
        CustomerId customerId) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CustomerId = customerId;
    }

    public static User Create(
        string? firstName,
        string? lastName,
        string? email,
        string? password,
        CustomerId customerId)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            customerId);
    }
    
    public void AddRelationship(RelationshipId relationshipId)
    {
        _relationshipIds.Add(relationshipId);
    }
    
    public void RemoveRelationship(RelationshipId relationshipId)
    {
        _relationshipIds.Remove(relationshipId);
    }
}