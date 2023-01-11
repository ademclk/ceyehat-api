using Ceyehat.Domain.Entities;
using Ceyehat.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChefApi.Core.DbOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CeyehatDbContext(serviceProvider.GetRequiredService<DbContextOptions<CeyehatDbContext>>()))
        {
            if (context.Users.Any()) return;

            context.Add(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Adem",
                LastName = "Çelik",
                Email = "ademclk@gmail.com",
                Password = "12345678",
            });

            context.SaveChanges();
        }
    }
}