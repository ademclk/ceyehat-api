using Ceyehat.Application.Common.Interfaces.Services;

namespace Ceyehat.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}