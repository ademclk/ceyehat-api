using System.ComponentModel.DataAnnotations;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.Entities;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<Relationship> _relationships = new();
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }

    public CustomerId CustomerId { get; private set; }
    public IReadOnlyCollection<Relationship> Relationships => _relationships.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    private User(
        UserId userId,
        string? firstName,
        string? lastName,
        string? email,
        string? password,
        CustomerId customerId,
        DateTime createdAt,
        DateTime updatedAt) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CustomerId = customerId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
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
            customerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddRelationship(Relationship relationship)
    {
        _relationships.Add(relationship);
    }
    
    public void RemoveRelationship(Relationship relationship)
    {
        _relationships.Remove(relationship);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private User()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}   