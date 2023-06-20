using FluentResults;

namespace Ceyehat.Application.Common.Errors.City;

public class NotFoundError : IError
{
    public string Message { get; } = null!;
    public Dictionary<string, object> Metadata { get; } = null!;
    public List<IError> Reasons { get; } = null!;
}