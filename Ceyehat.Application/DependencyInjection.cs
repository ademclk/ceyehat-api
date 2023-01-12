using Ceyehat.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Ceyehat.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}