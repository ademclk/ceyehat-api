using Ceyehat.Domain.UserAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<UserId?> GetUserIdByEmailAsync(string email);
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User? user);
}