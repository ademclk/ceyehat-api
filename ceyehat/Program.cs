using ceyehat;
using Ceyehat.Application;
using Ceyehat.Infrastructure;
using Ceyehat.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ceyehat.Common.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddSingleton(new EmailService(builder.Configuration.GetSection("SendGrid").GetValue<string>("ApiKey")!));

    builder.Services.AddDbContext<CeyehatDbContext>(opt => opt.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}