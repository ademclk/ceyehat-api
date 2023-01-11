using Ceyehat.Application;
using ceyehat.Errors;
using Ceyehat.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ChefApi.Core.DbOperations;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<ProblemDetailsFactory, CeyehatProblemDetailsFactory>();

    builder.Services.AddDbContext<CeyehatDbContext>(opt => opt.UseInMemoryDatabase("ceyehat"));
    // builder.Services.AddDbContext<CeyehatDbContext>(opt => opt.UseNpgsql(
    //     builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        DataGenerator.Initialize(services);
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}