namespace Ceyehat.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }
    
    protected Entity(TId id)
    {
        Id = id;
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
       return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }
    
    public static bool operator ==(Entity<TId> l, Entity<TId> r)
    {
        return Equals(l, r);
    }
    
    public static bool operator !=(Entity<TId> l, Entity<TId> r)
    {
        return !Equals(l, r);
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}
