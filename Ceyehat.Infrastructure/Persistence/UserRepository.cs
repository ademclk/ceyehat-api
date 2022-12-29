using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Entities;

namespace Ceyehat.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    // Just for testing purposes, not for implementation
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}