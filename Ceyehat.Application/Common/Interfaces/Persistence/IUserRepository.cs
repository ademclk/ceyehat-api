using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}