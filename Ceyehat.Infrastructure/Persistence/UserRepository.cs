using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Ceyehat.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly CeyehatDbContext _dbContext;

    public UserRepository(CeyehatDbContext context)
    {
        _dbContext = context;
    }

    public async Task Add(User? user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    private static User MapUser(NpgsqlDataReader reader)
    {
        return new User
        {
            UserId = reader.GetGuid(0),
            Email = reader.GetString(1),
            Password = reader.GetString(2),
            FirstName = reader.GetString(3),
            LastName = reader.GetString(4)
        };
    }
}