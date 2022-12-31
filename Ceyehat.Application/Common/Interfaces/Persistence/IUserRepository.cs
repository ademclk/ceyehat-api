using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task Add(User? user);
}