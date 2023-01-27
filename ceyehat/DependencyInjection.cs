using ceyehat.Common.Errors;
using ceyehat.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ceyehat;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, CeyehatProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}