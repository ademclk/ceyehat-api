using FluentResults;

namespace Ceyehat.Application.Common.Errors.City;

public class NotFoundError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}