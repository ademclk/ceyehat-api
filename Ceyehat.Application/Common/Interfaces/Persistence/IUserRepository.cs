using Ceyehat.Domain.UserAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User? user);
}